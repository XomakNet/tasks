using NUnit.Framework;

namespace JsonConversion
{
    [TestFixture]
    public class JsonProgramShould
    {
        [Test]
        public void MakeSingleQuotes_ifQuoted()
        {
            var result = JsonProgram.MakeSingleQuotes(new string[] {"test", "test4"}, "\"test\": \"test2\", \"test4\": \"test5\"");
            Assert.AreEqual("'test': 'test2', 'test4': 'test5'", result);
        }

        [Test]
        public void MakeSingleQuotes_ifNotQuoted()
        {
            var result = JsonProgram.MakeSingleQuotes(new string[] { "test", "test4" }, "\"test\": 1, \"test4\": 2");
            Assert.AreEqual("'test': 1, 'test4': 2", result);
        }

        [Test]
        public void MakeSingleQuotes_notTouch()
        {
            var result = JsonProgram.MakeSingleQuotes(new string[] { "test" }, "\"test\": 1, \"test4\": 2");
            Assert.AreEqual("'test': 1, \"test4\": 2", result);
        }

    }
}