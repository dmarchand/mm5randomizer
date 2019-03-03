using System;
using System.Collections.Generic;
using System.Text;

namespace Megaman5Randomizer.Data.Enemies
{
    public class EnemyCompatabilityGroupings
    {
        public static List<List<EnemyNameId>> SameSpriteGroupings = new List<List<EnemyNameId>>() {
            new List<EnemyNameId>() { EnemyNameId.BoatJoeLeft, EnemyNameId.BoatJoeRight }, // Boats
            new List<EnemyNameId>() { EnemyNameId.SpikeWheelFastLeft, EnemyNameId.SpikeWheelFastRight, EnemyNameId.SpikeWheelLeft, EnemyNameId.SpikeWheelRight }, // Red Spike Wheels 
            new List<EnemyNameId>() { EnemyNameId.GreenSpikeWheelFastLeft, EnemyNameId.GreenSpikeWheelFastRight, EnemyNameId.GreenSpikeWheelOtherRight, EnemyNameId.GreenSpikeWheelOtherRight }, // Green Spike Wheels
            new List<EnemyNameId>() { EnemyNameId.IronKuange, EnemyNameId.IronKuangeInverted }, // Iron traps
            new List<EnemyNameId>() { EnemyNameId.SusieG, EnemyNameId.SusieGInverted }, // Susie Gs
            new List<EnemyNameId>() { EnemyNameId.Rat, EnemyNameId.Taban, EnemyNameId.Orbiter }, // Tiny friends
            new List<EnemyNameId>() { EnemyNameId.GreenPukapuka, EnemyNameId.Lyric, EnemyNameId.DaidineDown, EnemyNameId.DaidineDownLeft,
                EnemyNameId.DaidineDownRight, EnemyNameId.DaidineLeft, EnemyNameId.DaidineRight, EnemyNameId.DaidineRight,
                EnemyNameId.DaidineUp, EnemyNameId.DaidineUpLeft, EnemyNameId.DaidineUpRight } // Daidines are very small
        };
    }
}
