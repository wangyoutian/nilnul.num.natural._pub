using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace nilnul.num.natural.func
{
	static public partial class PowerOfTwoX
	{
		static public BigInteger _Eval(BigInteger index_natural) {
			if (index_natural == 0)
			{
				return 1;

			}

			BigInteger remainder;
			var half = BigInteger.DivRem(index_natural, 2, out remainder);

			var halfPow = _Eval( half);
			//var halfPowSquared = halfPow * halfPow;



			return remainder == 0 ? halfPow * halfPow : halfPow * halfPow * 2;
			
		}

	}
}
