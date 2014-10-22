using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;


namespace nilnul.num.natural
{
	/// <summary>
	/// 
	/// </summary>
	/// 
	[Obsolete("See PrimeFactoring")]
	public class PrimeDecomposition
	{
		private static prime.db.nilnul3Entities db =prime.Db.CreateConnection();

		/// <summary>
		/// u must be greater than 1.
		/// </summary>
		/// <param name="u"></param>
		/// <returns></returns>

		private static Dictionary<BigInteger, long> _EvalRecur(BigInteger u) {

			Dictionary<BigInteger, long> composition= new Dictionary<BigInteger, long>();
			var r = u.Sqrt();
			BigInteger remainder;
			bool isPrime = true;
			foreach (var item in db.Prime.Where(cc => cc.prime1<=r ).OrderBy(ccc => ccc.prime1))
			{
				//divide the number
				var t = u / item.prime1;
				var quotient = BigInteger.DivRem(u, item.prime1, out  remainder);

				if (remainder == 0)
				{
					composition= _EvalRecur(quotient);
					if (composition.ContainsKey((item.prime1)))
					{
						composition[item.prime1]++;
					}
					else
					{
						composition.Add(item.prime1, 1);
					}
					isPrime = false;
					break;
				}

			}
			if (isPrime)
			{
				composition.Add(u, 1);
				
			}
			return composition;
		
		}

		public static Dictionary<BigInteger,long> Eval(int a){
			return Eval(new Count(a));
		}

		public static Dictionary<BigInteger,long> Eval(Count u) { 
			//first iterate each prime under c...

			//get the sqrt of u

			if (u.val==1)
			{
				return null;
				
			}

			return _EvalRecur(u.val);

			

		}
	}
}
