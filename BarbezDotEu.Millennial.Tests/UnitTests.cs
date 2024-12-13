// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarbezDotEu.Millennial.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void ObfuscationAndDeobfuscationWorks()
        {
            var text = "qwe rtzuiopa sdfgh jklyxcv bnmqwe rtzuiopa sdfgh jklyxcv bnm";
            var obfuscations = 10000;
            var iterations = 60;

            for (var i = 0; i < iterations; i++)
            {
                ConcurrentBag<string> collection = [];
                Parallel.For(default, obfuscations, i =>
                {
                    collection.Add(text.Millennialize());
                });

                Assert.AreEqual(collection.Count, obfuscations);
                Parallel.ForEach(collection, item =>
                {
                    var deobfuscated = item.Demillennialize();
                    var equal = string.Equals(text, deobfuscated, StringComparison.InvariantCultureIgnoreCase);
                    Assert.IsTrue(equal);
                });
            }
        }
    }
}
