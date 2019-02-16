using System;
using System.Collections.Generic;
using System.Text;

namespace Megaman5Randomizer.Data
{
    public class Levels
    {
        public static List<Level> RobotMasterLevelData = new List<Level>() {
            new Level(2320, 0x0B90, 0x00, "Gravity Man Stage"),
            new Level(4320, 0x2B90, 0x01, "Wave Man Stage"),
            new Level(6320, 0x4B90, 0x02, "Stone Man Stage"),
            new Level(8320, 0x6B90, 0x03, "Gyro Man Stage"),
            new Level(10320, 0x8B90, 0x04, "Star Man Stage"),
            new Level(12320, 0xAB90, 0x05, "Charge Man Stage"),
            new Level(14320, 0xCB90, 0x06, "Napalm Man Stage"),
            new Level(16320, 0xEB90, 0x07, "Crystal Man Stage")
        };
    }
}
