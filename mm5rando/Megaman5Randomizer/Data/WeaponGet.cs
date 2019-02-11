using System;
using System.Collections.Generic;
using System.Text;

namespace Megaman5Randomizer.Data
{
    public class WeaponGet
    {
        public static List<Weapon> WeaponData = new List<Weapon>() {
            new Weapon(0x01, "Water Wave"),
            new Weapon(0x02, "Gyro Attack"),
            new Weapon(0x03, "Crystal Eye"),
            new Weapon(0x04, "Napalm Bomb"),
            new Weapon(0x05, "Super Arrow"),
            new Weapon(0x06, "Power Stone"),
            new Weapon(0x07, "Gravity Hold"),
            new Weapon(0x08, "Charge Kick"),
            new Weapon(0x09, "Star Crash"),
            new Weapon(0x0A, "Rush Coil"),
            new Weapon(0x0B, "Rush Jet"),
            new Weapon(0x0C, "Beat")
        };
    }
}
