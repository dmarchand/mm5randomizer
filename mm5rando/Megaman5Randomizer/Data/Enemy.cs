using System;
using System.Collections.Generic;
using System.Text;

namespace Megaman5Randomizer.Data
{
    public class Enemy
    {
        public byte Value { get; set; }
        public string Name { get; set; }

        public Enemy(byte value, string name) {
            Value = value;
            Name = name;
        }
    }
}
