
namespace Megaman5Randomizer.Data.Enemies
{
    public class Enemy {
        public EnemyNameId EnemyNameId { get; set; }
        public byte Value { get; set; }
        public string Name { get; set; }
        public int YOffset { get; set; }
        public bool IsFlying { get; set; }
        public bool HasGravity { get; set; }
        public bool IsInverted { get; set; }
        public bool IsJetSkiOnly { get; set; }
        public bool IsBannedFromRandomization { get; set; }
        public bool IsUnderwaterOnly { get; set; }
        public bool IsHighRenderCost { get; set; }
        public bool IsBigBoy { get; set; }
        public bool CanReplaceFliers { get; set; }
        public int SpriteBank { get; set; }

        public int TauntFrames { get; set; }

        public int AnimationReference { get; set; }

        public Enemy(EnemyNameId enemyNameId, int yOffset, bool hasGravity, bool isFlyingOnly, bool isInverted, bool isJetSkiOnly, bool isUnderwaterOnly, bool isHighRenderCost, int spriteBank, bool canReplaceFliers = false, bool isBigBoy = false, bool isBannedFromRandomization = false, int tauntFrames = 0, int animationReference = 0) {
            EnemyNameId = enemyNameId;
            Value = (byte)enemyNameId;
            Name = enemyNameId.ToString();
            YOffset = yOffset;
            HasGravity = hasGravity;
            IsFlying = isFlyingOnly;
            IsInverted = isInverted;
            IsJetSkiOnly = isJetSkiOnly;
            IsUnderwaterOnly = isUnderwaterOnly;
            IsHighRenderCost = isHighRenderCost;
            IsBannedFromRandomization = isBannedFromRandomization;
            IsBigBoy = isBigBoy;
            SpriteBank = spriteBank;
            CanReplaceFliers = CanReplaceFliers;
            TauntFrames = tauntFrames;
            AnimationReference = animationReference;

        }
    }
}
