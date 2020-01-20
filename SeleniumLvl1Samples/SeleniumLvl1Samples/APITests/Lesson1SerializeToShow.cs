using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Threading;

namespace APITests
{
    [TestFixture]
    public class Lesson1SerializeToShow
    {

        [Test]
        public void Sample_1_SerializeObject()
        {
            var payload = new TestClassApiToSerialize()
            {
                A = "asdf",
                Bint = 1,
                ListOfStrings = new List<string>() { "asdfg", "wqewqw" }
            };

            var objectSerialized = JsonConvert.SerializeObject(payload);

        }

        [Test]
        public void Sample_2_SerializeObjectNamed()
        {
            var dict = new Dictionary<string, InnerClassToSerialize>();
            dict.Add("1key", new InnerClassToSerialize() { A = "asd", Bint = 1 });
            dict.Add("2key", new InnerClassToSerialize() { A = "bsd", Bint = 2 });

            var payload = new TestClassApiToSerializeDictionaryToShow()
            {
                A = "asdf",
                Bint = 1,
                DictOfStrings = dict
            };

            var objectSerialized = JsonConvert.SerializeObject(payload);

        }
    }

    public class TestClassApiToSerializeToShow
    {
        public string A { get; set; }
        public int Bint { get; set; }

        public List<string> ListOfStrings { get; set; }
    }

    public class TestClassApiToSerializeDictionaryToShow
    {
        public string A { get; set; }
        public int Bint { get; set; }

        public Dictionary<string,InnerClassToSerialize> DictOfStrings { get; set; }
    }

    public class InnerClassToSerialize
    {
        public string A { get; set; }
        public int Bint { get; set; }
    }
}