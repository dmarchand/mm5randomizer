using System;
using System.Collections.Generic;
using System.Text;

namespace Megaman5Randomizer.Data.Levels
{
    public class Levels
    {
        public static List<Level> LevelData = new List<Level>() {
            new Level(2320, 0x0B90, 0x00, 0x143E8, Enemies.EnemyNameId.GravityMan, "Gravity Man Stage"),
            new Level(4320, 0x2B90, 0x01, 0x143E9, Enemies.EnemyNameId.WaveMan, "Wave Man Stage"),
            new Level(6320, 0x4B90, 0x02, 0x143EA, Enemies.EnemyNameId.StoneMan, "Stone Man Stage"),
            new Level(8320, 0x6B90, 0x03, 0x143EB, Enemies.EnemyNameId.GyroMan, "Gyro Man Stage"),
            new Level(10320, 0x8B90, 0x04, 0x143EC, Enemies.EnemyNameId.StarMan, "Star Man Stage"),
            new Level(12320, 0xAB90, 0x05, 0x143ED, Enemies.EnemyNameId.ChargeMan, "Charge Man Stage"),
            new Level(14320, 0xCB90, 0x06, 0x143EE, Enemies.EnemyNameId.NapalmMan, "Napalm Man Stage"),
            new Level(16320, 0xEB90, 0x07, 0x143EF, Enemies.EnemyNameId.CrystalMan, "Crystal Man Stage"),
            new Level(18320, 0x10B90, 0x07, 0x00, Enemies.EnemyNameId.DarkMan, "Protoman 1"),
            new Level(20320, 0x12B90, 0x07, 0x00, Enemies.EnemyNameId.DarkMan2, "Protoman 2"),
            new Level(22320, 0x14B90, 0x07, 0x00, Enemies.EnemyNameId.DarkMan3, "Protoman 3"),
            new Level(24320, 0x16B90, 0x07, 0x00, Enemies.EnemyNameId.DarkMan4, "Protoman 4"),
            new Level(24320, 0x18B90, 0x07, 0x00, Enemies.EnemyNameId.DarkMan4, "Wily Castle 1"),
            new Level(24320, 0x1AB90, 0x07, 0x00, Enemies.EnemyNameId.DarkMan4, "Wily Castle 2"),
            new Level(24320, 0x1CB90, 0x07, 0x00, Enemies.EnemyNameId.DarkMan4, "Wily Castle 3"),
            new Level(24320, 0x1EB90, 0x07, 0x00, Enemies.EnemyNameId.WilyMachine, "Wily Castle 4")
        };
    }
}
