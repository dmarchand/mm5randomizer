using System;
using System.Collections.Generic;
using System.Text;

namespace Megaman5Randomizer.Data.Enemies
{
    public class IrreplaceableEnemies
    {
        public static List<Enemy> EnemyData = new List<Enemy>() {
            new Enemy(EnemyNameId.PitGuard, 0, false, false, false, false, false, false, 3, false, false, true),
            new Enemy(EnemyNameId.CrystalSpawner, 0, false, false, false, false, false, false, 3, false, false, true),
            new Enemy(EnemyNameId.WaveCrack, 0, false, false, false, false, false, false, 2, false, false, true),
            new Enemy(EnemyNameId.DaidineDown, 0, false, false, false, false, false, false, 2, false, true),
            new Enemy(EnemyNameId.DaidineDownLeft, 0, false, false, false, false, false, false, 2, false, true),
            new Enemy(EnemyNameId.DaidineDownRight, 0, false, false, false, false, false, false, 2, false, true),
            new Enemy(EnemyNameId.DaidineLeft, 0, false, false, false, false, false, false, 2, false, true),
            new Enemy(EnemyNameId.DaidineRight, 0, false, false, false, false, false, false, 2, false, true),
            new Enemy(EnemyNameId.DaidineUp, 0, false, false, false, false, false, false, 2, false, true),
            new Enemy(EnemyNameId.DaidineUpLeft, 0, false, false, false, false, false, false, 2, false, true),
            new Enemy(EnemyNameId.DaidineUpRight, 0, false, false, false, false, false, false, 2, false, true),
        };
    }
}
