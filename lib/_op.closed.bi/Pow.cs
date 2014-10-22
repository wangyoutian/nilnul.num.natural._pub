using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace nilnul.num.natural
{
	static public partial  class PowX
	{

		static public Natural Square(Natural n) {
			return Pow(n, 2);
	
		}

		static public Natural Pow(BigInteger @base,BigInteger index) {

			return Pow(new Natural(@base), new Natural(index));
		
		}

		static public Natural Pow(int @base, Natural index) {
			return Pow(new Natural(@base), index);
		}

		static public Natural2 Pow(int @base, int index)
		{
			return Pow(new Natural2(@base), new Natural2( index));
		}

		static public Natural Pow(Natural n, int i) {

			return Pow(new Natural(n), new Natural(i));
		
		}

		static public Natural PowOfZero(Natural index) {
			if (index==0)
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

		static public void ThrowZeroPowZero() {
			throw new ZeroPowZeroException();
			
		}


		static public Natural Pow(Natural @base,Natural index) {
			if (@base==0)
			{
				return PowOfZero(index);
				
			}

			if (index==0)
			{
				return (Natural)1;
				
			}
			return (Natural)_Pow(@base.val, index.val);
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
				return new PositiveNatural2( _Pow(@base.val, exp.val));
			}
		}

	
		/// <summary>
		/// 
		/// </summary>
		/// <param name="_base"></param>
		/// <param name="_powPositive"></param>
		/// <returns></returns>
		static private BigInteger _Pow(BigInteger _base,BigInteger _powPositive) {
			//
			
			if (_powPositive==1)
			{
				return _base;
				
			}
			BigInteger remainder;
			var half=BigInteger.DivRem(_powPositive, 2,out remainder);

			var halfPow=_Pow(_base, half);
			//var halfPowSquared = halfPow * halfPow;

			return remainder==0? halfPow * halfPow :halfPow*halfPow*_base;


			
		}

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
