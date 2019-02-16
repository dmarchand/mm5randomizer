using Megaman5Randomizer.Data;
using Megaman5Randomizer;
using System;
using System.Collections.Generic;
using System.Text;
using RomWriter;
using System.Linq;

namespace Megaman5Randomizer.RandomizationStrategy
{
    public class WeaponGetRandomizer : IRandomizationStrategy
    {
        private const int ROCKMANV_WEAPON_REWARD_ADDRESS = 0x03af29;
        private List<Weapon> remainingWeapons = WeaponGet.WeaponData;
        private Dictionary<Level, Weapon> standardWeaponRewards = new Dictionary<Level, Weapon>();
        private Dictionary<Level, Weapon> bonusWeaponRewards = new Dictionary<Level, Weapon>();
        private Weapon letterRewardWeapon;

        public void Randomize(Random random, RomPatcher patcher) {
            ReplaceWeaponsRandomly(random, patcher);    
        }

        void ReplaceWeaponsRandomly(Random random, RomPatcher patcher) {
            // First select the ROCKMANV weapon
            letterRewardWeapon = remainingWeapons[random.Next(remainingWeapons.Count)];
            remainingWeapons.Remove(letterRewardWeapon);

            // Select weapons for each stage
            List<Level> remainingRegularStages = new List<Level>(Levels.RobotMasterLevelData);
            List<Weapon> eightWeaponsToSprinkle = remainingWeapons.OrderBy(x => random.Next()).Take(8).ToList();
            eightWeaponsToSprinkle.ForEach(weapon => {
                Level stageToInsert = remainingRegularStages[random.Next(remainingRegularStages.Count)];
                standardWeaponRewards.Add(stageToInsert, weapon);
                remainingWeapons.Remove(weapon);
                remainingRegularStages.Remove(stageToInsert);
            });

            // Pick two stages for a bonus weapon
            remainingRegularStages = new List<Level>(Levels.RobotMasterLevelData);
            remainingWeapons.ForEach(weapon => {
                Level stageToInsert = remainingRegularStages[random.Next(remainingRegularStages.Count)];
                bonusWeaponRewards.Add(stageToInsert, weapon);
                remainingWeapons.Remove(weapon);
                remainingRegularStages.Remove(stageToInsert);
            });

            WriteRockmanVRewardWeapon(letterRewardWeapon, patcher);
                // byte value = patcher.GetByteAtAddress(level.WeaponGetIndex);
                // Weapon weapon = remainingWeapons[random.Next(remainingWeapons.Count)];

                // patcher.AddRomModification(level.WeaponGetIndex, 0x01, weapon.Name);
                // patcher.AddRomModification(level.WeaponGetIndex + 0x01, 0x0B, "test");
                // Console.Out.WriteLine("Wrote New Weapon: " + weapon.Name + " at addr: " + level.WeaponGetIndex);                            
        }

        void WriteRockmanVRewardWeapon(Weapon weapon, RomPatcher patcher) {
            // Patch the actual reward
            byte valueToWrite = InMemoryWeapon.WeaponData.Where(inMemWeapon => inMemWeapon.Name == weapon.Name).First().Value;
            patcher.AddRomModification(ROCKMANV_WEAPON_REWARD_ADDRESS, valueToWrite, weapon.Name);
            Console.Out.WriteLine("Wrote weapon to ROCKMANV reward: " + weapon.Name);
        }
    }
}
