using System;
using System.Collections.Generic;
using System.Text;

namespace Megaman5Randomizer.Data
{
    public class FlyingEnemies
    {
        public static List<Enemy> EnemyData = new List<Enemy>() {
            new Enemy(0x12, "Drop Capsule"),
            new Enemy(0x02, "Skull Dropper"),
            new Enemy(0x07, "Bomb Dropper"),
            new Enemy(0x0D, "Flying Cannon Guy"),
        };
    }
}
