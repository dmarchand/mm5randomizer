using System;
using System.Collections.Generic;
using System.Text;

namespace Megaman5Randomizer.Data
{
    public class Level
    {
        const int ENEMY_DATA_OFFSET = 2960;
        const int ENEMY_DATA_LENGTH = 80;
        public string Name { get; set; }
        public int StartAddress { get; set; }
        public int EnemyDataAddress {
            get; set;
        }
        public int EnemyDataAddressEnd {
            get {
                return EnemyDataAddress + ENEMY_DATA_LENGTH;
            }
        }

        public Level(int startAddress, int enemyDataAddress, string name) {
            StartAddress = startAddress;
            EnemyDataAddress = enemyDataAddress;
            Name = name;
        }
    }
}
