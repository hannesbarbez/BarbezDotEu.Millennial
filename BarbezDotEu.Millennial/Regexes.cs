// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System.Text.RegularExpressions;

namespace BarbezDotEu.Millennial
{
    /// <summary>
    /// Contains a collection of <see cref="Regex"/> objects.
    /// </summary>
    public static partial class Regexes
    {
        /// <summary>
        /// Gets a <see cref="Regex"/> for irrelevant characters.
        /// </summary>
        public static readonly Regex IrrelevantCharacters = new($"[^a-zA-Z|{string.Join('|', Dictionaries.AllObfuscationCharacters)}|{Constants.Separator}]", RegexOptions.Compiled);
    }
}
