// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System;
using System.Linq;
using BarbezDotEu.Generic;

namespace BarbezDotEu.Millennial
{
    /// <summary>
    /// Pretends it's 2004 and encodes a text like a millennial would on MSN Messenger in 2004.
    /// 'Obfuscate' (i.e. encode) a text into an alternative text containing random emojis and other 'strange' characters, just like a millennial would in e.g. 2004.
    /// </summary>
    public static class Millennializer
    {
        /// <summary>
        /// Obfuscates a text using emojis and whatnot.
        /// </summary>
        /// <param name="text">The text to obfuscate.</param>
        /// <returns>The obfuscated text.</returns>
        public static string Millennialize(this string text)
        {
            var result = string.Empty;
            foreach (var letter in text)
            {
                var obfuscatable = Dictionaries.ObfuscatedCharacters.Keys.FirstOrDefault(key => string.Equals(key, letter.ToString(), StringComparison.InvariantCultureIgnoreCase));
                if (string.IsNullOrWhiteSpace(obfuscatable))
                {
                    result += letter;
                }
                else
                {
                    var obfuscation = Dictionaries.ObfuscatedCharacters[obfuscatable].PickRandom();
                    result += obfuscation;
                }
            }

            return result;
        }
    }
}
