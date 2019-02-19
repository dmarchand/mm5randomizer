using Megaman5Randomizer.Data;
using Megaman5Randomizer;
using System;
using System.Collections.Generic;
using System.Text;
using RomWriter;
using System.Linq;

namespace Megaman5Randomizer.RandomizationStrategy
{
    public class NormalEnemyRandomizer : IRandomizationStrategy
    {
        public void Randomize(Random random, RomPatcher patcher, Config config) {
            Levels.RobotMasterLevelData.ForEach(level => {
                ReplaceEnemiesRandomly(level, random, patcher);    
            });
        }

        void ReplaceEnemiesRandomly(Level level, Random random, RomPatcher patcher) {
            int enemyIndex = 0;
            int currentScreen = 0;
            int previousScreen = 0;
            bool screenHasHighCostEnemy = false;

            for(int address = level.EnemyDataAddress; address <= level.EnemyDataAddressEnd; address += 1) {
                byte enemyIDValue = patcher.GetByteAtAddress(address);
                byte screenValue = patcher.GetByteAtAddress(level.ScreenNumberStart + enemyIndex);
                int yPosLocation = level.YPosStart + enemyIndex;
                byte yPos = patcher.GetByteAtAddress(yPosLocation);

                currentScreen = screenValue;

                if(currentScreen != previousScreen) {
                    screenHasHighCostEnemy = false;
                }

                if (Enemies.EnemyData.Exists(enemy => enemy.Value == enemyIDValue)) {
                    Enemy enemyToReplace = Enemies.EnemyData.Where(enemy => enemy.Value == enemyIDValue).First();
                    List<Enemy> validEnemies = null;

                    if(enemyToReplace.IsFlyingOnly) {
                        validEnemies = Enemies.EnemyData.Where(enemy => enemy.IsFlyingOnly).ToList();
                    } else if(enemyToReplace.IsInverted) {
                        validEnemies = Enemies.EnemyData.Where(enemy => enemy.IsInverted).ToList();
                    } else if(enemyToReplace.IsJetSkiOnly) {
                        validEnemies = Enemies.EnemyData.Where(enemy => enemy.IsJetSkiOnly).ToList();
                    } else if(enemyToReplace.IsUnderwaterOnly) {
                        validEnemies = Enemies.EnemyData.Where(enemy => enemy.IsUnderwaterOnly).ToList();
                    } else {
                        validEnemies = Enemies.EnemyData.Where(enemy => !enemy.IsFlyingOnly && !enemy.IsInverted && !enemy.IsJetSkiOnly && !enemy.IsUnderwaterOnly).ToList();
                    }

                    if(screenHasHighCostEnemy) {
                        validEnemies.RemoveAll(enemy => enemy.IsHighRenderCost);
                    }

                    Enemy selectedEnemy = validEnemies[random.Next(0, validEnemies.Count)];

                    if(selectedEnemy.IsHighRenderCost) {
                        screenHasHighCostEnemy = true;
                    }

                    byte newYPos = (byte)(yPos + selectedEnemy.YOffset - enemyToReplace.YOffset);
                    
                    patcher.AddRomModification(address, selectedEnemy.Value, selectedEnemy.Name);
                    patcher.AddRomModification(yPosLocation, newYPos, selectedEnemy.Name);
                    //Console.Out.WriteLine("Wrote Enemy: " + selectedEnemy.Name + " at addr: " + address + " at new YPos: " + newYPos);
                }
                enemyIndex++;
                previousScreen = currentScreen;
            }
        }
    }
}
