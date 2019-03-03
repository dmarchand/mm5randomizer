# mm5randomizer
## A full randomizer for Mega Man 5

# Implemented Features
* Random boss weapon rewards (including Rush Jet and S. Arrow)
* Random Beat reward (Beat itself enters the random boss reward pool as well)
* Enemy Randomization

# Confirmed 100% Playable Stages
* Stone Man
* Gravity Man
* Napalm Man
* Charge Man

# Notes for later:
This section currently documents my wonderful and exciting adventures through the Megaman V ROM.

## Weapon Unlock Status
Weapon unlock status is stored in RAM between $00B1 and $00BC. A weapon's energy ranges from 0x80 to 0x9C, each increment representing 1 bar of energy. A value below 0x80 will result in the weapon not being unlocked and not displayed on the menu screen. The instant a weapon has a value of 0x80, the menu will consider it unlocked and display it. There's no view/model separation in the world of NES, so the menu itself is essentially controlling whether or not the player can equip a weapon!

## Weapon Acquisition:
Starting at 0x2EF0C, each byte contains a value that serves as an offset from 0x2EF14, pointing to the weapon acquisition block. The bytes are in stage order (0 is Gravity Man, for example). Once you calculate the offset, you'll land on the "WEAPON GET" message string. After the string ends, there are two bytes. These are the awarded weapons from the stage. Should be able to safely write until 0x02EFE7, I think.

## ROCKMANV/MEGAMANV Letters
In RAM, the ROCKMANV letter status is stored in a byte at $006D. Each bit represents a letter, in reverse (thanks endian-ness). For example, 10111111 would mean you have ROCKMA_V unlocked. Loading the menu will display the letter status.

## Awarding a Weapon That Isn't Beat When ROCKMANV is Collected
When Megaman picks up a letter, a routine is called at $AF08. This routine checks the value at $006D in RAM, and compares it to 0xFF (1111111). If true, the value at 0x03AF29 in the ROM is read, and that value in memory is set to 0x9C. As per the Weapon Unlock Status section above, this will cause whatever weapon is at that location in the ROM to be unlocked! For example, setting the value to 0xBB will unlock Rush Jet, since Rush Jet's weapon energy is stored at this location.

However, there's still a problem. If you do this, the menu will still say "ROCKMANV", but show all 8 letters unlocked. This also means that if you unlock Beat later via other means, the menu will look pretty ugly, since you'll have Beat's graphic overlayed on top of ROCKMANV. We can fix this too, though!

At $8488, there's a routine that controls the ROCKMANV display in the menu. The very first thing done is `LDA $00BC`. This loads the value of Beat's weapon energy into the accumulator. It then checks to see if the value is greater than 0x80. If not, the rest of the routine is skipped. This is the key to erasing the ROCKMANV segment. If we change the instruction to `LDA $00XX`, where XX is once again the location of the weapon's energy, the ROCKMANV segment will disappear. Unfortunately, since we're in a world without modern software engineering principles, we're not done. This routine has some strange side effects, and we need to fix them up too. If you stop here, you'll notice that, while ROCKMANV disappears, you'll unlock Beat anyways, but the weapon will have zero energy.

At $84CC, we'll find a `STA $00BC` call. This takes the current value and stuffs it into whatever is at $00BC. That's beat's energy, and we don't want to mess with that. Two lines above this, we can see the value get loaded via `LDA $00BC` again, and a bitwise OR occurs on it with 0x80. This will cause Beat to have 0 energy, but still be unlocked, oops! If we modify these calls, we can fix this. Set the values at 0x0024D4 and 0x0024D0 to the memory address of the weapon we want to unlock, instead. Beat will still render on the menu unfortunately, but now the weapon cannot be selected, so we're making progress! At this point, if you unlock Beat normally, everything will be ok.

There is a workaround here. At $8488, we can return to `LDA $00BC` instead of `LDA $00XX`. This will result in ROCKMANV rendering fully gold when our new weapon is unlocked, but disappearing entirely once Beat himself is earned! It's not perfect, but I think it's the most workable solution without re-writing the menu code. One caveat: If you unlock Beat prior to collecting all the letters, they'll still disappear. Unfortunately, like the issue above, we can't really fix this without re-coding the menu and potentially adding an additional menu slot.

# Vulnerability Offets
Gravityman offset: 81
Napalmman offset: 89
Stoneman offset: 69
