using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace nilnul.num.natural.prime
{


	/// <summary>
	/// this is an auto-increase table, an ideal table, i.e., it can hold unlimited primes; while the table implemented in sql serer, due to the capacity constraints there, can only hold bounded primes.
	/// </summary>


	/// <summary>
	/// sql server talbe + memeory.
	/// </summary>
	public partial class Set
	{


		static nilnul.num.natural.prime.model.Adapter _buffer;

		static List<BigInteger> _overflow=new List<BigInteger>();

		static BigInteger _compositeBound;


		static private bool Contains(Plural b)
		{


			return _Contains(b.val);

		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="next">
		/// overflowing BigInt.
		/// 
		/// </param>
		/// <returns></returns>
		static private bool _Contains(BigInteger _plural)
		{


			if (_plural <= Adapter.MAX)
			{
				
				return prime.model.WriterX2.Contains((long)_plural);

			}
			if (_plural <= _compositeBound)
			{
				return _overflow.Cast<BigInteger>().Contains(_plural);
			}


			return false;

		}

		static private bool Contains(int i) {
			if (PluralX.Not(i))
			{
				return false;
				
			}

			return Contains(new Plural(i));
		
		}

	


		static private void PopulateToCover(BigInteger b)
		{
			if (b <= Adapter.MAX)
			{
				Adapter.PopulateAndCommit(b);
				return;
			}

			//if (_overflow == null)
			//{
			//	_overflow = new List<BigInteger>();

			//}



			for (BigInteger i = _compositeBound; i < b; )
			{
				//check i's primability
				i++;
				if (_isNextPrime(i))
				{
					_overflow.Add(i);

				}

			}
			_compositeBound = b;

		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="b">geater than upperbound</param>
		/// <returns></returns>
		static private bool _isNextPrime(BigInteger b)
		{


			BigInteger sqrtFloor = (BigInteger)(b.SqrtFloor());


			foreach (var item in
				_buffer.reader.connection.Prime.Where(e => e.num <= sqrtFloor).Select(f => f.num).Cast<BigInteger>().Union(_overflow.Where(g => g <= sqrtFloor))
				)
			{

				if (b % item == 0)
				{
					return false;

				}
			}

			return true;


		}




		static public bool IsPrime(Natural n)
		{
			PopulateToCover(n);
			return _Contains(n);

		}




	}



}

