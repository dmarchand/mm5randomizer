using System;
using System.Collections.Generic;
using System.Text;

namespace Megaman5Randomizer.Data.Enemies
{
    public class Enemies
    {
        public static List<Enemy> EnemyData = new List<Enemy>() {
            new Enemy(EnemyNameId.PukkaPucker, 4, false, false, false, false, false, false, 2),
            new Enemy(EnemyNameId.SpikeSlammer, 0, false, true, false, false, false, false, 2),
            new Enemy(EnemyNameId.SkullDropper, 0, false, true, false, false, false, false, 2),
            new Enemy(EnemyNameId.MetAstronaut, 0, false, true, false, false, false, true, 2),
            new Enemy(EnemyNameId.Tiger, 0, false, false, false, false, false, false, 2),
            new Enemy(EnemyNameId.Rat, 7, false, false, false, false, false, false, 2),
            new Enemy(EnemyNameId.ShieldAttacker, -4, false, false, false, false, false, false, 2, true),
            new Enemy(EnemyNameId.BombDropper, 0, false, true, false, false, false, false, 3),
            new Enemy(EnemyNameId.MetTurret, -4, false, false, false, false, false, true, 3),
            new Enemy(EnemyNameId.MetTrain, -4, true, false, false, false, false, true, 3),
            new Enemy(EnemyNameId.Buoy, 0, false, false, false, true, false, false, 2),
            new Enemy(EnemyNameId.PowerMuscler, -0x0F, false, false, false, false, false, true, 2, false, true),
            new Enemy(EnemyNameId.ChopperJoe, 0, false, true, false, false, false, true, 2),
            new Enemy(EnemyNameId.IronKuangeInverted, -7, false, false, true, false, false, true, 3),
            new Enemy(EnemyNameId.IronKuange, 8, false, false, false, false, false, true, 3),
            new Enemy(EnemyNameId.Graviton, 0, false, true, false, false, false, false, 2),
            new Enemy(EnemyNameId.VerticalPakkan, -5, false, false, false, false, false, false, 3),
            new Enemy(EnemyNameId.Fugene, 0, true, false, false, false, false, true, 3),
            new Enemy(EnemyNameId.BomberSloan, -4, false, false, false, false, false, true, 2),
            new Enemy(EnemyNameId.BoatJoeRight, -2, false, false, false, true, false, false, 3),
            new Enemy(EnemyNameId.CrystalJoe, -2, false, false, false, false, false, true, 2),
            new Enemy(EnemyNameId.SusieG, 0, false, false, false, false, false, false, 2),
            new Enemy(EnemyNameId.SusieGInverted, 0, false, false, true, false, false, false, 2),
            new Enemy(EnemyNameId.Yudon, -4, false, false, false, false, false, false, 2, false, true),
            new Enemy(EnemyNameId.Hirarian427, -8, false, false, true, false, false, false, 2, false),
            new Enemy(EnemyNameId.Dacology, -7, false, false, false, false, false, false, 2, false, true),
            new Enemy(EnemyNameId.Dacone, -7, false, false, false, false, false, false, 2, false, true),
            new Enemy(EnemyNameId.BoatJoeLeft, 0, false, false, false, true, false, false, 3),
            new Enemy(EnemyNameId.MetScuba, 0, false, false, false, false, true, false, 2),
            new Enemy(EnemyNameId.ScrewHead, 0, false, false, false, false, false, false, 3),
            new Enemy(EnemyNameId.BouncyGuy, -2, false, true, false, false, false, true, 2),
            new Enemy(EnemyNameId.Scooper, 4, false, false, false, false, false, true, 2),
            new Enemy(EnemyNameId.SpikeWheelRight, 4, false, false, false, false, false, false, 3),
            new Enemy(EnemyNameId.SpikeWheelFastLeft, 4, false, false, false, false, false, false, 3),
            new Enemy(EnemyNameId.SpikeWheelFastRight, 4, false, false, false, false, false, false, 3),
            new Enemy(EnemyNameId.SpikeWheelLeft, 4, false, false, false, false, false, false, 3),
            new Enemy(EnemyNameId.MetMother, 7, false, false, false, false, false, true, 3),
            new Enemy(EnemyNameId.WarningCone, 4, false, false, false, false, false, false, 2),
            new Enemy(EnemyNameId.TonDale, 0, false, true, false, false, false, true, 3),
            new Enemy(EnemyNameId.Taban, 1, false, false, true, false, false, false, 2), // Small sprite size, can coexist with rat, for example
            new Enemy(EnemyNameId.RockSloan, -4, false, false, false, false, false, true, 3),
            new Enemy(EnemyNameId.PukaPuka, 0, false, true, false, false, false, false, 2),
            new Enemy(EnemyNameId.Missile, 0, false, true, false, false, false, false, 3),
            new Enemy(EnemyNameId.Orbiter, 0, false, true, false, false, false, false, 3),
            new Enemy(EnemyNameId.MotherHen, -4, false, false, false, false, false, true, 3),
            new Enemy(EnemyNameId.Dolphin, -4, false, false, false, true, false, false, 3),
            new Enemy(EnemyNameId.PopUpCannon, 9, false, false, false, false, false, false, 3),
            new Enemy(EnemyNameId.GreenSpikeWheelFastLeft, 4, false, false, false, false, false, false, 2),
            new Enemy(EnemyNameId.GreenSpikeWheelFastRight, 4, false, false, false, false, false, false, 2),
            new Enemy(EnemyNameId.GreenSpikeWheelRight, 4, false, false, false, false, false, false, 2),
            new Enemy(EnemyNameId.GreenPukapuka, 0, false, true, false, false, false, false, 3),
            new Enemy(EnemyNameId.Camon, 0, false, false, false, false, false, false, 3),
            new Enemy(EnemyNameId.Lyric, 0, false, true, false, false, false, false, 2),
            new Enemy(EnemyNameId.GreenSpikeWheelOtherRight, 4, false, false, false, false, false, false, 2)
        };
    }
}
