using nilnul.num.natural.op;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace nilnul.num.natural.func
{
	static public partial class DoubleFactorialX
	{
		static public PositiveNatural_inheritNatural2 Eval(Natural_bigInteger n) {
			return new PositiveNatural_inheritNatural2(_Eval(n.val));
		
		}

		static public PositiveNatural_inheritNatural2 Eval(BigInteger n) {
			return Eval(new Natural_bigInteger(n));
		}

		static public BigInteger _Eval(BigInteger _natural) {

			if (_natural==0)
			{
				return 1;
				
			}
			if (_natural==1)
			{
				return 1;
				
			}
			return _natural * _Eval(_natural - 2);

		
		}

		static public BigInteger _Eval_viaFactorial(BigInteger _positive_even) {
			var half=_positive_even/2;
		
			return PowerOfTwoX._Eval(half) * FactorialX._Eval_byLoop(half);
				
			
		
		}
	}
}
