using HoloJson.Core.Util;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HoloJson.Core.UnitTests.Util
{
    [TestFixture]
    public class GenericUtilTest
    {
        [TestCase]
        public void TestIsList()
        {
            IList<int> list = new List<int>();
            var nonList = new DateTime();

            var isList1 = GenericUtil.IsList(list);
            System.Diagnostics.Debug.WriteLine("isList1 = {0}", isList1);
            Assert.AreEqual(true, isList1);

            var isList2 = GenericUtil.IsList(nonList);
            System.Diagnostics.Debug.WriteLine("isList2 = {0}", isList2);
            Assert.AreEqual(false, isList2);

        }

        [TestCase]
        public void TestIsDictionary()
        {
            IDictionary<string, char> dict = new Dictionary<string, char>();
            ISet<string> nonDict = new HashSet<string>();

            var isDict1 = GenericUtil.IsDictionary(dict);
            System.Diagnostics.Debug.WriteLine("isDict1 = {0}", isDict1);
            Assert.AreEqual(true, isDict1);

            var isDict2 = GenericUtil.IsDictionary(nonDict);
            System.Diagnostics.Debug.WriteLine("isDict2 = {0}", isDict2);
            Assert.AreEqual(false, isDict2);

        }

    }
}
