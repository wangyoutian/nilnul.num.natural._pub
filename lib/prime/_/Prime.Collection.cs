using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace nilnul.num.natural
{

	public partial class Prime
	{

		/// <summary>
		/// this is an auto-increase table, an ideal table, i.e., it can hold unlimited primes; while the table implemented in sql serer, due to the capacity constraints there, can only hold bounded primes.
		/// </summary>
		public partial class Collection
		{

			/// <summary>
			/// sql server talbe + memeory.
			/// </summary>
			public partial class Finite
			{


				static nilnul.num.natural.prime.model.Adapter _buffer;
 
				static List<BigInteger> _overflow=new List<BigInteger>();

				static BigInteger _compositeBound;
				/// <summary>
				/// 
				/// </summary>
				/// <param name="next">
				/// overflowing BigInt.
				/// 
				/// </param>
				/// <returns></returns>
				static public bool Contains(BigInteger b) {
					
	
					if (b<=Adapter.MAX)
					{
						_buffer.populateAndCommit(b);
						return _buffer.reader.contains(b);
						
					}
					if (b<=_compositeBound)
					{
						return _overflow.Cast<BigInteger>().Contains(b);
					}


					return false;
				
					
				}

				static public void PopulateToCover(BigInteger b) {
					if (b<=Adapter.MAX)
					{
						Adapter.PopulateAndCommit(b);
						return;
					}

					//if (_overflow==null)
					//{
					//	_overflow = new List<BigInteger>();
						
					//}


					for (BigInteger i =_compositeBound; i < b; )
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
				static public bool _isNextPrime(BigInteger b) {


					BigInteger sqrtFloor = (BigInteger)(b.SqrtFloor());


					foreach (var item in 
						_buffer.reader.connection.Prime.Where(e => e.num <= sqrtFloor).Select(f=>f.num).Cast<BigInteger>().Union(_overflow.Where(g=>g<=sqrtFloor))
						)
					{

						if (b % item == 0)
						{
							return false;

						}
					}

					return true;

				
				}


			}



			

		


			static public bool IsPrime(Natural n)
			{
				Finite.PopulateToCover(n);
				return Finite.Contains(n);

			}

	




		}

	}
}
