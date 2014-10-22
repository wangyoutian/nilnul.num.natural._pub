using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Data;
using nilnul.num.natural;
using nilnul.num.natural.prime.model;

namespace nilnul.num.natural.prime.model
{
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	///  This is the controller of a db table.
	///	/// todo:make it thread safe.

	/// </remarks>
	static public partial class Controller
	{



		static public bool _isNextPrime2(Plural i)
		{

			return _isNextPrime2(i.val);


		}


		static public void PopulateToCover(Plural p) {

			lock (db)
			{
				var upperPrimability = GetUpperPrimability();

				if (upperPrimability == null)	//init
				{
					_PopulateToCover_FromNull((long)(p));
					return;
				}
				else
				{

				}



			}




		}

		static private void _Insert(long sn, long prime)
		{

			var rec = new Prime();

			rec.sn = sn;
			rec.num = prime;

			db.Prime.AddObject(rec);

		}

	


		/// <summary>
		/// upperPrimability is null
		/// </summary>
		/// <param name="p"></param>
		static private void _PopulateToCover_FromNull(long p) {

			long sn;

			if (p==long.MaxValue)
			{
				sn=_PopulateToCover_FromNullToLessMax(p - 1);

				//

				if (_isNextPrime2(long.MaxValue))
				{
					_Insert(sn + 1, long.MaxValue);
					
				}
				return;
				
			}

			sn = 0;
			for (long i = 2; i <= p; i++)
			{
				//check i's primability

				if (_isNextPrime2(i))
				{
					sn++;
					_Insert(sn, i);

				}


			}


			return;


		
		}


		static private long _PopulateToCover_FromNullToLessMax(long p)
		{

			long sn=0;
			for (long i = 2; i <= p; i++)
			{
				//check i's primability



				if (_isNextPrime2(i))
				{
					sn++;
					

					_Insert(sn, i);
					
				}


			}


			return sn;


		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="primeSn"></param>
		/// <param name="bound"></param>
		/// <param name="p"></param>
		/// <returns></returns>
		/// <remarks>
		///  sn=0, bound=1 if table is empty.
		///  
		/// if table is not empty, bound is the actual bound 
		/// 
		/// 
		/// </remarks>
		static private long _PopulateToCover_FromSomeToMaxOrNot(long primeSn, long bound,long p)
		{

			//long sn = 0;

			for (long i = bound; i < p; )
			{
				//check i's primability

				i++;

				if (_isNextPrime2(i))
				{
					primeSn++;

					_Insert(primeSn, i);

				}


			}

			return primeSn;


		}


		static private long _PopulateToCover_FromNullToMaxOrNot(long p)
		{

			long sn = 0;

			for (long i = 1; i < p;)
			{
				//check i's primability

				i++;

				if (_isNextPrime2(i))
				{
					sn++;

					_Insert(sn, i);

				}


			}


			return sn;


		}





		static public void PopulateToCover(long upperBound)
		{
			///

			lock (db)
			{
				var upperPrimability = GetUpperPrimability();

				if (upperPrimability == null)	//init
				{

					_PopulateToCover_FromNull(upperBound);

				}


			}



		}





	}
}
