using System;
using System.Collections.Generic;
using System.Text;

namespace Megaman5Randomizer.Data.Enemies
{
    /// <summary>
    /// Primarily used on stages with rising/falling platforms
    /// </summary>
    public class GravityRequiredEnemyGroupings
    {
        public static List<EnemyNameId> Groupings = new List<EnemyNameId>() {
            EnemyNameId.Scooper,
            EnemyNameId.ChopperJoe,
            EnemyNameId.GreenPukapuka,
            EnemyNameId.PukaPuka,
            EnemyNameId.SkullDropper,
            EnemyNameId.SpikeSlammer,
            EnemyNameId.TonDale,
            EnemyNameId.Lyric,
            EnemyNameId.MetAstronaut,
            EnemyNameId.Missile
        };
    }
}
