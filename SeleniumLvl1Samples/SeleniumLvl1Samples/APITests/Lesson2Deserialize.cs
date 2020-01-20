using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace APITests
{
    [TestFixture]
    public class Lesson2Deserialize
    {

        [Test]
        public void Sample_1_DeserializeString()
        {
            var str = "{\"eBooks\":[{\"language\":\"Pascal\",\"edition\":\"third\"},{\"language\":\"Python\",\"edition\":\"four\"},{\"language\":\"SQL\",\"edition\":\"second\"}]}";

            var obj = JsonConvert.DeserializeObject(str);
        }






















        [Test]
        public void Sample_2_DeserializeString()
        {
            var str = "{\"eBooks\":[{\"language\":\"Pascal\",\"edition\":\"third\"},{\"language\":\"Python\",\"edition\":\"four\"},{\"language\":\"SQL\",\"edition\":\"second\"}]}";

            var obj = JsonConvert.DeserializeObject<ClassToDeserialize>(str);
        }


        [Test]
        public void Sample_3_DeserializeStringWithAdditional()
        {
            var str = "{\"eBooks\":[{\"language\":\"Pascal\",\"edition\":\"third\"},{\"language\":\"Python\",\"edition\":\"four\"},{\"language\":\"SQL\",\"edition\":\"second\"}],\"test\":\"testValue\"}";

            var obj = JsonConvert.DeserializeObject<ClassToDeserialize>(str);
        }

        public class ClassToDeserialize
        {
            public List<Ebooks> eBooks { get; set; }
        }

        public class Ebooks
        {
            public string language { get; set; }
            public string edition { get; set; }
        }

        //[Test]
        //public void Sample_4_DeserializeStudents()
        //{
        //    var str = "{\"students\":{\"Price\":{\"id\":\"01\",\"name\":\"Tom\"},\"Thameson\":{\"id\":\"02\",\"name\":\"Nick\"}}}";

        //    var obj = JsonConvert.DeserializeObject<studentsClass>(str);
        //}

        //[Test]
        //public void Sample_5_DeserializeStudentsBroken()
        //{
        //    var str = "";

        //    var obj = JsonConvert.DeserializeObject<studentsClass>(str);
        //}

        //public class studentsClass
        //{
        //    public Dictionary<string, Student> students { get; set; }
        //}

        //public class Student
        //{
        //    public string id { get; set; }
        //    public string name { get; set; }
        //}
    }
}