using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.String;

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
		    var queries = ((JArray) jObject["queries"]).Select(v => v.Value<String>());
		    var data = (JObject) jObject["data"];


		    foreach (var queryParams in queries.Select(q => q.Split('.')))
		    {
		        var tempResult = data;
		        JValue valueResult = null;
		        
		        foreach (var queryParam in queryParams)
		        {
		            try
		            {
		                tempResult = (JObject) tempResult[queryParam];
		            }
		            catch
		            {
                        valueResult = (JValue)tempResult[queryParam];
                    }
		        }

                CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("da-DK");

                queries_results.Add(Join(".", queryParams) + " = " + valueResult.ToString("0.00", cultureInfo));
		    }

            return queries_results;
		}
	}
}
