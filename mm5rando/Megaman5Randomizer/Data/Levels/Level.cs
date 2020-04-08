using Megaman5Randomizer.Data.Enemies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Megaman5Randomizer.Data.Levels
{
    public class Level
    {
        private const int ENEMY_DATA_OFFSET = 2960;
        private const int ENEMY_DATA_LENGTH = 120;
        private const int SCREEN_NUMBER_OFFSET_BASE = 0x180;
        public const int Y_POS_OFFSET_BASE = 0x80;
        public const int X_POS_OFFSET_BASE = 0x100;
        private const int WEAPON_GET_OFFSET = 0x2EF29;

        public string Name { get; set; }
        public int StartAddress { get; set; }

        public int WeaponGetIndex { get; set; }

        public int BossAILoaderIndex { get; set; }

        public int EnemyDataAddress {
            get; set;
        }

        public EnemyNameId BossEnemy { get; set; }
        public int EnemyDataAddressEnd {
            get {
                return EnemyDataAddress + ENEMY_DATA_LENGTH;
            }
        }
        public int YPosStart;
        public int ScreenNumberStart;


        public Dictionary<int, List<EnemyNameId>> OffsetToSpecialEnemyList { get; }

        public Level(int startAddress, int enemyDataAddress, int weaponGetIndex, int bossAILoaderIndex, EnemyNameId boss, string name) {
            StartAddress = startAddress;
            EnemyDataAddress = enemyDataAddress;
            Name = name;
            WeaponGetIndex = weaponGetIndex;
            ScreenNumberStart = enemyDataAddress - SCREEN_NUMBER_OFFSET_BASE;
            YPosStart = enemyDataAddress - Y_POS_OFFSET_BASE;
            BossAILoaderIndex = bossAILoaderIndex;
            BossEnemy = boss;
            OffsetToSpecialEnemyList = new Dictionary<int, List<EnemyNameId>>();
        }
    }
}
