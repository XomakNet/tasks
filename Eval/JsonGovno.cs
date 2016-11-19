using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace EvalTask
{
    class JsonGovno
    {
        public static string Replace(string json, string expression)
        {
            if (string.IsNullOrWhiteSpace(json))
                return expression;

            var vars = JObject.Parse(json);

            var replaceDictionary = new Dictionary<string, double>();
            foreach (var v in vars)
                replaceDictionary.Add(v.Key, Convert.ToDouble(v.Value));
            
            return replaceDictionary.OrderByDescending(i => i.Key.Length)
                .Aggregate(expression, (current, value) => current.Replace(value.Key, value.Value.ToString()));
        }

        [TestFixture]
        public class JsonGovno_Should
        {
            [Test]
            public void SimplyWork()
            {
                string json = "{x:1,y:2}";
                string expr = "x+y";
                Assert.AreEqual("1+2",Replace(json, expr));
            }

            [Test]
            public void WorkOnSimilar()
            {
                string json = "{x:1,xx:2}";
                string expr = "x+xx";
                Assert.AreEqual("1+2", Replace(json, expr));
            }

            [Test]
            public void DoSomething_WhenSomething()
            {
                string json = "{x:1,xx:2.2,yy:3,y:5}";
                string expr = "x+xx+yy+y";
                Assert.AreEqual("1+2,2+3+5", Replace(json, expr));
            }
        }
    }
}