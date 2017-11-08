using Megaman5Randomizer.RandomizationStrategy;
using RomWriter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Megaman5Randomizer
{
    public class Randomizer
    {
        public int Seed {
            get; set;
        }

        public Random RNG {
            get; set;
        }

        List<IRandomizationStrategy> randomizers;
        public void RandomizeRom(string path) {
            InitRNG();

            RomPatcher patcher = new RomPatcher(path);
            randomizers = new List<IRandomizationStrategy>();
            randomizers.Add(new NormalEnemyRandomizer());

            RunRandomizers(patcher);

            patcher.ApplyRomPatch();
        }

        void InitRNG() {
            if(Seed <= 0) {
                Seed = Guid.NewGuid().GetHashCode();
            }

            RNG = new Random(Seed);
        }

        void RunRandomizers(RomPatcher patcher) {
            randomizers.ForEach(randomizer => {
                randomizer.Randomize(RNG, patcher);
            });
        }
    }
}
