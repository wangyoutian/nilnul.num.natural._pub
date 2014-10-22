using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace nilnul.num.natural.op
{
	public partial class Permutate
	{
		public static uint Eval(uint total, uint selected)
		{
			if (total < selected)
			{
				throw new Exception();
			}
			uint r = 1;
			for (uint i = total; i >= selected; i--)
			{
				r *= i;
			}
			return r;


		}
		public static BigInteger _Eval(BigInteger _total_natural, BigInteger _selected_natural_lessThanTotal)
		{
			BigInteger r = 1;
			for (BigInteger i = _total_natural; i >= _selected_natural_lessThanTotal; i--)
			{
				r *= i;
			}
			return r;


		}
		public static Natural_bigInteger Eval(Natural_bigInteger total_natural, Natural_bigInteger selected_natural)
		{
			if (total_natural < selected_natural)
			{
				throw new Exception();
			}
			return new Natural_bigInteger( _Eval(total_natural.val, selected_natural.val));


		}
	}
}
