using Megaman5Randomizer.RandomizationStrategy;
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

        IList<IRandomizationStrategy> randomizers;
        public void RandomizeRom(string path) {
            randomizers = new List<IRandomizationStrategy>();
        }
    }
}
