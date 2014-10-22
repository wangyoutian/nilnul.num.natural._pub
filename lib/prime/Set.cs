using nilnul.num.natural.prime.conn;
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


		//static nilnul.num.natural.Adapter _buffer;

		 List<BigInteger> _overflow = new List<BigInteger>();



		static BigInteger _chekedTill = Adapter.MAX;


		 private bool Contains(Plural b)
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
		 private bool _Contains(BigInteger _plural)
		{


			if (_plural <= Adapter.MAX)
			{

				return Adapter.Contains((long)_plural);

			}
			if (_plural <= _chekedTill)
			{
				return _overflow.Cast<BigInteger>().Contains(_plural);
			}


			return false;

		}

		 private bool Contains(int i)
		{
			if (PluralX.Not(i))
			{
				return false;

			}

			return Contains(new Plural(i));

		}





		 private void _PopulateToCover(BigInteger p_plural)
		{

			for (BigInteger i = _chekedTill; i < p_plural; )
			{
				//check i's primability
				i++;
				if (_isNextPrime(i))
				{
					_overflow.Add(i);

				}

			}
			_chekedTill = p_plural;

		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="b">geater than upperbound</param>
		/// <returns></returns>
		/// 
		
		 private bool _isNextPrime(BigInteger b)
		{


			BigInteger sqrtFloor = (BigInteger)(b.SqrtFloor());


			foreach (
				var item 
				in 
				Adapter.db.Prime.Where(e => e.prime1<= sqrtFloor).Select(f => f.prime1).Cast<BigInteger>().Union(_overflow.Where(g => g <= sqrtFloor))
			)
			{

				if (b % item == 0)
				{
					return false;

				}
			}

			return true;


		}


		 public IEnumerable<BigInteger> SequenceUpTo_inBigInteger__positive(BigInteger _positive )   
		{


			if (_positive <= Adapter.MAX)
			{
				return Adapter.SequenceUpTo_inLong__positive((long)_positive).Select(c => new BigInteger(c));//.Cast<BigInteger>();
			}

			_PopulateToCover(_positive);

			return Adapter.SequenceUpToMax().Select(c => new BigInteger(c)).Union(_overflow.TakeWhile(c => c <= _positive));




		}


		 public IEnumerable<BigInteger> SequenceUpTo_inBigInteger(BigInteger _plural)
		{

			if (_plural <= Adapter.MAX)
			{
				return Adapter.SequenceUpTo_inLong((long)_plural).Select(c => new BigInteger(c));//.Cast<BigInteger>();
			}

			_PopulateToCover(_plural);

			return Adapter.SequenceUpToMax().Select(c => new BigInteger(c)).Union(_overflow.TakeWhile(c => c <= _plural));



		}



		[Obsolete("not right",true)]
		 public bool IsPrime(Natural n)
		{
			_PopulateToCover(n);
			return _Contains(n);

		}


		 public bool _IsPrime(BigInteger n_plural)
		{
			if (n_plural <= Adapter.MAX)
			{
				return Adapter._Contains((long)n_plural);

			}


			_PopulateToCover(n_plural);
			return _Contains(n_plural);

		}


		 public bool IsPrime(BigInteger n_plural)
		{
			if (n_plural<2)
			{
				return false;
				
			}
			return _IsPrime(n_plural);
		}


		 public bool IsPrime(Plural2.Noun n)
		{
			return _IsPrime(n.val.val);

		}





	}



}

