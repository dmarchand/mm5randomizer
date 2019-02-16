using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Megaman5Randomizer.Data
{
    class TextMapper
    {
        #region CharMap
        static Dictionary<char, int> textMapping = new Dictionary<char, int>() {
            { ' ', 0x01 },
            { '0', 0x02 },
            { '1', 0x03 },
            { '2', 0x04 },
            { '3', 0x05 },
            { '4', 0x06 },
            { '5', 0x07 },
            { '6', 0x08 },
            { '7', 0x09 },
            { '8', 0x0A },
            { '9', 0x0B },
            { 'A', 0x0C },
            { 'B', 0x0D },
            { 'C', 0x0E },
            { 'D', 0x0F },
            { 'E', 0x10 },
            { 'F', 0x11 },
            { 'G', 0x12 },
            { 'H', 0x13 },
            { 'I', 0x14 },
            { 'J', 0x15 },
            { 'K', 0x16 },
            { 'L', 0x17 },
            { 'M', 0x18 },
            { 'N', 0x19 },
            { 'O', 0x1A },
            { 'P', 0x1B },
            { 'Q', 0x1C },
            { 'R', 0x1D },
            { 'S', 0x1E },
            { 'T', 0x1F },
            { 'U', 0x20 },
            { 'V', 0x21 },
            { 'W', 0x22 },
            { 'X', 0x23 },
            { 'Y', 0x24 },
            { 'Z', 0x25 },
            { '.', 0x26 },
            { ',', 0x27 },
            { '\"', 0x28 },
            { '!', 0x29 },
            { '?', 0x2A },
            { '&', 0x2B },
            { '(', 0x2C },
            { ')', 0x2D },
            { '\'', 0x2E },
            { '-', 0x2F },
            { '\\', 0x2C },
            { '+', 0x5B }
        };
        #endregion

        public static int CharToHexValue(char charToReplace) {
            return textMapping[charToReplace];
        }

        public static char HexValueToChar(int hexValue) {
            return textMapping.FirstOrDefault(key => key.Value == hexValue).Key;
        }

        public static List<int> StringToHexValues(string stringToConvert) {
            List<int> result = new List<int>();
            stringToConvert.ToList().ForEach(x => result.Add(x));
            return result;
        }
    }
}
