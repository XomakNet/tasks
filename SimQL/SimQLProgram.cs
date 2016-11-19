using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SimQLTask
{
	class SimQLProgram
	{
		static void Main(string[] args)
		{
			var json = Console.In.ReadToEnd();
			foreach (var result in ExecuteQueries(json))
				Console.WriteLine(result);
		}

		public static IEnumerable<string> ExecuteQueries(string json)
		{
            var queries_results = new List<String>();

		    var jObject = JObject.Parse(json);
		    //var queries = jObject["queries"].ToObject<string[]>();
		    var queries = ((JArray) jObject["queries"]).Select(v => v.Value<String>());
		    var data = (JObject) jObject["data"];


		    foreach (var query_path in queries.Select(q => q.Split('.')))
		    {
		        var temp_result = data;
		        JValue value_result = null;
		        var tmp_str = "";
		        foreach (var query_param in query_path)
		        {
		            try
		            {
		                temp_result = (JObject) temp_result[query_param];
		            }
		            catch
		            {
                        value_result = (JValue)temp_result[query_param];
                    }
		        }

		        queries_results.Add(String.Join(".", query_path) + " = " + value_result);
		    }

            return queries_results;
		}
	}
}
