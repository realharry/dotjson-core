using HoloJson.Core.Builder;
using HoloJson.Core.Core;
using HoloJson.Core.Parser;
using HoloJson.Core.Util;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HoloJson.Core.UnitTests.Parser
{
    [TestFixture]
    public class JsonParserTest
    {
        [TestCase]
        public async Task TestParseStringAsync()
        {
            LiteJsonParser jsonParser = new HoloJsonMiniParser();

            // var jsonString = "{\"a\":[33, 55, 77]}";
            var jsonString = "[300, {\"a\":[33, false, true], \"b\":null}, \"ft\\/st/lt\\/gt\", null]";

            object node = null;
            try {
                //var task = jsonParser.ParseAsync(jsonString);
                //if (task.IsCompleted) {
                //    node = task.Result;
                //}
                node = await jsonParser.ParseAsync(jsonString);
                System.Diagnostics.Debug.WriteLine("node = " + node);
            } catch (HoloJsonMiniException ex) {
                System.Diagnostics.Debug.WriteLine("Exception = " + ex.Message);
            }


            // format the jsonStr
            LiteJsonBuilder jsonBuilder = new HoloJsonMiniBuilder();
            // string jsonStr = jsonBuilder.build(node);
            string jsonStr = null;
            try {
                //var task = jsonBuilder.BuildAsync(node);
                //// task.RunSynchronously();
                //jsonStr = task.Result;
                jsonStr = await jsonBuilder.BuildAsync(node);
            } catch (HoloJsonMiniException ex) {
                System.Diagnostics.Debug.WriteLine("Exception = " + ex.Message);
            }
            System.Diagnostics.Debug.WriteLine("--------------------------------------------------------");
            System.Diagnostics.Debug.WriteLine("jsonStr = " + jsonStr);

            int jsonLen = jsonStr.Length;
            System.Diagnostics.Debug.WriteLine("jsonLen = " + jsonLen);
        
        }

        //// In order to be able to run this test,
        //// you need to create a json file named, testjson1.json, under the app InstalledLocation.
        //// [TestCase]
        //public async Task TestParseFile()
        //{
        //    LiteJsonParser jsonParser = new HoloJsonMiniParser();

        //    var filePath = "testjson1.json";

        //    object jsonStruct = null;
        //    try {
        //        // ????
        //        var folder = Package.Current.InstalledLocation;
        //        System.Diagnostics.Debug.WriteLine("folder = {0}", folder.Path);

        //        IStorageFile jsonFile = await folder.GetFileAsync(filePath);
        //        // var asyncOp = folder.GetFileAsync(filePath);
        //        // IStorageFile jsonFile = asyncOp.GetResults();

        //        jsonStruct = await jsonParser.ParseAsync(jsonFile);
        //        System.Diagnostics.Debug.WriteLine("jsonStruct = " + CollectionUtil.ToDebugString<string, object>(jsonStruct));

        //    } catch (HoloJsonMiniException ex) {
        //        System.Diagnostics.Debug.WriteLine("Exception = " + ex.Message);

        //        //string context = ex.GetContext();
        //        //System.Diagnostics.Debug.WriteLine("context = " + context);
        //    }


        //    // format the jsonStr
        //    LiteJsonBuilder jsonBuilder = new HoloJsonMiniBuilder();
        //    // string jsonStr = jsonBuilder.build(node);
        //    string jsonStr = null;
        //    try {
        //        jsonStr = await jsonBuilder.BuildAsync(jsonStruct);
        //        // var task = jsonBuilder.BuildAsync(jsonStruct);
        //        // if (task.IsCompleted) {
        //        //     jsonStr = task.Result;
        //        // }
        //    } catch (HoloJsonMiniException ex) {
        //        System.Diagnostics.Debug.WriteLine("Exception = " + ex.Message);
        //    }
        //    System.Diagnostics.Debug.WriteLine("--------------------------------------------------------");
        //    System.Diagnostics.Debug.WriteLine("jsonStr = " + jsonStr);

        //    int jsonLen = jsonStr.Length;
        //    System.Diagnostics.Debug.WriteLine("jsonLen = " + jsonLen);

        //    Assert.AreEqual(34, jsonLen);
        //}



        //[TestCase]
        //public void TestParseReader()
        //{
        //    LiteJsonParser jsonParser = new HoloJsonMiniParser();

        //    // string filePath = @"C:\Users\Harry\Desktop\fastjson-bug.json";
        //    // string filePath = @"C:\Users\Harry\Desktop\random-json1.json";
        //    // string filePath = @"C:\Users\Harry\Desktop\random-json2.json";
        //    // string filePath = @"C:\Users\Harry\Desktop\random-json3.json";
        //    // string filePath = @"C:\Users\Harry\Desktop\sample.json";

        //    string filePath = @"C:\Users\Harry\Desktop\testjson.json";

        //    object node = null;
        //    try {
        //        // ????
        //        TextReader reader = new StreamReader(filePath);

        //        node = jsonParser.Parse(reader);
        //        // System.Diagnostics.Debug.WriteLine("node = " + node);

        //    } catch (HoloJsonMiniException ex) {
        //        System.Diagnostics.Debug.WriteLine("Exception = " + ex.Message);

        //        //string context = ex.GetContext();
        //        //System.Diagnostics.Debug.WriteLine("context = " + context);
        //    }


        //    // format the jsonStr
        //    LiteJsonBuilder jsonBuilder = new HoloJsonMiniBuilder();
        //    // string jsonStr = jsonBuilder.build(node);
        //    string jsonStr = null;
        //    try {
        //        var task = jsonBuilder.Build(node);
        //        // task.RunSynchronously();
        //        jsonStr = task.Result;
        //    } catch (HoloJsonMiniException ex) {
        //        System.Diagnostics.Debug.WriteLine("Exception = " + ex.Message);
        //    }
        //    System.Diagnostics.Debug.WriteLine("--------------------------------------------------------");
        //    System.Diagnostics.Debug.WriteLine("jsonStr = " + jsonStr);

        //    int jsonLen = jsonStr.Length;
        //    System.Diagnostics.Debug.WriteLine("jsonLen = " + jsonLen);

        //}

    }
}
