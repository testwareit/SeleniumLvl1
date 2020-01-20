using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace APITests
{
    [TestFixture]
    public class Lesson1Serialize
    {

        [Test]
        public void Sample_1_SerializeObject()
        {
        }
    }

    public class TestClassApiToSerialize
    {
        public string A { get; set; }
        public int Bint { get; set; }

        public List<string> ListOfStrings { get; set; }
    }
}