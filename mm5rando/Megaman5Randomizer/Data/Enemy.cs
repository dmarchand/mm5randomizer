using System;
using System.Collections.Generic;
using System.Text;

namespace Megaman5Randomizer.Data
{
    public class Enemy
    {
        public byte Value { get; set; }
        public string Name { get; set; }
        public int YOffset { get; set; }
        public bool IsFlyingOnly { get; set; }
        public bool HasGravity { get; set; }
        public bool IsInverted { get; set; }
        public bool IsJetSkiOnly { get; set; }
        public bool IsBannedFromRandomization { get; set; }
        public bool IsUnderwaterOnly { get; set; }
        public bool IsHighRenderCost { get; set; }

        public Enemy(byte value, string name, int yOffset, bool hasGravity, bool isFlyingOnly, bool isInverted, bool isJetSkiOnly, bool isUnderwaterOnly, bool isHighRenderCost, bool isBannedFromRandomization = false) {
            Value = value;
            Name = name;
            YOffset = yOffset;
            HasGravity = hasGravity;
            IsFlyingOnly = isFlyingOnly;
            IsInverted = isInverted;
            IsJetSkiOnly = isJetSkiOnly;
            IsUnderwaterOnly = isUnderwaterOnly;
            IsHighRenderCost = isHighRenderCost;
            IsBannedFromRandomization = isBannedFromRandomization;

        }
    }
}
