using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace nilnul.num.natural
{
	public partial class Root
	{
		public static Natural Eval(Natural @base, Count indexDenominator)
		{
			if (@base == 0)
			{
				return (Natural)0;

			}

			return new Natural( _Eval(@base.val, indexDenominator.val));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="base">count (>=1)</param>
		/// <param name="indexDenominator"> count(>=1) </param>
		/// <returns></returns>
		/// <remarks>
		/// not using Newton Method for its complexity
		/// using binary search instead.
		/// </remarks>
		private static BigInteger _Eval(BigInteger @base, BigInteger radical)
		{



			var right = 1 + (@base - 1) / radical+1;		//+1 for the ceiling operation to ensuer rightPow>@base.

			BigInteger left = 1;
			BigInteger span = right - left;

			while (span > 1)
			{
				BigInteger middle = left + span / 2; // if right = left +2+n, where n>=0, then middle = left+1+n/2m which is greater than left, and less than right.

				var middlePow = PowX.Pow(@base, middle);

				if (middlePow > @base)
				{
					right = middle;

				}
				else

				if (middlePow < @base)
				{
						left = middle;

				}
				else
				{
						return middle;
				}

				span = right - left;

			}

			return left;


		}



	}
}
