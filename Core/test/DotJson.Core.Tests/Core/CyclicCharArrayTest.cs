using DotJson.Core.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DotJson.Core.UnitTests.Core
{
    [TestFixture]
    public class CyclicCharArrayTest
    {
        [TestCase]
        public void TestCyclicCharArray()
        {
            var backing = new char[] { 'a', 'b', 'c', 'd', 'e', 'f' };
            var cyclicCharArray = new CyclicCharArray(backing);

            Assert.AreEqual(backing.Length, cyclicCharArray.ArrayLength);

            cyclicCharArray.Offset = 1;
            cyclicCharArray.Length = 3;

            for (int i = cyclicCharArray.Start; i < cyclicCharArray.End; i++) {
                char ch = cyclicCharArray.GetCharInArray(i);
                System.Diagnostics.Debug.WriteLine("i = {0}, ch = {1}", i, ch);
            }

            System.Diagnostics.Debug.WriteLine("cyclicCharArray = {0}", cyclicCharArray);

            char ch1 = cyclicCharArray.GetCharInArray(cyclicCharArray.Start + 1);
            Assert.AreEqual('c', ch1);

            cyclicCharArray.Offset = 4;
            cyclicCharArray.Length = 4;
            System.Diagnostics.Debug.WriteLine("cyclicCharArray = {0}", cyclicCharArray);

            char ch2 = cyclicCharArray.GetCharInArray(cyclicCharArray.Start + 2);
            Assert.AreEqual('a', ch2);

        }

    }
}
