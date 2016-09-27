using HoloJson.Core.Builder;
using HoloJson.Core.Core;
using HoloJson.Core.Util;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HoloJson.Core.UnitTests.Builder
{
    [TestFixture]
    public class JsonStructureBuilderTest
    {
        [TestCase]
        public void TestToJsonStructure1()
        {
            LiteJsonStructureBuilder jsonStructureBuilder = new HoloJsonMiniStructureBuilder();

            IDictionary<String,Object> map = new Dictionary<String,Object>();
            IList<Object> list1 = new List<Object>();
            list1.Add("x");
            list1.Add("y\ny\ty\ry\\y ___ \\/ / ___ </ ___ y/y\"\u0033\u0035y\u001ay");
            list1.Add("z");
            list1.Add(null);
            map.Add("a", list1);
            //TestJsonCompatibleObject jb1 = new TestJsonCompatibleObject();
            //map.Add("a2", jb1);
            //TestJsonCompatibleArray jb2 = new TestJsonCompatibleArray();
            //map.Add("a3", jb2);
            map.Add("b", false);
            IDictionary<String,Object> map2 = new Dictionary<String,Object>();
            map2.Add("p", 100);
            map2.Add("q", null);
            map2.Add("r", 200);
            map2.Add("s", Byte.MaxValue);
            map2.Add("t", new Byte[]{});
            map2.Add("u", new Byte[]{Byte.MinValue});

            map.Add("b2", null);
            map.Add("c", map2);
            map.Add("c2", map2);

            //TestBean bean1 = new TestBean(3, "aaaa");
            //bean1.setAttrF(new char[]{'h','i'});
            //IDictionary<String,Object> mapC1 = new Dictionary<String,Object>();
            //mapC1.Add("ii", 33);
            //TestBean beanC1 = new TestBean(4, "bbbb");
            //TestBean beanC2 = new TestBean(5, "cccc");
            //mapC1.Add("ii22", new Object[]{1,2,3, beanC2});
            //TestBean beanD3 = new TestBean(6, "dddd");
            //IList<Object> listD3 = new List<Object> {1,2,3, beanD3};
            //beanC2.setAttrD(listD3);
            //beanC1.setAttrE(beanC2);
            //beanC1.setAttrF(new char[]{'k','q','p'});
            //mapC1.Add("jj", beanC1);
            //bean1.setAttrC(mapC1);
            //map.Add("d", bean1);
            //map.Add("z", new Object[]{ bean1 , beanC1} );
        
            Object obj = map;
            Object jsonObj = null;
            try {
                var task = jsonStructureBuilder.BuildJsonStructureAsync(obj, -1);
                // var task = jsonStructureBuilder.BuildJsonStructureAsync(obj);
                jsonObj = task.Result;
            } catch (HoloJsonMiniException ex) {
                System.Diagnostics.Debug.WriteLine("Exception = " + ex.Message);
            }
    //        if(jsonObj instanceof String) {
    //            System.Diagnostics.Debug.WriteLine("jsonObj is String.");            
    //        } else {
    //            System.Diagnostics.Debug.WriteLine("jsonObj is not a String."); 
    //        }

            //string objStr = null;
            //if (jsonObj != null) {
            //    var dictObj = jsonObj as IDictionary<string, object>;
            //    if (dictObj != null) {
            //        objStr = dictObj.ToDebugString();
            //    } else {
            //        var listObj = jsonObj as IList<object>;
            //        if (listObj != null) {
            //            objStr = listObj.ToDebugString<string, object>();
            //        } else {
            //            objStr = jsonObj.ToString();
            //        }
            //    }
            //}
            //System.Diagnostics.Debug.WriteLine("jsonObj = " + objStr);

            System.Diagnostics.Debug.WriteLine("jsonObj = " + jsonObj.ToDebugString<string, object>());


            // For tracing
            LiteJsonBuilder jsonBuilder = new HoloJsonMiniBuilder();

            String jsonStr = null;
            try {
                var task = jsonBuilder.BuildAsync(jsonObj);
                // task.RunSynchronously();   // ????
                jsonStr = task.Result;
            } catch (HoloJsonMiniException ex) {
                System.Diagnostics.Debug.WriteLine("Exception = " + ex.Message);
            }
            System.Diagnostics.Debug.WriteLine("[3] jsonStr = " + jsonStr);


        }


        [TestCase]
        public void TestToJsonStructure2()
        {
            LiteJsonStructureBuilder jsonStructureBuilder = new HoloJsonMiniStructureBuilder();

            object obj = new TestBean(33, "Maybe");

            Object jsonObj = null;
            try {
                var task = jsonStructureBuilder.BuildJsonStructureAsync(obj, -1);
                // var task = jsonStructureBuilder.BuildJsonStructureAsync(obj);
                // ????
                if (task.IsCompleted) {
                    jsonObj = task.Result;
                }
            } catch (HoloJsonMiniException ex) {
                System.Diagnostics.Debug.WriteLine("Exception = " + ex.Message);
            }
            System.Diagnostics.Debug.WriteLine("jsonObj = " + jsonObj.ToDebugString<string, object>());

        }

    }

    internal class TestBean
    {
        private int counter;
        private string title;
        private IList<long> timestamps;
        private IDictionary<string, char> characterMap;
        private object miscObject;

        public TestBean(int counter, string title)
        {
            this.counter = counter;
            this.title = title;

            timestamps = new List<long>() { 1L, 11L, 111L };
            characterMap = new Dictionary<string, char>() {
                {"aa", 'A'},
                {"bb", 'B'}
            };

            miscObject = new {
                k1 = 123,
                k2 = "value",
                k3 = new {
                    m1 = 77,
                    m2 = "the rest"
                }
            };
        }

        public int Conter
        {
            get
            {
                return counter;
            }
            set
            {
                counter = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public IList<long> Timestamps
        {
            get
            {
                return timestamps;
            }
            set
            {
                timestamps = value;
            }
        }
        public IDictionary<string, char> CharacterMap
        {
            get
            {
                return characterMap;
            }
            set
            {
                characterMap = value;
            }
        }
        public object MiscObject
        {
            get
            {
                return miscObject;
            }
            set
            {
                miscObject = value;
            }
        }

    }
}
