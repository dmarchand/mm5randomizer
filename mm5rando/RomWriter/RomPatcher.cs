using System;
using System.Collections.Generic;
using System.Text;
using RomWriter;
using System.IO;


namespace RomWriter
{
    /// <summary>
    /// A general purpose ROM Patcher
    /// Code borrowed from https://github.com/duckfist/MM2Random/blob/master/MM2RandoLib/Patcher/Patch.cs
    /// </summary>
    public class RomPatcher
    {
        Dictionary<int, RomWriteEntry> RomModifications { get; set; }
        string RomPath { get; set; }

        public RomPatcher(string romPath) {
            RomModifications = new Dictionary<int, RomWriteEntry>();
            RomPath = romPath;
        }

        public void AddRomModification(int address, byte value, string info ="") {
            RomWriteEntry entry = new RomWriteEntry(address, value, info);

            if(RomModifications.ContainsKey(address)) {
                RomModifications[address] = entry;
            } else {
                RomModifications.Add(address, entry);
            }
        }

        public byte GetByteAtAddress(int address) {
            using (var stream = new FileStream(RomPath, FileMode.Open, FileAccess.Read)) {
                stream.Position = address;
                return (byte)stream.ReadByte();
            }
        }

        public void ApplyRomPatch() {
            using (var stream = new FileStream(RomPath, FileMode.Open, FileAccess.ReadWrite)) {

                foreach (KeyValuePair<int, RomWriteEntry> kvp in RomModifications) {
                    stream.Position = kvp.Key;
                    stream.WriteByte(kvp.Value.Value);
                }
            }
        }

    }
}
