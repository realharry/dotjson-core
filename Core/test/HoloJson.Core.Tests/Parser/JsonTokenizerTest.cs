using HoloJson.Core.Common;
using HoloJson.Core.Core;
using HoloJson.Core.Parser;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HoloJson.Core.UnitTests.Parser
{
    [TestFixture]
    public class JsonTokenizerTest
    {
        [TestCase]
        public void TestTokenizerNext()
        {
            // String jsonStr = "{\"a\":[3, 5, 777]}";
            String jsonStr = "[31, {\"a\":[3, false, true], \"b\":null}, \"ft\", null]";
            LiteJsonTokenizer jsonTokenizer = new HoloJsonMiniTokenizer(jsonStr);

            JsonToken token = JsonToken.INVALID;
            try {
                while(jsonTokenizer.HasMore()) {
                    token = jsonTokenizer.Next();
                    System.Diagnostics.Debug.WriteLine("token = " + token);
                }
            } catch (HoloJsonMiniException ex) {
                System.Diagnostics.Debug.WriteLine("Exception = " + ex.Message);
            }
        }

        [TestCase]
        public void TestTokenizerPeek()
        {
            // String jsonStr = "{\"a\":[3, 5, 7]}";
            String jsonStr = "[31, {\"a\":[3, false, true], \"b\":null}, \"ft\", null]";
            LiteJsonTokenizer jsonTokenizer = new HoloJsonMiniTokenizer(jsonStr);

            JsonToken token1 = JsonToken.INVALID;
            JsonToken token2 = JsonToken.INVALID;
            try {
                while(jsonTokenizer.HasMore()) {
                    token1 = jsonTokenizer.Peek();
                    token2 = jsonTokenizer.Next();
                    System.Diagnostics.Debug.WriteLine("token1 = " + token1);
                    System.Diagnostics.Debug.WriteLine("token2 = " + token2);
                    Assert.AreEqual(token1, token2);
                }
            } catch (HoloJsonMiniException ex) {
                System.Diagnostics.Debug.WriteLine("Exception = " + ex.Message);
            }
        }

    
    }
}
