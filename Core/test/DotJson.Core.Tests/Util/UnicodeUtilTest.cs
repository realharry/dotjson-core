using DotJson.Core.Util;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DotJson.Core.UnitTests.Util
{
    [TestFixture]
    public class UnicodeUtilTest
    {
        [TestCase]
        public void TestGetUnicodeCharFromHexSequence()
        {
            char[] c1 = new char[]{'0','0','3','5'};
            char u1 = UnicodeUtil.GetUnicodeCharFromHexSequence(c1);
            System.Diagnostics.Debug.WriteLine("u1 = " + u1);
            Assert.AreEqual('5', u1);

            char[] c2 = new char[]{'0','0','5','d'};
            char u2 = UnicodeUtil.GetUnicodeCharFromHexSequence(c2);
            System.Diagnostics.Debug.WriteLine("u2 = " + u2);
            Assert.AreEqual(']', u2);

        }

        [TestCase]
        public void TestGetUnicodeCodeFromChar()
        {
            char[] c1 = UnicodeUtil.GetUnicodeHexCodeFromChar('0');
            System.Diagnostics.Debug.WriteLine("c1 = " + String.Join(",", c1));
            // Assert.AreEqual("\\u0030".toCharArray(), c1);

            char[] c2 = UnicodeUtil.GetUnicodeHexCodeFromChar('a');
            System.Diagnostics.Debug.WriteLine("c2 = " + String.Join(",", c2));
            // Assert.AreEqual("".toCharArray(), c2);
        
        }
 

    }
}
