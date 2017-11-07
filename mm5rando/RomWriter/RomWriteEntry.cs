using System;
using System.Collections.Generic;
using System.Text;

namespace RomWriter
{
    public class RomWriteEntry
    {
        public int Address { get; set; }
        public byte Value { get; set; }
        public string Info { get; set; }

        public RomWriteEntry(int address, byte value, string info = "") {
            Address = address;
            Value = value;
            Info = info;
        }
    }
}
