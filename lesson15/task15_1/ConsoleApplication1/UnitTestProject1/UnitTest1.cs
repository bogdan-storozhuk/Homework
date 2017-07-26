using System;
using System.Collections.Generic;
using NUnit.Framework;
using  ConsoleApplication1;
using NUnit.Framework.Internal;


namespace UnitTestProject1
{
    [TestFixture]
    public class UnitTest1
    {
        private MyLinkedList<int> myLinkedList;

        [SetUp]
        public void SetUpVoid()
        {
            myLinkedList = new MyLinkedList<int>();
            myLinkedList.Add(1);
            myLinkedList.Add(2);
            myLinkedList.Add(3);
        }

        [Test]
        public void TestCountOfGetArrayElements()
        {
            var array = myLinkedList.ToArray();
            int length = array.Length;
            Assert.AreEqual(3, length);
        }

        [Test]
        public void TestGetArray()
        {
            var array = myLinkedList.ToArray();
            
            Assert.AreEqual(typeof(int[]), array.GetType());
        }

        
        [TestCase(6)]
        [TestCase(5)]
        [TestCase(4)]
        public void TestAddOneElement(int value)
        {
            int count = myLinkedList.GetLength();
            Assert.AreEqual(true, myLinkedList.Add(value));
            Assert.AreEqual(++count, myLinkedList.GetLength());
        }

    }
}
