# mm5randomizer


# Notes for later:
## Weapon Acquisition:
Starting at 0x2EF0C, each byte contains a value that serves as an offset from 0x2EF14, pointing to the weapon acquisition block. The bytes are in stage order (0 is Gravity Man, for example). Once you calculate the offset, you'll land on the "WEAPON GET" message string. After the string ends, there are two bytes. These are the awarded weapons from the stage. Should be able to safely write until 0x02EFE7, I think.