using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace nilnul.num.natural.set
{
	static public class SumX
	{
		static public NotNull2<Natural2> Sum(NotNull2<IEnumerable<Natural2>> numbers)
		{

			return new Natural2(numbers.val.Aggregate(new BigInteger(0), (a, c) => c.val + a));

		}
		static public NotNull2<Natural_bigInteger> Sum(IEnumerable<Natural_bigInteger> numbers)
		{

			return numbers.Aggregate(Natural_bigInteger.Zero, (a, c) => c + a);

		}
	}
}
