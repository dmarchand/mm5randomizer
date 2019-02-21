using Megaman5Randomizer.Data;
using Megaman5Randomizer;
using System;
using System.Collections.Generic;
using System.Text;
using RomWriter;
using System.Linq;
using Megaman5Randomizer.Data.Enemies;

namespace Megaman5Randomizer.RandomizationStrategy
{
    public class NormalEnemyRandomizer : IRandomizationStrategy
    {
        public void Randomize(Random random, RomPatcher patcher, Config config) {
            Levels.LevelData.ForEach(level => {
                ReplaceEnemiesRandomly(level, random, patcher);    
            });
        }

        void ReplaceEnemiesRandomly(Level level, Random random, RomPatcher patcher) {
            int enemyIndex = 0;
            byte currentScreen = 1;
            List<int> addressesToShuffle = new List<int>();

            for (int address = level.EnemyDataAddress; address <= level.EnemyDataAddressEnd; address++) {
                byte screenValue = patcher.GetByteAtAddress(level.ScreenNumberStart + enemyIndex);
                if (screenValue != currentScreen) {
                    List<int> shuffledAddresses = addressesToShuffle.OrderBy((item) => random.Next()).ToList();
                    List<KeyValuePair<byte, byte>> addedEnemiesToXPos = new List<KeyValuePair<byte, byte>>();

                    shuffledAddresses.ForEach(currentAddress => {
                        byte enemyIDValue = patcher.GetByteAtAddress(currentAddress);

                        int yPosLocation = currentAddress - Level.Y_POS_OFFSET_BASE;
                        byte yPos = patcher.GetByteAtAddress(yPosLocation);

                        int xPosLocation = currentAddress - Level.X_POS_OFFSET_BASE;
                        byte xPos = patcher.GetByteAtAddress(xPosLocation);

                        if (Enemies.EnemyData.Exists(enemy => enemy.Value == enemyIDValue)) {
                            var enemyToReplace = Enemies.EnemyData.Where(enemy => enemy.Value == enemyIDValue).First();
                            List<Enemy> validEnemies = null;

                            if (enemyToReplace.IsFlyingOnly) {
                                validEnemies = Enemies.EnemyData.Where(enemy => enemy.IsFlyingOnly).ToList();
                            } else if (enemyToReplace.IsInverted) {
                                validEnemies = Enemies.EnemyData.Where(enemy => enemy.IsInverted).ToList();
                            } else if (enemyToReplace.IsJetSkiOnly) {
                                validEnemies = Enemies.EnemyData.Where(enemy => enemy.IsJetSkiOnly).ToList();
                            } else if (enemyToReplace.IsUnderwaterOnly) {
                                validEnemies = Enemies.EnemyData.Where(enemy => enemy.IsUnderwaterOnly).ToList();
                            } else if (enemyToReplace.IsBigBoy) {
                                validEnemies = Enemies.EnemyData.Where(enemy => enemy.IsBigBoy).ToList();
                            } else {
                                validEnemies = Enemies.EnemyData.Where(enemy => !enemy.IsFlyingOnly
                                    && !enemy.IsInverted
                                    && !enemy.IsJetSkiOnly
                                    && !enemy.IsUnderwaterOnly
                                    && !enemy.IsBigBoy
                                    && (!enemy.Name.Contains("Spike Wheel") || random.Next(0, 2) == 1)).ToList(); // Too many spike wheels, weed them out a bit
                            }

                            // Remove conflicting enemies that will be close to each other
                            foreach(var kvp in addedEnemiesToXPos) {
                                var enemyId = kvp.Key;
                                var enemyXPos = kvp.Value;
                                //bool inRange = Enumerable.Range(xPos - 0xD0, xPos + 0xD0).Contains(xPos);
                                bool inRange = true;
                                if (inRange && EnemyExclusions.Exclusions.Keys.Contains(enemyId)) {
                                    var exclusions = EnemyExclusions.Exclusions[enemyId];

                                    validEnemies.RemoveAll(enemy => exclusions.Contains(enemy.Value));
                                }
                            }

                            Enemy selectedEnemy = validEnemies[random.Next(0, validEnemies.Count)];
                            byte newYPos = (byte)(yPos + selectedEnemy.YOffset - enemyToReplace.YOffset);

                            patcher.AddRomModification(currentAddress, selectedEnemy.Value, selectedEnemy.Name);
                            patcher.AddRomModification(yPosLocation, newYPos, selectedEnemy.Name);

                            addedEnemiesToXPos.Add(new KeyValuePair<byte, byte>(selectedEnemy.Value, xPos));
                        }
                    });

                    currentScreen = screenValue; // Advance to next screen
                    address--; // Reset back one address so we can re-process this enemy
                    addressesToShuffle.Clear();
                } else {
                    addressesToShuffle.Add(address);
                    enemyIndex++;
                }    
            }
        }
    }
}
