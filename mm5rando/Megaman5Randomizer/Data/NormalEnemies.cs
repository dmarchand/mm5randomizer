using System;
using System.Collections.Generic;
using System.Text;

namespace Megaman5Randomizer.Data
{
    public class NormalEnemies
    {
        public static List<Enemy> EnemyData = new List<Enemy>() {
            new Enemy(0x00, "Ballhead Guy"),
            new Enemy(0x04, "Tiger"),
            new Enemy(0x05, "Rat"),
            new Enemy(0x17, "Scooter Guy"),
            new Enemy(0x03, "Space Metool"),
            new Enemy(0x08, "Cannon Metool"),
            new Enemy(0x10, "Pit Guard"),
            new Enemy(0x14, "Sniper Joe"),
            new Enemy(0x15, "Dusty Joe"),
            new Enemy(0x16, "Ball Thrower"),
            new Enemy(0x18, "Crystal Joe"),
            new Enemy(0x1D, "Cannon"),
            new Enemy(0x2A, "Spiral Neck"),
            new Enemy(0x31, "Metool"),
            new Enemy(0x2C, "Catapult Joe"),
            new Enemy(0x35, "Stone Thrower"),
            new Enemy(0x39, "Fowl"),
            new Enemy(0x38, "Surrounder"),
        };
    }
}
