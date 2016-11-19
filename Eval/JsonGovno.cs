using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EvalTask
{
    class JsonGovno
    {
        public static string Replace(string json, string expression)
        {
            var vars = JObject.Parse(json);

            foreach (var v in vars)
            {
                var r = new Regex(v.Key+"{1}");
            }
            return "";
        }
    }
}
