using System;
using System.Collections.Generic;
using System.Text;

namespace Megaman5Randomizer.Data.Enemies
{
    public class EnemyExclusionGroupings
    {
        public static List<List<EnemyNameId>> ExclusionGroupings = new List<List<EnemyNameId>>() {
            new List<EnemyNameId>() { EnemyNameId.Graviton, EnemyNameId.CrystalJoe }, // PPU overflow, I think?
            new List<EnemyNameId>() { EnemyNameId.Graviton, EnemyNameId.BouncyGuy }, // PPU overflow, I think?
            new List<EnemyNameId>() { EnemyNameId.Graviton, EnemyNameId.DaidineDown, EnemyNameId.DaidineDownLeft,
                EnemyNameId.DaidineDownRight, EnemyNameId.DaidineLeft, EnemyNameId.DaidineRight, EnemyNameId.DaidineRight,
                EnemyNameId.DaidineUp, EnemyNameId.DaidineUpLeft, EnemyNameId.DaidineUpRight }
        };
    }
}
