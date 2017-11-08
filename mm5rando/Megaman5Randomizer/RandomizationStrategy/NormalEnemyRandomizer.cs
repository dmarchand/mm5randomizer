using Megaman5Randomizer.Data;
using Megaman5Randomizer;
using System;
using System.Collections.Generic;
using System.Text;
using RomWriter;

namespace Megaman5Randomizer.RandomizationStrategy
{
    public class NormalEnemyRandomizer : IRandomizationStrategy
    {
        public void Randomize(Random random, RomPatcher patcher) {
            Levels.LevelData.ForEach(level => {
                ReplaceEnemiesRandomly(level, random, patcher);    
            });
        }

        void ReplaceEnemiesRandomly(Level level, Random random, RomPatcher patcher) {
            int bytesPerEnemy = 1;

            for(int address = level.EnemyDataAddress; address <= level.EnemyDataAddressEnd; address += bytesPerEnemy) {
                byte value = patcher.GetByteAtAddress(address);

                if (!BannedEnemies.EnemyData.Exists(banned => banned.Value == value)) {
                    Enemy enemy = null;
                    if (FlyingEnemies.EnemyData.Exists(flying => flying.Value == value)) {
                        int index = random.Next(0, FlyingEnemies.EnemyData.Count);
                        enemy = FlyingEnemies.EnemyData[index];
                    } else {
                        int index = random.Next(0, NormalEnemies.EnemyData.Count);
                        enemy = NormalEnemies.EnemyData[index];
                    }
                    patcher.AddRomModification(address, enemy.Value, enemy.Name);
                    Console.Out.WriteLine("Wrote Enemy: " + enemy.Name + " at addr: " + address);
                }             
            }
        }
    }
}
