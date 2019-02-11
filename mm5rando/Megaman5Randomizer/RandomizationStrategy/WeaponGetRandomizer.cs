using Megaman5Randomizer.Data;
using Megaman5Randomizer;
using System;
using System.Collections.Generic;
using System.Text;
using RomWriter;

namespace Megaman5Randomizer.RandomizationStrategy
{
    public class WeaponGetRandomizer : IRandomizationStrategy
    {
        private List<Weapon> remainingWeapons = WeaponGet.WeaponData;

        public void Randomize(Random random, RomPatcher patcher) {
            Levels.LevelData.ForEach(level => {
                ReplaceWeaponsRandomly(level, random, patcher);    
            });
        }

        void ReplaceWeaponsRandomly(Level level, Random random, RomPatcher patcher) {
                byte value = patcher.GetByteAtAddress(level.WeaponGetIndex);
                Weapon weapon = remainingWeapons[random.Next(remainingWeapons.Count)];

                patcher.AddRomModification(level.WeaponGetIndex, 0x01, weapon.Name);
                patcher.AddRomModification(level.WeaponGetIndex + 0x01, 0x0B, "test");
                Console.Out.WriteLine("Wrote New Weapon: " + weapon.Name + " at addr: " + level.WeaponGetIndex);                            
        }
    }
}
