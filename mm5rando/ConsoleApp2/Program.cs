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
            Randomizer randomizer = new Randomizer();

            if(args.Length == 0) { 
                config.RandomizeEnemies = true;
                config.RandomizeWeaponRewards = true;
                config.RandomizeBeatReward = true;
                config.RandomizeVulnerability = true;
                
                System.IO.File.Copy("base.nes", "test.nes", true);
                randomizer.RandomizeRom(config, "test.nes");
            } else {
                string fileName = args[0];
                config.RandomizeWeaponRewards = Boolean.Parse(args[1]);
                config.RandomizeBeatReward = Boolean.Parse(args[2]);
                config.RandomizeVulnerability = Boolean.Parse(args[3]);
                randomizer.RandomizeRom(config, fileName);
            }
        }
    }
}