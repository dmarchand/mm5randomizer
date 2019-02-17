using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Megaman5Randomizer.Data
{
    class TextMapper
    {
        #region CharMap
        // NOTE: 5C 2B 2E = newline, 5C 2B 4B = bigger newline
        static Dictionary<char, byte> textMapping = new Dictionary<char, byte>() {
            { ' ', 0x20 },
            { '0', 0x30 },
            { '1', 0x31 },
            { '2', 0x32 },
            { '3', 0x33 },
            { '4', 0x34 },
            { '5', 0x35 },
            { '6', 0x36 },
            { '7', 0x37 },
            { '8', 0x38 },
            { '9', 0x39 },
            { 'A', 0x41 },
            { 'B', 0x42 },
            { 'C', 0x43 },
            { 'D', 0x44 },
            { 'E', 0x45 },
            { 'F', 0x46 },
            { 'G', 0x47 },
            { 'H', 0x48 },
            { 'I', 0x49 },
            { 'J', 0x4A },
            { 'K', 0x4B },
            { 'L', 0x4C },
            { 'M', 0x4D },
            { 'N', 0x4E },
            { 'O', 0x4F },
            { 'P', 0x50 },
            { 'Q', 0x51 },
            { 'R', 0x52 },
            { 'S', 0x53 },
            { 'T', 0x54 },
            { 'U', 0x55 },
            { 'V', 0x56 },
            { 'W', 0x57 },
            { 'X', 0x58 },
            { 'Y', 0x59 },
            { 'Z', 0x60 },
            { '.', 0x2E },
            { ',', 0x27 },
            { '\"', 0x28 },
            { '!', 0x21 },
            { '?', 0x2A },
            { '&', 0x2B },
            { '(', 0x2C },
            { ')', 0x2D },
            { '\'', 0x2E },
            { '-', 0x2F },
            { '+', 0x5C },
            { ';', 0x2B },
            { ':', 0x2E },
            { '[', 0x4B }
        };
        #endregion

        public static int CharToHexValue(char charToReplace) {
            return textMapping[charToReplace];
        }

        public static char HexValueToChar(int hexValue) {
            return textMapping.FirstOrDefault(key => key.Value == hexValue).Key;
        }

        public static List<byte> StringToHexValues(string stringToConvert) {
            List<byte> result = new List<byte>();
            stringToConvert.ToList().ForEach(x => result.Add(textMapping[x]));
            return result;
        }
    }
}
