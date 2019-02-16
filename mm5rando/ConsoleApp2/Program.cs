using System;
using RomWriter;
using Megaman5Randomizer;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Config config = new Config();
            config.RandomizeEnemies = false;
            config.RandomizeWeaponRewards = true;
            config.RandomizeBeatReward = true;
            Randomizer randomizer = new Randomizer();
            randomizer.RandomizeRom(config, "test.nes");
        }
    }
}