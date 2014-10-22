using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nilnul.collection;
using nat = nilnul.num.natural.Natural;

namespace testCombinate
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var naturalClosedInterval = new ClosedInterval(0, 3);

			HashSet<HashSet<nat>>  combinated=naturalClosedInterval.Combinate();

			HashSet<HashSet<nat>> combinatedBench = new HashSet<HashSet<nat>>(
				HashSet<nat>.CreateSetComparer()
					
			);
			combinatedBench.Add(new HashSet<nat>());	
			
			combinatedBench.Add(new HashSet<nat>(new nat[] { new nat(0) }));
			combinatedBench.Add(new HashSet<nat>(new nat[] { new nat(1) }));
			combinatedBench.Add(new HashSet<nat>(new nat[] { new nat(2) }));

			combinatedBench.Add(new HashSet<nat>(new nat[] { new nat(0),new nat(1) }));
			combinatedBench.Add(new HashSet<nat>(new nat[] { new nat(0),new nat(2) }));
			combinatedBench.Add(new HashSet<nat>(new nat[] { new nat(1),new nat(2) }));

			combinatedBench.Add(new HashSet<nat>(new nat[] { new nat(1),new nat(2),new nat(0) }));
			Assert.IsTrue(
			combinated.SetEquals(combinatedBench));
			Assert.IsTrue(
					combinatedBench.SetEquals(combinated));

			

			


		}
	}
}
