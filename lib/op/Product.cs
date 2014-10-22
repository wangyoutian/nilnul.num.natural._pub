using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nilnul.num.natural.op
{
	public partial class Product
	{

		static public Natural2 Eval( params Natural2[] numbers) {

			return numbers.Aggregate(Natural2.One, (a, c) => a * c);
		
		}

		static public uint Eval(params uint[] numbers)
		{

			return numbers.Aggregate((uint)1, (a, c) => a * c);

		}
	}
}
