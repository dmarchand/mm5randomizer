using Megaman5Randomizer.Data;
using Megaman5Randomizer;
using System;
using System.Collections.Generic;
using System.Text;
using RomWriter;
using System.Linq;
using Megaman5Randomizer.Data.Levels;

namespace Megaman5Randomizer.RandomizationStrategy
{
    public class WeaponGetRandomizer : IRandomizationStrategy
    {
        private const int ROCKMANV_WEAPON_REWARD_ADDRESS = 0x03af29; // This determines what weapon is awarded when letters are collected
        private const int ROCKMANV_MENU_DISPLAY_LETTERS_ADDRESS = 0x02499;
        private const int WEAPON_GET_MAP_BASE = 0x02EF0C; // The location of the weapon get offset map
        private const int WEAPON_GET_OFFSET_BASE = 0x02EF14; // The location that each weapon get offset adds to
        private const string WEAPON_GET_SINGLE_FORMAT = "YOU GOT {0}.";
        private const string WEAPON_GET_DOUBLE_FORMAT = "YOU GOT {0}+;:AND+;[ {1}.";

        private List<Weapon> remainingWeapons = new List<Weapon>(WeaponGet.WeaponData);
        private Dictionary<Level, List<Weapon>> weaponRewards = new Dictionary<Level, List<Weapon>>();
        private Weapon letterRewardWeapon;

        public void Randomize(Random random, RomPatcher patcher, Config config) {
            ReplaceWeaponsRandomly(random, patcher);    
        }

        void ReplaceWeaponsRandomly(Random random, RomPatcher patcher) {
            // First select the ROCKMANV weapon
            letterRewardWeapon = remainingWeapons[random.Next(remainingWeapons.Count)];
            remainingWeapons.Remove(letterRewardWeapon);

            // Select weapons for each stage
            List<Level> remainingRegularStages = new List<Level>(Levels.LevelData.Where(level => !level.Name.Contains("Wily") && !level.Name.Contains("Protoman")));
            List<Weapon> eightWeaponsToSprinkle = remainingWeapons.OrderBy(x => random.Next()).Take(8).ToList();
            eightWeaponsToSprinkle.ForEach(weapon => {
                Level stageToInsert = remainingRegularStages[random.Next(remainingRegularStages.Count)];
                weaponRewards.Add(stageToInsert, new List<Weapon>() { weapon });
                remainingWeapons.Remove(weapon);
                remainingRegularStages.Remove(stageToInsert);
            });

            // Pick two stages for a bonus weapon
            remainingRegularStages = new List<Level>(Levels.LevelData.Where(level => !level.Name.Contains("Wily") && !level.Name.Contains("Protoman")));
            remainingWeapons.ForEach(weapon => {
                Level stageToInsert = remainingRegularStages[random.Next(remainingRegularStages.Count)];
                weaponRewards[stageToInsert].Add(weapon);
                remainingRegularStages.Remove(stageToInsert);
            });
            remainingWeapons.Clear();

            foreach(var kvp in weaponRewards) {
                string weapons = "";
                kvp.Value.ForEach(weapon => weapons += ", " + weapon.Name);
                Console.WriteLine("Stage: " + kvp.Key.Name + " got weapons: " + weapons);
            }

            WriteRockmanVRewardWeapon(letterRewardWeapon, patcher);
            WriteBossRewards(patcher);
        }

        void WriteRockmanVRewardWeapon(Weapon weapon, RomPatcher patcher) {
            // Patch the actual reward
            byte valueToWrite = InMemoryWeapon.WeaponData.Where(inMemWeapon => inMemWeapon.Name == weapon.Name).First().Value;
            patcher.AddRomModification(ROCKMANV_WEAPON_REWARD_ADDRESS, valueToWrite, weapon.Name);
            patcher.AddRomModification(ROCKMANV_MENU_DISPLAY_LETTERS_ADDRESS, valueToWrite, weapon.Name);
            Console.Out.WriteLine("Wrote weapon to ROCKMANV reward: " + weapon.Name);
        }

        void WriteBossRewards(RomPatcher patcher) {
            int totalOffset = 0; // Need to keep track of how far we've gone
            weaponRewards.Keys.OrderBy(x => x.WeaponGetIndex);

            foreach (var kvp in weaponRewards) {
                Level level = kvp.Key;
                List<Weapon> rewards = kvp.Value;

                // Write the offset map for this level
                int offsetToWriteTo = WEAPON_GET_MAP_BASE + level.WeaponGetIndex;
                patcher.AddRomModification(offsetToWriteTo, (byte)totalOffset, "Offset write for: " + level.Name);

                string weaponGetString = String.Empty;

                if(rewards.Count == 1) {
                    Weapon reward = rewards[0];
                    weaponGetString = string.Format(WEAPON_GET_SINGLE_FORMAT, reward.Name.ToUpper());
                } else {
                    weaponGetString = string.Format(WEAPON_GET_DOUBLE_FORMAT, rewards[0].Name.ToUpper(), rewards[1].Name.ToUpper());
                }

                List<byte> byteEncodedWeaponGetString = TextMapper.StringToHexValues(weaponGetString);
                int currentLocation = WEAPON_GET_OFFSET_BASE + totalOffset;

                // First write the "WEAPON GET" text
                byteEncodedWeaponGetString.ForEach(letter => {
                    patcher.AddRomModification(currentLocation, letter, "Weapon get: " + letter);
                    currentLocation++;
                    totalOffset++;
                });

                // Now write the weapons themselves
                patcher.AddRomModification(currentLocation, rewards[0].Value, "Weapon get weapon: " + rewards[0].Value);
                patcher.AddRomModification(currentLocation + 1, rewards.Count == 1 ? (byte)0x00 : rewards[1].Value, "Bonus weapon");
                totalOffset += 2;
            }
            Console.Write("Foo");
        }
    }
}
