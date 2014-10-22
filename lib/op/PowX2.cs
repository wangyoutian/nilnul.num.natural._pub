using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace nilnul.num.natural.op
{
	static public partial class PowX2
	{
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
		static public BigInteger Eval(uint base_, uint index)
		{
			if (index == 0)
			{
				return 1;
			}

			var half = op.DivRem.Eval(ref index, 2);	//>=1;
			var halfPow = Eval(base_, half);
			return index == 0 ? halfPow * halfPow : halfPow * halfPow * base_;
		}
		static public BigInteger Eval(int base_, int index)
		{
			
			return Eval((uint)base_,(uint)index);
		}


		static public BigInteger Eval_basePlural_indexPlural(BigInteger base_plural, BigInteger index_plural)
		{

			
			BigInteger remainder;
			var half = BigInteger.DivRem(index_plural, 2, out remainder);	//>=1;
			
			

			var halfPow = Eval_basePlural_indexPositive(base_plural, half);
			//var halfPowSquared = halfPow * halfPow;

			return remainder == 0 ? halfPow * halfPow : halfPow * halfPow * base_plural;


		}

		static public Natural Square(Natural n)
		{
			return Pow(n, 2);

		}

		static public Natural Pow(BigInteger @base, BigInteger index)
		{

			return Pow(new Natural(@base), new Natural(index));

		}

		static public Natural Pow2(BigInteger @base, BigInteger index)
		{

			return Pow(new Natural(@base), new Natural(index));

		}

		static public Natural Pow(int @base, Natural index)
		{
			return Pow(new Natural(@base), index);
		}

		static public Natural2 Pow(int @base, int index)
		{
			return Pow(new Natural2(@base), new Natural2(index));
		}

		static public Natural Pow(Natural n, int i)
		{

			return Pow(new Natural(n), new Natural(i));

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


		static public Natural Pow(Natural @base, Natural index)
		{
			if (@base == 0)
			{
				return PowOfZero(index);

			}

			if (index == 0)
			{
				return (Natural)1;

			}
			return (Natural)_Pow(@base.val, index.val);
		}
		static public Natural_bigInteger Eval(Natural_bigInteger @base, Natural_bigInteger index)
		{

			return new Natural_bigInteger(Do_nonNeg_nonNeg(@base.val, index.val));
		}


		static public Natural2 Pow(Natural2 @base, Natural2 index)
		{
			if (@base == 0)
			{
				return PowOfZero(index);

			}

			if (index == 0)
			{
				return (Natural2)1;

			}
			return (Natural2)_Pow(@base.val, index.val);
		}

		static public Count Pow(this Count @base, Natural exp)
		{
			if (Zero.Is(exp))
			{
				return new Count(1);


			}
			else
			{
				//
				return new Count(_Pow(@base.val, exp.val));
			}


		}

		static public PositiveNatural2 Pow(this PositiveNatural2 @base, Natural exp)
		{
			if (Zero.Is(exp))
			{
				return new PositiveNatural2(1);


			}
			else
			{
				//
				return new PositiveNatural2(_Pow(@base.val, exp.val));
			}
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
