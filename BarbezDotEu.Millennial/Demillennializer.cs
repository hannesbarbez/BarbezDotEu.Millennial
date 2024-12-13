// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System;
using BarbezDotEu.String;

namespace BarbezDotEu.Millennial
{
    /// <summary>
    /// Deobfuscates a text by removing all Unicode lookalikes of letters in the English alphabet.
    /// </summary>
    public static class Demillennializer
    {
        /// <inheritdoc/>
        /// <summary>
        /// Deobfuscates a text by removing all Unicode lookalikes of letters in the English alphabet. Does not keep numbers.
        /// </summary>
        /// <param name="obfuscatedText">The obfuscated text.</param>
        /// <returns>The deobfuscated text.</returns>
        public static string Demillennialize(this string obfuscatedText)
        {
            var delimited = String.Regexes.UnicodeWhiteSpaces.Replace(obfuscatedText, Constants.Separator);
            var relevant = Regexes.IrrelevantCharacters.Replace(delimited, string.Empty);
            var essential = relevant.Replace(Constants.Separator, StringConstants.Space);
            var basic = String.Regexes.ConsecutiveWhiteSpaces.Replace(essential, StringConstants.Space);
            var deobfuscated = basic;

            // Using foreach b/c regex didn't play nice with certain Unicode characters (new Regex($"[{string.Join('|', obfuscation.Value)}]", RegexOptions.IgnoreCase);).
            foreach (var obfuscation in Dictionaries.ObfuscatedCharacters)
            {
                foreach (var character in obfuscation.Value)
                {
                    deobfuscated = deobfuscated.Replace(character, obfuscation.Key, StringComparison.OrdinalIgnoreCase);
                }
            }

            var withoutSingleCharacters = String.Regexes.SingleCharacters.Replace(deobfuscated, string.Empty);
            return withoutSingleCharacters;
        }
    }
}
