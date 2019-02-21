using System;
using System.Collections.Generic;
using System.Text;

namespace Megaman5Randomizer.Data.Enemies
{
    public class Enemies
    {
        public static List<Enemy> EnemyData = new List<Enemy>() {
            new Enemy(0x00, "Pukka Pucker", 4, false, false, false, false, false, false, false),
            new Enemy(0x01, "Spike Slammer", 0, false, false, false, false, false, false),
            new Enemy(0x02, "Skull Dropper", 0, false, true, false, false, false, false),
            new Enemy(0x03, "Met Astronaut", 0, false, true, false, false, false, true),
            new Enemy(0x04, "Tiger", 0, false, false, false, false, false, false),
            new Enemy(0x05, "Rat", 7, false, false, false, false, false, false),
            new Enemy(0x06, "Shield Attacker", -4, false, false, false, false, false, false),
            new Enemy(0x07, "Bomb Dropper", 0, false, true, false, false, false, false),
            new Enemy(0x08, "Metturret", -4, false, false, false, false, false, true),
            new Enemy(0x09, "Mettrain", 0, true, false, false, false, false, true),
            new Enemy(0x0B, "Buoy", 0, false, false, false, true, false, false),
            new Enemy(0x0C, "Power Muscler", -0x0F, false, false, false, false, false, true, true),
            new Enemy(0x0D, "Chopper Joe", 0, false, true, false, false, false, true),
            new Enemy(0x0E, "Iron Kuange (inv)", -7, false, false, true, false, false, true),
            new Enemy(0x0F, "Iron Kuange", 8, false, false, false, false, false, true),
            new Enemy(0x12, "Graviton", 0, false, true, false, false, false, false),
            new Enemy(0x14, "Vertical Pakkan", -5, false, false, false, false, false, false),
            new Enemy(0x15, "Duster (Fugene)", 0, true, false, false, false, false, true),
            new Enemy(0x16, "Bomber Sloan", -4, false, false, false, false, false, true),
            new Enemy(0x17, "Boat Joe (Right)", -2, false, false, false, true, false, false),
            new Enemy(0x18, "Crystal Joe", -2, false, false, false, false, false, true),
            new Enemy(0x19, "Susie G", 0, false, false, false, false, false, false),
            new Enemy(0x1A, "Susie G (inv)", 0, false, false, true, false, false, false),
            new Enemy(0x1B, "Yudon", -4, false, false, false, false, false, false, true),
            new Enemy(0x1F, "Dacone", -8, false, false, false, false, false, false, true),
            new Enemy(0x28, "Boat Joe (left)", 0, false, false, false, true, false, false),
            new Enemy(0x29, "Met Scuba", 0, false, false, false, false, true, false),
            new Enemy(0x2A, "Screwhead", 0, false, false, false, false, false, false),
            new Enemy(0x2B, "Bouncy Guy", -2, false, true, false, false, false, true),
            new Enemy(0x2C, "Scooper", 4, false, false, false, false, false, true),
            new Enemy(0x2D, "Spike Wheel (Right)", 4, false, false, false, false, false, false),
            new Enemy(0x2E, "Spike Wheel Fast (Left)", 4, false, false, false, false, false, false),
            new Enemy(0x2F, "Spike Wheel Fast (Right)", 4, false, false, false, false, false, false),
            new Enemy(0x30, "Spike Wheel (Left)", 4, false, false, false, false, false, false),
            new Enemy(0x31, "Met Mother", 7, false, false, false, false, false, true),
            new Enemy(0x32, "Warning Cone", 4, false, false, false, false, false, false),
            new Enemy(0x33, "Ton Dale", 0, false, true, false, false, false, true),
            new Enemy(0x34, "Hanging Bat", -7, false, false, true, false, false, false),
            new Enemy(0x35, "Rock Sloan", -4, false, false, false, false, false, true),
            new Enemy(0x36, "Puka Puka", 0, false, false, false, false, false, false),
            new Enemy(0x37, "Missile", 0, false, true, false, false, false, false),
            new Enemy(0x38, "Orbiter", 0, false, true, false, false, false, false),
            new Enemy(0x39, "Mother Hen", -4, false, false, false, false, false, true),
            new Enemy(0x3A, "Dolphin", -4, false, false, false, true, false, false),
            new Enemy(0x3B, "Pop-up Cannon", 9, false, false, false, false, false, false),
            new Enemy(0x3C, "Green Spike Wheel Fast (Left)", 4, false, false, false, false, false, false),
            new Enemy(0x3D, "Green Spike Wheel (Right)", 4, false, false, false, false, false, false),
            new Enemy(0x3E, "Green Spike Wheel Fast (Left)", 4, false, false, false, false, false, false),
            new Enemy(0x3F, "Green Pukapuka", 0, false, true, false, false, false, false),
            new Enemy(0x60, "Carmen", 0, false, false, false, false, false, false),
            new Enemy(0x61, "Lyric", 0, false, true, false, false, false, false),
            new Enemy(0x7F, "Green Spike Wheel (Right)", 4, false, false, false, false, false, false)
        };
    }
}
