using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SimQLTask
{
	[TestFixture]
	public class SimQLProgram_Should
	{
		[Test]
		public void SimSQLShould()
		{
		    var results =
		        SimQLProgram.ExecuteQueries(
		            "{'data':{'empty':{},'ab':0,'x1':1,'x2':2,'y1':{'y2':{'y3':3}}},'queries':['empty','xyz','x1.x2','y1.y2.z','empty.foobar']}");
            
            Console.WriteLine();
			Assert.AreEqual(new String[] {"empty", "xyz", "x1.x2", "y1.y2.z", "empty.foobar"}, results.ToArray());
		}

        [Test]
		public void SumEmptyDataToZero()
		{
			var results = SimQLProgram.ExecuteQueries(
				"{" +
				"'data': [], " +
				"'queries': ['sum(item.cost)', 'sum(itemsCount)']}");
			Assert.AreEqual(new[] {0, 0}, results);
		}

		[Test]
		public void SumSingleItem()
		{
			var results = SimQLProgram.ExecuteQueries(
				"{" +
				"'data': [{'itemsCount':42}, {'foo':'bar'}], " +
				"'queries': ['sum(itemsCount)']}");
			Assert.AreEqual(new[] { 42 }, results);
		}
	}
}