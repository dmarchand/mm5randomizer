using Megaman5Randomizer.Data.Enemies;
using Megaman5Randomizer.Data.Levels;
using Megaman5Randomizer.Data.Objects;
using RomWriter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Megaman5Randomizer.RandomizationStrategy
{
    public class BossRandomizer : IRandomizationStrategy {
        private const int BOSS_GAME_OBJECT_MAPPER_START = 0x0143E8;
        private const int GRAVITY_MAN_GIMMICK = 0x0142C7;
        private const int GRAVITY_MAN_SWITCHER = 0x0BC7;
        private const int TAUNT_FRAME_MAP = 0x143D0;
        private const int ANIMATION_MAP = 0x143DC;

        public void Randomize(Random random, RomPatcher patcher, Config config) {
            List<GameObject> bossObjects = new List<GameObject>(RobotMasterObjects.ObjectData);
            List<Level> bossLevels = new List<Level>(Levels.LevelData.GetRange(0, 8));
            Dictionary<Level, GameObject> bossSlots = new Dictionary<Level, GameObject>();

            bossObjects.ForEach(bossObject => {
                Level levelToOccupy = bossLevels[random.Next(bossLevels.Count - 1)];
                bossSlots.Add(levelToOccupy, bossObject);
                bossLevels.Remove(levelToOccupy);
            });

            bossSlots.Keys.ToList().ForEach(bossLevel => {
                Console.Out.WriteLine("Replacing boss of " + bossLevel.Name + " with " + bossSlots[bossLevel].Name);
                patcher.AddRomModification(bossLevel.BossAILoaderIndex, (byte)bossSlots[bossLevel].ObjectId, bossSlots[bossLevel].Name);
                UpdateBossSprite(bossLevel, bossSlots[bossLevel], patcher);
                UpdateTauntFrames(bossLevel, bossSlots[bossLevel], patcher);
                UpdateAnimationReference(bossLevel, bossSlots[bossLevel], patcher);
            });

            // Remove Gravity Man's Gimmick if necessary
            if(bossSlots[bossSlots.Keys.Where(slot => slot.Name == "Gravity Man Stage").First()].ObjectId != 0x81) {
                patcher.AddRomModification(GRAVITY_MAN_GIMMICK, 0xA9, "Removing Gravity Man boss door gimmick");
                patcher.AddRomModification(GRAVITY_MAN_SWITCHER, 0xBF, "Removing Gravity Man switcher");
            }
        }

        private void UpdateBossSprite(Level level, GameObject bossObject, RomPatcher patcher) {
            Enemy bossEnemy = RobotMasterEnemies.EnemyData.Where(enemy => enemy.Name == bossObject.Name).First();
            for(int addr = level.EnemyDataAddress; addr <= level.EnemyDataAddressEnd; addr++) {
                int enemyId = patcher.GetByteAtAddress(addr);

                if(enemyId == (int)level.BossEnemy) {
                    patcher.AddRomModification(addr, (byte)bossEnemy.EnemyNameId);
                    Console.Out.WriteLine("Replacing enemy at " + addr + " with new boss sprite");
                    return;
                }
            }
            Console.Out.WriteLine("Orphaned robot master: " + bossObject.Name);
        }

        private void UpdateTauntFrames(Level level, GameObject bossObject, RomPatcher patcher) {
            List<Level> bossLevels = new List<Level>(Levels.LevelData.GetRange(0, 8));
            Enemy bossEnemy = RobotMasterEnemies.EnemyData.Where(enemy => enemy.Name == bossObject.Name).First();
            int levelIndex = bossLevels.IndexOf(level);

            patcher.AddRomModification(TAUNT_FRAME_MAP + levelIndex, (byte)bossEnemy.TauntFrames);
        }

        private void UpdateAnimationReference(Level level, GameObject bossObject, RomPatcher patcher) {
            List<Level> bossLevels = new List<Level>(Levels.LevelData.GetRange(0, 8));
            Enemy bossEnemy = RobotMasterEnemies.EnemyData.Where(enemy => enemy.Name == bossObject.Name).First();
            int levelIndex = bossLevels.IndexOf(level);

            patcher.AddRomModification(ANIMATION_MAP + levelIndex, (byte)bossEnemy.TauntFrames);
        }
    }
}
