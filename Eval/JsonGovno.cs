﻿using System;
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

            var replaceDictionary = new Dictionary<string, double>();
            foreach (var v in vars)
                replaceDictionary.Add(v.Key, Convert.ToDouble(v.Value));
            
            return replaceDictionary.OrderBy(i => i.Key.Length)
                .Aggregate(expression, (current, value) => current.Replace(value.Key, value.Value.ToString()));
        }
    }
}