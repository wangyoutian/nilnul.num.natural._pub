using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using nilnul.num.natural.prime.model;


namespace nilnul.num.natural
{
	public partial class PrimeFactoring
	{

		//static void Main(string[] args)
		//{
		//	var d = Eval(60);
			
		//}

		private static PrimeEntities2 db = PrimeController120408.Init();

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
			
			foreach (var item in db.Prime.Where(cc => cc.num <=r ).OrderBy(ccc => ccc.num))
			{
				//divide the number

				var t = u / item.num;
				var quotient = BigInteger.DivRem(u, item.num, out  remainder);

				if (remainder == 0)
				{

					composition= _EvalRecur(quotient);
		
					
					if (composition.ContainsKey((item.num)))
					{
						composition[item.num]++;
					}
					else
					{
						composition.Add(item.num, 1);
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
