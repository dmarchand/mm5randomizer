using RomWriter;
using System;

namespace Megaman5Randomizer.RandomizationStrategy
{
    public interface IRandomizationStrategy
    {
        void Randomize(Random random, RomPatcher patcher);
    }
}