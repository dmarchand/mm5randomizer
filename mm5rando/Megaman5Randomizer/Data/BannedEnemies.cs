using System;
using System.Collections.Generic;
using System.Text;

namespace Megaman5Randomizer.Data
{
    public class BannedEnemies
    {
        public static List<Enemy> EnemyData = new List<Enemy>() {
            new Enemy(0x42, "Gravity 1"),
            new Enemy(0x43, "Gravity 2"),
            new Enemy(0x44, "Gravity 3"),
            new Enemy(0x45, "Gravity 4"),
            new Enemy(0x46, "Gravity 5"),
            new Enemy(0x65, "Gravity Man")
        };
    }
}
