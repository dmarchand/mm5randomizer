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
                    List<KeyValuePair<Enemy, byte>> addedEnemiesToXPos = new List<KeyValuePair<Enemy, byte>>();

                    shuffledAddresses.ForEach(currentAddress => {
                        byte enemyIDValue = patcher.GetByteAtAddress(currentAddress);

                        int yPosLocation = currentAddress - Level.Y_POS_OFFSET_BASE;
                        byte yPos = patcher.GetByteAtAddress(yPosLocation);

                        int xPosLocation = currentAddress - Level.X_POS_OFFSET_BASE;
                        byte xPos = patcher.GetByteAtAddress(xPosLocation);

                        if (Enemies.EnemyData.Exists(enemy => enemy.Value == enemyIDValue)) {
                            var enemyToReplace = Enemies.EnemyData.Where(enemy => enemy.Value == enemyIDValue).First();
                            List<Enemy> validEnemies = null;

                            if (enemyToReplace.IsFlying) {
                                validEnemies = Enemies.EnemyData.Where(enemy => enemy.IsFlying || enemy.CanReplaceFliers).ToList();
                            } else if (enemyToReplace.IsInverted) {
                                validEnemies = Enemies.EnemyData.Where(enemy => enemy.IsInverted || enemy.IsFlying || enemy.CanReplaceFliers).ToList();
                            } else if (enemyToReplace.IsJetSkiOnly) {
                                validEnemies = Enemies.EnemyData.Where(enemy => enemy.IsJetSkiOnly).ToList();
                            } else if (enemyToReplace.IsUnderwaterOnly) {
                                validEnemies = Enemies.EnemyData.Where(enemy => enemy.IsUnderwaterOnly || enemy.IsFlying || enemy.CanReplaceFliers).ToList();
                            } else if (enemyToReplace.IsBigBoy) {
                                validEnemies = Enemies.EnemyData.Where(enemy => enemy.IsBigBoy).ToList();
                            } else {
                                validEnemies = Enemies.EnemyData.Where(enemy => !enemy.IsInverted
                                    && !enemy.IsJetSkiOnly
                                    && !enemy.IsUnderwaterOnly
                                    && !enemy.IsBigBoy
                                    && (!enemy.Name.Contains("Spike Wheel") || random.Next(0, 3) == 1)).ToList(); // Too many spike wheels, weed them out a bit
                            }

                            // Remove conflicting enemies
                            foreach(var kvp in addedEnemiesToXPos) {
                                var enemyToCompare = kvp.Key;

                                if (enemyToCompare.EnemyNameId != EnemyNameId.NullEnemy) {
                                    validEnemies.RemoveAll(enemy => {
                                        bool conflict = false;
                                        if (enemy.SpriteBank == enemyToCompare.SpriteBank) {
                                            conflict = true;
                                            EnemyCompatabilityGroupings.SameSpriteGroupings.ForEach(grouping => conflict &= !(grouping.Contains(enemy.EnemyNameId) && grouping.Contains(enemyToCompare.EnemyNameId)));
                                        }
                                        EnemyExclusionGroupings.ExclusionGroupings.ForEach(grouping => conflict |= (grouping.Contains(enemy.EnemyNameId) && grouping.Contains(enemyToCompare.EnemyNameId)));
                                        return conflict;
                                    });
                                }
                            }

                            Enemy selectedEnemy = null;
                            if (validEnemies.Count == 0) {
                                selectedEnemy = new Enemy(EnemyNameId.NullEnemy, 0, false, false, false, false, false, false, 0);
                            } else {
                                selectedEnemy = validEnemies[random.Next(0, validEnemies.Count)];
                            }
                            byte newYPos = (byte)(yPos + selectedEnemy.YOffset - enemyToReplace.YOffset);

                            patcher.AddRomModification(currentAddress, selectedEnemy.Value, selectedEnemy.Name);
                            patcher.AddRomModification(yPosLocation, newYPos, selectedEnemy.Name);

                            addedEnemiesToXPos.Add(new KeyValuePair<Enemy, byte>(selectedEnemy, xPos));
                        } else if(IrreplaceableEnemies.EnemyData.Exists(enemy => enemy.Value == enemyIDValue)) { // If this is an enemy we don't want to replace, store it for sprite bank reasons
                            Enemy existingEnemy = IrreplaceableEnemies.EnemyData.Where(enemy => enemy.Value == enemyIDValue).First();
                            addedEnemiesToXPos.Add(new KeyValuePair<Enemy, byte>(existingEnemy, 0));
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
