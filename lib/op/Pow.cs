using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using N=nilnul.num.natural.Natural_bigInteger;

namespace nilnul.num.natural.op
{
	public partial class Pow
		:Binary
	{
		public Pow()
			:base(Eval1)
		{

		}
		static public Pow Instance = SingletonByDefaultNew<Pow>.Instance;

		static public op.ExprI Call(op.ExprI a, op.ExprI b) {
			return new binary.Expr(Instance, a, b);
		}

		static public N Eval1(N base_,N index) {
			return new N( Eval(base_.val,index.val));
		}

		static public BigInteger Eval(BigInteger base_nonNeg, BigInteger index_nonNeg)
		{
			if (base_nonNeg == 0)
			{
				if (index_nonNeg == 0)
				{
					throw new ZeroPowZeroException();

				}
				return 0;

			}

			if (base_nonNeg == 1)
			{
				return 1;

			}
			if (index_nonNeg == 0)
			{
				return 1;

			}
			if (index_nonNeg == 1)
			{
				return base_nonNeg;

			}
			return Eval_basePlural_indexPlural(base_nonNeg, index_nonNeg);

		}
		static public BigInteger Do_nonNeg_nonNeg(BigInteger base_nonNeg, BigInteger index_nonNeg)
		{
			if (base_nonNeg == 0)
			{
				if (index_nonNeg == 0)
				{
					throw new ZeroPowZeroException();

				}
				return 0;

			}

			if (base_nonNeg == 1)
			{
				return 1;

			}
			if (index_nonNeg == 0)
			{
				return 1;

			}
			if (index_nonNeg == 1)
			{
				return base_nonNeg;

			}
			return Eval_basePlural_indexPlural(base_nonNeg, index_nonNeg);

		}

		static public BigInteger Do_basePlural_indexNonNeg(BigInteger base_plural, BigInteger index_nonNeg)
		{
			
			if (index_nonNeg == 0)
			{
				return 1;

			}
		
			return Eval_basePlural_indexPositive(base_plural, index_nonNeg);

		}


		

		static public BigInteger Eval_basePlural_indexPositive(BigInteger base_plural, BigInteger index_positive)
		{

			if (index_positive == 1)
			{
				return base_plural;
			}
			BigInteger remainder;
			var half = BigInteger.DivRem(index_positive, 2, out remainder);	//>=1;
			var halfPow = Eval_basePlural_indexPositive(base_plural, half);
			//var halfPowSquared = halfPow * halfPow;
			return remainder == 0 ? halfPow * halfPow : halfPow * halfPow * base_plural;
		}
		static public BigInteger Eval_basePlural_indexPlural(BigInteger base_plural, BigInteger index_plural)
		{

			
			BigInteger remainder;
			var half = BigInteger.DivRem(index_plural, 2, out remainder);	//>=1;
			
			

			var halfPow = Eval_basePlural_indexPositive(base_plural, half);
			//var halfPowSquared = halfPow * halfPow;

			return remainder == 0 ? halfPow * halfPow : halfPow * halfPow * base_plural;


		}

		

	

		
		

		

	

		static public Natural PowOfZero(Natural index)
		{
			if (index == 0)
			{
				ThrowZeroPowZero();

			}

			return (Natural)0;

		}


		static public Natural2 PowOfZero(Natural2 index)
		{
			if (index == 0)
			{
				ThrowZeroPowZero();

			}

			return (Natural2)0;

		}

		static public void ThrowZeroPowZero()
		{
			throw new ZeroPowZeroException();

		}


		static public Natural_bigInteger Eval(Natural_bigInteger @base, Natural_bigInteger index)
		{

			return new Natural_bigInteger(Do_nonNeg_nonNeg(@base.val, index.val));
		}


		
	


		/// <summary>
		/// 
		/// </summary>
		/// <param name="_base"></param>
		/// <param name="_powPositive"></param>
		/// <returns></returns>
		static private BigInteger _Pow(BigInteger _base, BigInteger _powPositive)
		{
			//

			if (_powPositive == 1)
			{
				return _base;

			}
			BigInteger remainder;
			var half = BigInteger.DivRem(_powPositive, 2, out remainder);

			var halfPow = _Pow(_base, half);
			//var halfPowSquared = halfPow * halfPow;

			return remainder == 0 ? halfPow * halfPow : halfPow * halfPow * _base;



		}
		[Serializable]
		public class ZeroPowZeroException : Exception
		{
			public ZeroPowZeroException() { }
			public ZeroPowZeroException(string message) : base(message) { }
			public ZeroPowZeroException(string message, Exception inner) : base(message, inner) { }
			protected ZeroPowZeroException(
			  System.Runtime.Serialization.SerializationInfo info,
			  System.Runtime.Serialization.StreamingContext context)
				: base(info, context) { }
		}

	}

}
