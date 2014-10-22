using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace nilnul.num.natural.op
{
	public partial class DivRem
	{
		static public uint[] Eval(uint dividend, uint divisor)
		{

			return new uint[] { dividend / divisor, dividend % divisor };
		}
		static public uint Eval(ref uint dividend, uint divisor)
		{
			var r = dividend / divisor;

			dividend %= divisor;

			return r;
		}
		static public uint[] Eval( int dividend, int divisor)
		{
			return Eval((uint)dividend, (uint)divisor);

		}

		static public Natural_bigInteger Eval(ref Natural_bigInteger dividend, Natural_bigInteger divisor)
		{
			BigInteger remainder;
			var r = BigInteger.DivRem(dividend.val, divisor.val, out remainder);

			dividend.val = remainder;

			return new Natural_bigInteger(r);




		}
		static public Natural_bigInteger Eval(ref Natural_bigInteger dividend, int divisor)
		{
			BigInteger remainder;
			var r = BigInteger.DivRem(dividend.val, divisor, out remainder);

			dividend.val = remainder;

			return new Natural_bigInteger(r);




		}

	}
}
