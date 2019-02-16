using System.Collections.Generic;

namespace Megaman5Randomizer.Data
{
    public class InMemoryWeapon
    {
        public static List<Weapon> WeaponData = new List<Weapon>() {
            new Weapon(0xB1, "Water Wave"),
            new Weapon(0xB2, "Gyro Attack"),
            new Weapon(0xB3, "Crystal Eye"),
            new Weapon(0xB4, "Napalm Bomb"),
            new Weapon(0xB5, "Super Arrow"),
            new Weapon(0xB6, "Power Stone"),
            new Weapon(0xB7, "Gravity Hold"),
            new Weapon(0xB8, "Charge Kick"),
            new Weapon(0xB9, "Star Crash"),
            new Weapon(0xBA, "Rush Coil"),
            new Weapon(0xBB, "Rush Jet"),
            new Weapon(0xBC, "Beat")
        };
    }
}
