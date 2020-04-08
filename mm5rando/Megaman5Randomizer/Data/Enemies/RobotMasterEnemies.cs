using System;
using System.Collections.Generic;
using System.Text;

namespace Megaman5Randomizer.Data.Enemies {
    class RobotMasterEnemies {
        public static List<Enemy> EnemyData = new List<Enemy>() {
            new Enemy(EnemyNameId.GravityMan, 4, false, false, false, false, false, false, 2, false, false, false, 0x0C, 0x01),
            new Enemy(EnemyNameId.WaveMan, 4, false, false, false, false, false, false, 2, false, false, false, 0x10, 0x2A),
            new Enemy(EnemyNameId.StoneMan, 4, false, false, false, false, false, false, 2, false, false, false, 0x09, 0x08),
            new Enemy(EnemyNameId.GyroMan, 4, false, false, false, false, false, false, 2, false, false, false, 0x1D, 0x12),
            new Enemy(EnemyNameId.StarMan, 4, false, false, false, false, false, false, 2, false, false, false, 0x1E, 0x3C),
            new Enemy(EnemyNameId.ChargeMan, 4, false, false, false, false, false, false, 2, false, false, false, 0x0C, 0x19),
            new Enemy(EnemyNameId.NapalmMan, 4, false, false, false, false, false, false, 2, false, false, false, 0x09, 0x32),
            new Enemy(EnemyNameId.CrystalMan, 4, false, false, false, false, false, false, 2, false, false, false, 0x15, 0x24),
        };
    }
}
