using System;
using RomWriter;
using Megaman5Randomizer;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Randomizer randomizer = new Randomizer();
            randomizer.RandomizeRom("test.nes");
        }
    }
}