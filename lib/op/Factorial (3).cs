using System;
using System.Collections;
using System.Numerics;


namespace nilnul.num.natural.op
{
	

	static public partial class FactorialX
	{


		static public BigInteger _Eval_byLoop(BigInteger _natural)
		{


			BigInteger r = 1;
			for (BigInteger i =_natural; i >1;i++ )
			{
				r *= i;
			}
			return r;
		}

	
		static public BigInteger _Eval_recur(this BigInteger _natural)
		{
			if (_natural == 0) return 1;

			return _natural * _Eval_recur(_natural-1);

		}

		
	
		
	}
	
	
	
}
