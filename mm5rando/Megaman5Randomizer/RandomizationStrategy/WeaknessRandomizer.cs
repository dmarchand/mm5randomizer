using System;
using System.Collections.Generic;
using System.Text;
using RomWriter;
using Megaman5Randomizer.Data;
using System.Linq;
using Megaman5Randomizer.Data.Objects;

namespace Megaman5Randomizer.RandomizationStrategy
{
    class WeaknessRandomizer : IRandomizationStrategy
    {
        public void Randomize(Random random, RomPatcher patcher, Config config) {
            List<GameObject> bosses = new List<GameObject>(BossObjects.ObjectData);
            if(config.ChaosMode) {
                DoChaosBossRandomization(bosses, random, patcher);
            } else {
                DoRegularBossRandomization(bosses, random, patcher);
            }
        }

        void DoRegularBossRandomization(List<GameObject> bosses, Random random, RomPatcher patcher) {
            List<VulnerabilityTable> usableWeapons = new List<VulnerabilityTable>(VulnerabilityTables.EnemyData);
            usableWeapons.RemoveAll(vulnerability => vulnerability.Name == "Rush Coil" || vulnerability.Name == "Rush Jet"); // On regular mode, lets be nice

            // Pick unique weaknesses for each robot master
            List<GameObject> mastersWithoutWeakness = new List<GameObject>(RobotMasterObjects.ObjectData);
            List<GameObject> otherBosses = new List<GameObject>(RobotMasterObjects.ObjectData);
            usableWeapons.ForEach(weapon => {
                // First pick someone to be weak
                GameObject weakMaster = null;
                if (mastersWithoutWeakness.Count > 0) {
                    weakMaster = mastersWithoutWeakness[random.Next(mastersWithoutWeakness.Count)];
                    int bossOffset = weapon.VulnerabilityTableOffset + weakMaster.ObjectId;
                    patcher.AddRomModification(bossOffset, 0x04, "Vuln for: " + weakMaster.Name + " for weapon type: " + weapon.Name); // Weak bosses take 4 damage
                    Console.Out.WriteLine("Robot Master: " + weakMaster.Name + " now weak to: " + weapon.Name);
                    mastersWithoutWeakness.Remove(weakMaster);
                }
        
                otherBosses.ForEach(boss => {
                    if (weakMaster == null || boss.Name != weakMaster.Name) {
                        int offset = weapon.VulnerabilityTableOffset + boss.ObjectId;
                        patcher.AddRomModification(offset, (byte)random.Next(0, 2), "Vuln for: " + boss.Name + " for weapon type: " + weapon.Name); // Strong bosses take 0 or 1 damage
                        Console.Out.WriteLine("Robot Master: " + boss.Name + " now strong to: " + weapon.Name);
                    }
                });
            });

            // Randomize Wily Boss Weaknesses
            usableWeapons.ForEach(weapon => {
                WilyBosses.ObjectData.ForEach(wilyBoss => {
                    int bossOffset = weapon.VulnerabilityTableOffset + wilyBoss.ObjectId;
                    int randomRoll = random.Next(0, 3);
                    byte vulnAmount = 0x00;

                    if(randomRoll == 1) {
                        vulnAmount = 0x01;
                    } else if (randomRoll == 2) {
                        vulnAmount = 0x04;
                    }

                    patcher.AddRomModification(bossOffset, vulnAmount, "Vuln for: " + wilyBoss.Name + " for weapon type: " + wilyBoss.Name);
                    Console.Out.WriteLine("Wily Boss: " + wilyBoss.Name + " now modified to: " + vulnAmount + " for weapon type: " + weapon.Name);
                });
            });
        }

        /// <summary>
        /// Literally just makes every boss take random damage from weapons, including rush coil and rush jet. Good luck!
        /// </summary>
        /// <param name="bosses"></param>
        /// <param name="random"></param>
        /// <param name="patcher"></param>
        void DoChaosBossRandomization(List<GameObject> bosses, Random random, RomPatcher patcher) {
            bosses.ForEach(boss => {
                VulnerabilityTables.EnemyData.ForEach(vulnerability => {
                    int bossOffset = vulnerability.VulnerabilityTableOffset + boss.ObjectId; // Locate the entry in the vulnerability table
                    int vulnerabilityAmount = random.Next(0, 5); // 0 = no damage, 4 = big weakness
                    patcher.AddRomModification(bossOffset, (byte)vulnerabilityAmount, "Vuln for: " + boss.Name + " for weapon type: " + vulnerability.Name);
                });
            });
        }
    }
}
