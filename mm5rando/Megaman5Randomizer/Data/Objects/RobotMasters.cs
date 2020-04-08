using System;
using System.Collections.Generic;
using System.Text;

namespace Megaman5Randomizer.Data.Objects
{
    public class RobotMasterObjects
    {
        public static List<GameObject> ObjectData = new List<GameObject>() {
            new GameObject(0x69, "StoneMan"),
            new GameObject(0x6B, "ChargeMan"),
            new GameObject(0x6E, "GyroMan"),
            new GameObject(0x81, "GravityMan"),
            new GameObject(0x83, "CrystalMan"),
            new GameObject(0x86, "WaveMan"),
            new GameObject(0x89, "NapalmMan"),
            new GameObject(0x8D, "StarMan")
        };
    }
}
