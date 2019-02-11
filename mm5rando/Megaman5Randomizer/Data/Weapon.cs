using System;
using System.Collections.Generic;
using System.Text;

namespace Megaman5Randomizer.Data
{
    public class Weapon
    {
        public byte Value { get; set; }
        public string Name { get; set; }

        public Weapon(byte value, string name) {
            Value = value;
            Name = name;
        }
    }
}
