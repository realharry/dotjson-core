using HoloJson.Core.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HoloJson.Core.UnitTests.Core
{
    [TestFixture]
    public class NumberTest
    {
        [TestCase]
        public void TestStringToNumber()
        {
            var number = new Number(30);
            System.Diagnostics.Debug.WriteLine("number = {0}", number);

            var s1 = "555";
            System.Diagnostics.Debug.WriteLine("s1 = {0}", s1);
            var n1 = s1.ToNumber();
            System.Diagnostics.Debug.WriteLine("n1 = {0}", n1);
            var v1 = n1.Value;
            Assert.IsTrue(v1 is int);

            var s2 = (Int32.MaxValue + 10L).ToString();
            System.Diagnostics.Debug.WriteLine("s2 = {0}", s2);
            var n2 = s2.ToNumber();
            System.Diagnostics.Debug.WriteLine("n2 = {0}", n2);
            var v2 = n2.Value;
            Assert.IsTrue(v2 is long);

            var s3 = "25.75";
            System.Diagnostics.Debug.WriteLine("s3 = {0}", s3);
            var n3 = s3.ToNumber();
            System.Diagnostics.Debug.WriteLine("n3 = {0}", n3);
            var v3 = n3.Value;
            Assert.IsTrue(v3 is decimal);

            var s4 = "100000000000000000000000000000000000000";
            System.Diagnostics.Debug.WriteLine("s4 = {0}", s4);
            var n4 = s4.ToNumber();
            System.Diagnostics.Debug.WriteLine("n4 = {0}", n4);
            var v4 = n4.Value;
            Assert.IsTrue(v4 is double);

        }


    }
}
