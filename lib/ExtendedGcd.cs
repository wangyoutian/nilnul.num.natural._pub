using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace nilnul.num.natural
{
	static public class ExtendedGcd
	{

		//static void Main(string[] args)
		//{
		//    Console.WriteLine(Eval(120,23));
		//    Console.WriteLine(EvalBySumAndB(120,23));
		//    Console.WriteLine(EvalBySumAndA(120,23));

		//}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns>
		/// Note the tuple is different in that a.val+b.val is different from a.val
		/// 
		/// </returns>
		static public Tuple<BigInteger, BigInteger> EvalBySumAndB(Natural a, Natural b)
		{


			var r= _EvalByIteration(a.val + b.val, b.val);
			
			return new Tuple<BigInteger, BigInteger>(r.Item1, r.Item2 + r.Item1);

		}


		static public Tuple<BigInteger, BigInteger> EvalBySumAndA(Natural a, Natural b)
		{


			var r = _EvalByIteration(a.val + b.val, a.val);

			return new Tuple<BigInteger, BigInteger>(r.Item1+r.Item2, r.Item1);

		}

		static public Tuple<BigInteger, BigInteger> EvalBySumAndA(BigInteger a, BigInteger b)
		{
			return EvalBySumAndA(a.ToNatural(), b.ToNatural());

		}



		static public Tuple<BigInteger, BigInteger> EvalBySumAndB(BigInteger a, BigInteger b)
		{
			return EvalBySumAndB(a.ToNatural(), b.ToNatural());

		}


		static public Tuple<BigInteger, BigInteger> Eval(Natural a, Natural b)
		{


			if (a.val < b.val)
			{
				Tuple<BigInteger, BigInteger> r = _EvalByIteration(b.val, a.val);
				return new Tuple<BigInteger, BigInteger>(r.Item2, r.Item1);

			}

			return _EvalByIteration(a.val, b.val); ;

		}

		static public Tuple<BigInteger, BigInteger> Eval(BigInteger a, BigInteger b)
		{
			return Eval(a.ToNatural(), b.ToNatural());

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns>
		/// 0 for 0,0
		/// </returns>
		/// <remarks>
		/// precedent: a >=b; b>=0;
		/// </remarks>

		static private Tuple<BigInteger, BigInteger> _EvalByIteration(BigInteger a, BigInteger b)
		{
												//a*1+b*1=a+b;		/a...=1....b
			BigInteger lastX = 1, lastY = 0;	//a*1+b*0=a;
			BigInteger x = 0, y = 1;			//a*0+b*1=b;

			BigInteger tempX, tempY;
			BigInteger r;
			BigInteger q;

			while (b != 0)
			{
				q = BigInteger.DivRem(a, b, out r);

				a = b;

				b = r;

				tempX = x;
				tempY = y;

				x = lastX - q * x;	
				
				///	a*lastX+b*lastY==b
				///	a*x+b*y=r
				///	

				y = lastY - q * y;

				lastX = tempX;
				lastY = tempY;


			}

			return new Tuple<BigInteger, BigInteger>(lastX, lastY);



		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		/// <remarks>by recursion</remarks>

		static private Tuple<BigInteger, BigInteger> _Eval(BigInteger a, BigInteger b)
		{

			if (b == 0)
			{
				return new Tuple<BigInteger, BigInteger>(1, 0);

			}
			else
			{
				BigInteger r;
				BigInteger q = BigInteger.DivRem(a, b, out r);
				Tuple<BigInteger, BigInteger> t = _Eval(b, r);
				return new Tuple<BigInteger, BigInteger>(t.Item2, t.Item1 - q * t.Item2);
			}



		}
	}
}
