using DotJson.Core.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Reference, if you are new to Windows app unit testing on Visual Studio:
// https://msdn.microsoft.com/en-us/library/windows/apps/jj159318.aspx

namespace DotJson.Core.UnitTests.Core
{
    [TestFixture]
    public class CharQueueTest
    {
        [TestCase]
        public void TestCharQueue()
        {
            var charQueue = new CharQueue(4);

            var suc = false;
            char character;

            suc = charQueue.Add('a');
            Assert.AreEqual(true, suc);
            suc = charQueue.Add('b');
            Assert.AreEqual(true, suc);
            suc = charQueue.Add('c');
            Assert.AreEqual(true, suc);
            suc = charQueue.Add('d');
            Assert.AreEqual(false, suc);

            character = charQueue.Peek();
            Assert.AreEqual('a', character);

            suc = charQueue.Add('e');
            Assert.AreEqual(false, suc);

            character = charQueue.Poll();
            Assert.AreEqual('a', character);

            suc = charQueue.Add('f');
            Assert.AreEqual(true, suc);

            character = charQueue.Peek();
            Assert.AreEqual('b', character);

            System.Diagnostics.Debug.WriteLine("charQueue = {0}", charQueue);
            
        }

    
        [TestCase]
        public void TestCharQueueAdd()
        {
            var charQueue = new CharQueue(10);

            int size1 = charQueue.Size;
            System.Diagnostics.Debug.WriteLine("size1 = " + size1);

            charQueue.Add('a');
            System.Diagnostics.Debug.WriteLine("charQueue = " + charQueue);

            int size2 = charQueue.Size;
            System.Diagnostics.Debug.WriteLine("size2 = " + size2);
            Assert.AreEqual(size1 + 1, size2);

            System.Diagnostics.Debug.WriteLine("charQueue = {0}", charQueue);
        }

        [TestCase]
        public void TestCharQueuePoll()
        {
            var charQueue = new CharQueue(10);

            int size1 = charQueue.Size;
            System.Diagnostics.Debug.WriteLine("size1 = " + size1);

            charQueue.Add('a');
            charQueue.Add('b');
            charQueue.Add('c');
            System.Diagnostics.Debug.WriteLine("charQueue = " + charQueue);

            char c = charQueue.Poll();
            System.Diagnostics.Debug.WriteLine("charQueue = " + charQueue);
            System.Diagnostics.Debug.WriteLine("c = " + c);
            Assert.AreEqual('a', c);

            int size2 = charQueue.Size;
            System.Diagnostics.Debug.WriteLine("size2 = " + size2);
            Assert.AreEqual(size1 + 2, size2);

            System.Diagnostics.Debug.WriteLine("charQueue = {0}", charQueue);
        }

        [TestCase]
        public void TestCharQueuePeek()
        {
            var charQueue = new CharQueue(10);

            int size1 = charQueue.Size;
            System.Diagnostics.Debug.WriteLine("size1 = " + size1);

            charQueue.Add('a');
            charQueue.Add('b');
            charQueue.Add('c');
            System.Diagnostics.Debug.WriteLine("charQueue = " + charQueue);

            char c = charQueue.Peek();
            System.Diagnostics.Debug.WriteLine("charQueue = " + charQueue);
            System.Diagnostics.Debug.WriteLine("c = " + c);
            Assert.AreEqual('a', c);

            int size2 = charQueue.Size;
            System.Diagnostics.Debug.WriteLine("size2 = " + size2);
            Assert.AreEqual(size1 + 3, size2);

            System.Diagnostics.Debug.WriteLine("charQueue = {0}", charQueue);
        }

        [TestCase]
        public void TestCharQueueAddAll()
        {
            var charQueue = new CharQueue(10);

            int size1 = charQueue.Size;
            System.Diagnostics.Debug.WriteLine("size1 = " + size1);

            char[] buff1 = new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h'};
            charQueue.AddAll(buff1);
            System.Diagnostics.Debug.WriteLine("charQueue = " + charQueue);

            int size2 = charQueue.Size;
            System.Diagnostics.Debug.WriteLine("size2 = " + size2);
            Assert.AreEqual(size1 + 8, size2);

            char c1 = charQueue.Poll();
            System.Diagnostics.Debug.WriteLine("charQueue = " + charQueue);
            System.Diagnostics.Debug.WriteLine("c1 = " + c1);
            Assert.AreEqual('a', c1);
            char c2 = charQueue.Poll();
            System.Diagnostics.Debug.WriteLine("charQueue = " + charQueue);
            System.Diagnostics.Debug.WriteLine("c2 = " + c2);
            Assert.AreEqual('b', c2);
            char c3 = charQueue.Poll();
            System.Diagnostics.Debug.WriteLine("charQueue = " + charQueue);
            System.Diagnostics.Debug.WriteLine("c3 = " + c3);
            Assert.AreEqual('c', c3);
            char[] cc = charQueue.Poll(3);
            System.Diagnostics.Debug.WriteLine("charQueue = " + charQueue);
            System.Diagnostics.Debug.WriteLine("cc = " + String.Join(",", cc));
            Assert.AreEqual('d', cc[0]);
            Assert.AreEqual('e', cc[1]);
            Assert.AreEqual('f', cc[2]);
            char c4 = charQueue.Peek();
            System.Diagnostics.Debug.WriteLine("charQueue = " + charQueue);
            System.Diagnostics.Debug.WriteLine("c4 = " + c4);
            Assert.AreEqual('g', c4);

            int size3 = charQueue.Size;
            System.Diagnostics.Debug.WriteLine("size3 = " + size3);
            Assert.AreEqual(size2 - 6, size3);

            char[] buff2 = new char[] {'i', 'j', 'k', 'l'};
            charQueue.AddAll(buff2);
            System.Diagnostics.Debug.WriteLine("charQueue = " + charQueue);

            int size4 = charQueue.Size;
            System.Diagnostics.Debug.WriteLine("size4 = " + size4);
            Assert.AreEqual(size3 + 4, size4);

            charQueue.Add('m');
            charQueue.Add('n');
            charQueue.Add('o');
            System.Diagnostics.Debug.WriteLine("charQueue = " + charQueue);

            bool suc = charQueue.Add('p');
            System.Diagnostics.Debug.WriteLine("charQueue = " + charQueue);
            Assert.AreEqual(false, suc);
        
            char c7 = charQueue.Poll();
            System.Diagnostics.Debug.WriteLine("charQueue = " + charQueue);
            Assert.AreEqual('g', c7);
            char c8 = charQueue.Poll();
            System.Diagnostics.Debug.WriteLine("charQueue = " + charQueue);
            Assert.AreEqual('h', c8);
            char c9 = charQueue.Poll();
            System.Diagnostics.Debug.WriteLine("charQueue = " + charQueue);
            Assert.AreEqual('i', c9);
            char c10 = charQueue.Poll();
            System.Diagnostics.Debug.WriteLine("charQueue = " + charQueue);
            Assert.AreEqual('j', c10);
            char c11 = charQueue.Peek();
            System.Diagnostics.Debug.WriteLine("charQueue = " + charQueue);
            Assert.AreEqual('k', c11);
            char c12 = charQueue.Poll();
            System.Diagnostics.Debug.WriteLine("charQueue = " + charQueue);
            Assert.AreEqual('k', c12);

            charQueue.Add('p');
            System.Diagnostics.Debug.WriteLine("charQueue = " + charQueue);

            charQueue.Clear();
            System.Diagnostics.Debug.WriteLine("charQueue = " + charQueue);
            int size9 = charQueue.Size;
            System.Diagnostics.Debug.WriteLine("size9 = " + size9);
            Assert.AreEqual(0, size9);

            System.Diagnostics.Debug.WriteLine("charQueue = {0}", charQueue);
        }
    
    
    }
}
