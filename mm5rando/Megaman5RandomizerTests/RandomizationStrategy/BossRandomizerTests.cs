using Microsoft.VisualStudio.TestTools.UnitTesting;
using Megaman5Randomizer.RandomizationStrategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Megaman5Randomizer.RandomizationStrategy.Tests {
    [TestClass()]
    public class BossRandomizerTests {
        [TestMethod()]
        public void UsesAll8BossSlots() {
            BossRandomizer bossRandomizer = new BossRandomizer();
            bossRandomizer.Randomize(new Random(), new RomWriter.RomPatcher("foo"), new Config());

        }
    }
}