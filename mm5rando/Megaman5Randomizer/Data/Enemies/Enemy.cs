
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
        public int SpriteBank { get; set; }

        public Enemy(EnemyNameId enemyNameId, int yOffset, bool hasGravity, bool isFlyingOnly, bool isInverted, bool isJetSkiOnly, bool isUnderwaterOnly, bool isHighRenderCost, int spriteBank, bool isBigBoy = false, bool isBannedFromRandomization = false) {
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

        }
    }
}
