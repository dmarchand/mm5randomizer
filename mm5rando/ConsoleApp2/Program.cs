using System;
using RomWriter;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            RomPatcher patcher = new RomPatcher();
            patcher.AddRomModification(2960, 0x3A); // Should be first gravity man enemy
            patcher.ApplyRomPatch("test.nes");
        }
    }
}