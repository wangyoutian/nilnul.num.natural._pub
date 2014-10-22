using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using nilnul.num.natural.collection;
using nilnul.num.natural.prime;


namespace nilnul.num.natural
{
	public partial class Factoring
	{

		//static void Main(string[] args)
		//{
		//	var d = Eval(60);

		//}



		//	private static PrimeEntities db = PrimeController120408.Init();



		/// <summary>
		/// u must be greater than 1.
		/// </summary>
		/// <param name="_plural"></param>
		/// <returns></returns>

		public static Bag _Eval(BigInteger _positive) {
			if (_positive==1)
			{
				return new Bag();
				
			}
			return _Eval_recur(_positive);
		}

		public static Bag _Eval_recur(BigInteger _plural)
		{

			Bag bag = new Bag();
			//composition.Add(u);

			var r = num.natural.SqrtFloorX._SqrtFloor(_plural);



			BigInteger remainder;

			//	bool isPrime = true;

			foreach (var item in SetX2.SequenceUpTo_inBigInteger__positive(r))
			{

				var quotient = BigInteger.DivRem(_plural, item, out  remainder);

				if (remainder == 0)
				{
					bag = _Eval_recur(quotient);
					bag.add(new Prime3(item));

					break;
				}

			}

			if (bag.Count == 0)
			{
				bag.add(new Prime3(_plural));

			}
			return bag;

		}



		public static Bag Eval(int a)
		{
			return Eval(new PositiveNatural2(a));
		}

		public static Bag Eval(PositiveNatural2 u)
		{
			//first iterate each prime under c...

			//get the sqrt of u

			if (u.val.val == 1)
			{
				return new Bag();

			}

			return _Eval_recur(u.val.val);

		}


	}
}
