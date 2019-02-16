using System;
using System.Collections.Generic;
using System.Text;

namespace Megaman5Randomizer.Data
{
    public class Level
    {
        private const int ENEMY_DATA_OFFSET = 2960;
        private const int ENEMY_DATA_LENGTH = 80;

        const int WEAPON_GET_OFFSET = 0x2EF29;
        public string Name { get; set; }
        public int StartAddress { get; set; }

        public int WeaponGetIndex { get; set; }
        public int EnemyDataAddress {
            get; set;
        }
        public int EnemyDataAddressEnd {
            get {
                return EnemyDataAddress + ENEMY_DATA_LENGTH;
            }
        }

        public Level(int startAddress, int enemyDataAddress, int weaponGetIndex, string name) {
            StartAddress = startAddress;
            EnemyDataAddress = enemyDataAddress;
            Name = name;
            WeaponGetIndex = weaponGetIndex + WEAPON_GET_OFFSET;
        }
    }
}
