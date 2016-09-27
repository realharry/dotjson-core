﻿using HoloJson.Core.Builder;
using HoloJson.Core.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HoloJson.Core.UnitTests.Builder
{
    [TestFixture]
    public class JsonBuilderTest
    {

        [TestCase]
        public void TestJsonBuild1()
        {
            LiteJsonBuilder jsonBuilder = new HoloJsonMiniBuilder();

            IDictionary<String,Object> map = new Dictionary<String,Object>();
            IList<Object> list1 = new List<Object>();
            list1.Add("x");
            list1.Add("y");
            list1.Add("z");
            map.Add("a", list1);
            map.Add("b", false);
            IDictionary<String,Object> map2 = new Dictionary<String,Object>();
            map2.Add("p", 100);
            map2.Add("q", null);
            map2.Add("r", 200);
            map.Add("c", map2);

            Object obj = map;
            // String jsonStr = jsonBuilder.Build(obj, 2);
            String jsonStr = null;
            try {
                var task = jsonBuilder.BuildAsync(obj);
                // ????
                // if (task.IsCompleted) {
                    jsonStr = task.Result;
                // }
            } catch (HoloJsonMiniException ex) {
                System.Diagnostics.Debug.WriteLine("Exception = " + ex.Message);
            }
            System.Diagnostics.Debug.WriteLine("[1] jsonStr = " + jsonStr);
        }

        [TestCase]
        public void TestJsonBuild2()
        {
            LiteJsonBuilder jsonBuilder = new HoloJsonMiniBuilder();

            List<Object> list = new List<Object>();
            list.Add("a");
        
            Object obj = list;
            String jsonStr = null;
            try {
                var task = jsonBuilder.BuildAsync(obj);
                // ????
                // if (task.IsCompleted) {
                jsonStr = task.Result;
                // }
            } catch (HoloJsonMiniException ex) {
                System.Diagnostics.Debug.WriteLine("Exception = " + ex.Message);
            }
            System.Diagnostics.Debug.WriteLine("[2] jsonStr = " + jsonStr);
        }

        [TestCase]
        public void TestJsonBuild3()
        {
            LiteJsonBuilder jsonBuilder = new HoloJsonMiniBuilder();

            Object objA = new char[] { 'X', 'Y', 'Z' };
            String jsonStrA = null;
            try {
                var task = jsonBuilder.BuildAsync(objA);
                // ????
                // if (task.IsCompleted) {
                    jsonStrA = task.Result;
                // }
            } catch (HoloJsonMiniException ex) {
                System.Diagnostics.Debug.WriteLine("Exception = " + ex.Message);
            }
            System.Diagnostics.Debug.WriteLine("[3A] jsonStrA = " + jsonStrA);

            Object objB = new byte[]{3,5,7};
            String jsonStrB = null;
            try {
                var task = jsonBuilder.BuildAsync(objB);
                // ????
                // if (task.IsCompleted) {
                    jsonStrB = task.Result;
                // }
            } catch (HoloJsonMiniException ex) {
                System.Diagnostics.Debug.WriteLine("Exception = " + ex.Message);
            }
            System.Diagnostics.Debug.WriteLine("[3B] jsonStrB = " + jsonStrB);

            Object objC = new int[] { 101, -55, 25 };
            String jsonStrC = null;
            try {
                var task = jsonBuilder.BuildAsync(objC);
                // ????
                // if (task.IsCompleted) {
                jsonStrC = task.Result;
                // }
            } catch (HoloJsonMiniException ex) {
                System.Diagnostics.Debug.WriteLine("Exception = " + ex.Message);
            }
            System.Diagnostics.Debug.WriteLine("[3C] jsonStrC = " + jsonStrC);

            Object objD = new string[] { "abc", "pqr", "xyz" };
            String jsonStrD = null;
            try {
                var task = jsonBuilder.BuildAsync(objD);
                // ????
                // if (task.IsCompleted) {
                jsonStrD = task.Result;
                // }
            } catch (HoloJsonMiniException ex) {
                System.Diagnostics.Debug.WriteLine("Exception = " + ex.Message);
            }
            System.Diagnostics.Debug.WriteLine("[3D] jsonStrD = " + jsonStrD);

            Object objE = new object[] { "abc", new object[] {5, new List<object>() { 33, "pp" }, new Dictionary<string, object>() {{"strArray", new object[] {'a', 'b'} }, {"date", new DateTime()} }} };
            String jsonStrE = null;
            try {
                var task = jsonBuilder.BuildAsync(objE);
                // ????
                // if (task.IsCompleted) {
                jsonStrE = task.Result;
                // }
            } catch (HoloJsonMiniException ex) {
                System.Diagnostics.Debug.WriteLine("Exception = " + ex.Message);
            }
            System.Diagnostics.Debug.WriteLine("[3E] jsonStrE = " + jsonStrE);
        }

        [TestCase]
        public void TestJsonBuild4()
        {
            LiteJsonBuilder jsonBuilder = new HoloJsonMiniBuilder();

            object obj = new {
                k1 = 123,
                k2 = "value"
            };

            String jsonStr = null;
            try {
                var task = jsonBuilder.BuildAsync(obj);
                // ????
                if (task.IsCompleted) {
                    jsonStr = task.Result;
                }
            } catch (HoloJsonMiniException ex) {
                System.Diagnostics.Debug.WriteLine("Exception = " + ex.Message);
            }
            System.Diagnostics.Debug.WriteLine("[4] jsonStr = " + jsonStr);
        }

    }
}
