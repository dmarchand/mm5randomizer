using System;
using System.Collections.Generic;
using System.Text;

namespace Megaman5Randomizer.Data.Objects
{
    public class RobotMasterObjects
    {
        public static List<GameObject> ObjectData = new List<GameObject>() {
            new GameObject(0x69, "Stone Man"),
            new GameObject(0x6B, "Charge Man"),
            new GameObject(0x6E, "Gyro Man"),
            new GameObject(0x81, "Gravity Man"),
            new GameObject(0x83, "Crystal Man"),
            new GameObject(0x86, "Wave Man"),
            new GameObject(0x89, "Napalm Man"),
            new GameObject(0x8D, "Star Man")
        };
    }
}
