using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Data;
using nilnul.num.natural;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;


namespace nilnul.num.natural.prime.conn
{
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	///  This is the controller of a db table.
	///	/// todo:make it thread safe.

	/// </remarks>
	static public partial class Adapter
	{
		public const long MAX = long.MaxValue;

		static public readonly db.nilnul3Entities db = Db.CreateConnection();


		static public void PopulateAndCommit(BigInteger bound)
		{
			_PopulateAndCommit((long)bound);
		}

		static private void _PopulateAndCommit(long _plural)
		{

			_PopulateToCover(_plural);
			//_PopulateToCover_saveByBatch(_plural);
			db.SaveChanges();
		}

		[STAThread]
		static public bool Contains(long i)
		{

			if (PluralX.Not(i))
			{
				return false;

			}

			_PopulateAndCommit(i);

			return db.Prime.Any(c => c.prime1 == i);

		}

		static public bool _Contains(long _plural)
		{



			_PopulateAndCommit(_plural);
			

			return db.Prime.Any(c => c.prime1 == _plural);

		}

		static public IEnumerable<long> SequenceUpTo_inLong__positive(long _positive)
		{
			if (_positive == 1)
			{
				return new long[0];

			}
			return SequenceUpTo_inLong(_positive);
		}

		static public IEnumerable<long> SequenceUpTo_inLong(long _plural)
		{
			_PopulateAndCommit(_plural);

			return db.Prime.Where(c => c.prime1 <= _plural).OrderBy(c => c.pi).Select(c => c.prime1);
		}

		static public IEnumerable<long> SequenceUpToMax()
		{
			return SequenceUpTo_inLong(MAX);

		}





		static public Tuple<long, long, bool> GetUpperPrimability1()
		{
			var maxRec = GetMaxRecord_byCheckNull();
			if (maxRec == null)
			{
				return null;
			}


			var composite = GetCompositeUpperBound();

			if (composite == null)
			{
				return new Tuple<long, long, bool>(maxRec.pi, maxRec.prime1, true);

			}

			return new Tuple<long, long, bool>(maxRec.pi, composite.Value, false);

		}

		static public Tuple<long, long, bool> GetUpperPrimability_noNullReturned()
		{
			var maxRec = GetMaxRecord_byCheckNull();
			if (maxRec == null)
			{
				return new Tuple<long, long, bool>(0, 1, false); ;
			}


			var composite = GetCompositeUpperBound();

			if (composite == null)
			{
				return new Tuple<long, long, bool>(maxRec.pi, maxRec.prime1, true);

			}

			return new Tuple<long, long, bool>(maxRec.pi, composite.Value, false);

		}



		static public db.Prime GetMaxRecord_byCheckNull()
		{

			if (db.Prime.Any())
			{
				var t = db.sp_PrimeMaxRecord().FirstOrDefault();

				if (t == null)
				{
					return null;

				}

				var prime = new db.Prime();
				prime.pi= t.pi.Value;
				prime.prime1 = t.prime.Value;
				return prime;

			}
			else
			{
				return null;
			}

		}


		static public db.sp_PrimeMaxRecord_Result GetMaxRecord2()
		{


			return db.sp_PrimeMaxRecord().FirstOrDefault();



		}

		static public long? GetCompositeUpperBound()
		{

			var r = db.CompositeCap.FirstOrDefault();
			if (r == null)
			{
				return null;

			}
			return r.composite;

		}



		/// <summary>
		/// 
		/// </summary>
		/// <param name="_plural">This must be a plural (a natural no less than 2).</param>
		/// <returns></returns>
		/// <remarks>
		/// find in the table anyone that divides the plural
		///  
		/// </remarks>
		static private bool _isNextPrime2(long _plural)
		{
			//var ordered = db.Primes.OrderBy(c => c.sn);

			//long curPrime;

			long sqrtFloor = (long)(_plural.SqrtFloor());


			foreach (var item in 

				db.Prime.Local.Union(

						db.Prime.Where(f => f.prime1 <= sqrtFloor)
						).Select(g => g.prime1)

				/*

				 (db as IObjectContextAdapter).ObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added).Where(c => c.Entity is db.Prime).Select(d => d.Entity as db.Prime).Where(e => e.prime1<= sqrtFloor).Union(

						db.Prime.Where(f => f.prime1 <= sqrtFloor)
						).Select(g => g.prime1)
				 */
				

				
			)
			{

				if (_plural % item == 0)
				{
					return false;

				}
			}

			return true;

		}

		static public void PopulateToCover(long plural)
		{

			PluralX.Assert(plural);
			_PopulateToCover(plural);

			//
		}
	

		static public void _PopulateSomeMore_tableAlreadyInited(int batchSize_positive=100,int totalBatches_positive=10){

			for (int i = 0; i < totalBatches_positive; i++)
			{
				_PopulateSomeMore2_initialized(batchSize_positive);
				
			}
		
		}


		static public long _PopulateSomeMore2_initialized(int batchSize_positive)
		{
			long maxPrime;
			long maxSn;
			lock (db)
			{

				var maxRecord = GetUpperPrimability1();
				//if (maxRecord == null)
				//{
				//	//table not intialized
				//	maxSn = 0;
				//	maxPrime = 1;

				//}
				//else
				//{
				//	maxSn = maxRecord.Item1;
				//	maxPrime = (long)(maxRecord.Item2);
				//}

				maxSn = maxRecord.Item1;
				maxPrime = (long)(maxRecord.Item2);

				for (int i = 0; i < batchSize_positive; i++)
				{
					maxPrime++;
					while (!_isNextPrime2(maxPrime))
					{
						//nextPrimeCandidate++;
						maxPrime++;

					}

					maxSn++;
					//var r = new mdf.Prime() ;
					////				var r = new NthPrime();
					//r.sn = maxSn;
					//r.prime1 = maxPrime;
					////			db.NthPrimes.AddObject(r);
					//db.Primes.AddObject(r);

					_Insert(maxSn, maxPrime);

					//db.Prime.AddObject(new Prime() { sn = maxSn, num = (long)maxPrime });

				}

				_DeleteBound();


				db.SaveChanges();
			}
			return maxPrime;


		}



		static private void _PopulateToCover(long _plural)
		{

			var upperPrimability = GetUpperPrimability1();

			if (upperPrimability == null)	//init
			{
				_PopulateToCover_FromNull(_plural);
				return;
			}
			else
			{
				if (_plural > upperPrimability.Item2)
				{
					_PopulateToCover_saveByBatch(upperPrimability.Item1, upperPrimability.Item2, _plural);

				}
			}
		}


		static public void PopulateToCover(Plural p)
		{
			_PopulateToCover((long)p);


		}



		static private void _Insert(long sn, long prime)
		{

			var rec = new db.Prime();

			rec.pi = sn;
			rec.prime1 = prime;

			db.Prime.Add(rec);

		}




		/// <summary>
		/// upperPrimability is null
		/// </summary>
		/// <param name="p"></param>
		static private void _PopulateToCover_FromNull(long p)
		{

			_PopulateToCover_saveByBatch(0, 1, p);



		}




		/// <summary>
		/// 
		/// </summary>
		/// <param name="primeSn">
		/// current max prime's sn. it's the prime counting function of prime. for example Pi(2)=1
		/// </param>
		/// <param name="currentBound"></param>
		/// <param name="newBound"> </param>
		/// <returns></returns>
		/// <remarks>
		///  sn=0, bound=1 if table is empty.
		///  
		/// if table is not empty, bound is the actual bound 
		///  
		/// 
		/// </remarks>
		static private long _PopulateToCover_FromSomeToMaxOrNot(long primeSn, long currentBound, long newBound)
		{


			//long sn = 0;

			for (long i = currentBound; i < newBound; )
			{
				//check i's primability

				i++;

				if (_isNextPrime2(i))
				{
					primeSn++;

					_Insert(primeSn, i);

				}


			}

			//new bound

			return primeSn;


		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="currentPrimeSn"></param>
		/// <param name="currentBound"></param>
		/// <param name="newBound"></param>
		/// <returns></returns>
		/// <remarks>
		/// 
		/// </remarks>
		static private void _PopulateToCover(long currentPrimeSn, long currentBound, long newBound)
		{
			//long sn = 0;

			var newBoundDecreased = newBound - 1;

			for (long i = currentBound; i < newBoundDecreased;)
			{
				//check i's primability

				i++;

				if (_isNextPrime2(i))
				{
					currentPrimeSn++;

					_Insert(currentPrimeSn, i);

				}

			

			}	//i is the newBound.



			if (_isNextPrime2(newBound))
			{
				currentPrimeSn++;

				_Insert(currentPrimeSn, newBound);

				///set the 
				///
				_DeleteBound();


			}
			else
			{
				_SetBound(newBound);

			}

		}
		static private void _PopulateToCover_saveByBatch(long currentPrimeSn, long currentBound, long newBound)
		{
			//long sn = 0;

			var newBoundDecreased = newBound - 1;

			int batchSize = 100;
			for (long i = currentBound; i < newBoundDecreased; batchSize--)
			{
				//check i's primability

				i++;

				if (_isNextPrime2(i))
				{
					currentPrimeSn++;

					_Insert(currentPrimeSn, i);

				}

				if (batchSize == 0)
				{
					batchSize = 100;

					db.SaveChanges();


				}

			}	//i is the newBound.



			if (_isNextPrime2(newBound))
			{
				currentPrimeSn++;

				_Insert(currentPrimeSn, newBound);

				///set the 
				///
				_DeleteBound();


			}
			else
			{
				_SetBound(newBound);

			}

		}

		static private void _DeleteBound()
		{
			var compositeUppoerBound = db.CompositeCap.FirstOrDefault();
			if (compositeUppoerBound != null)
			{
				db.CompositeCap.Remove(compositeUppoerBound);

			}
			//db.Prime_CompositeUpperBound

		}

		static private void _SetBound(long newBound)
		{

			var compositeUppoerBound = db.CompositeCap.FirstOrDefault();
			if (compositeUppoerBound != null)
			{
				db.CompositeCap.Remove(compositeUppoerBound);


			}


			compositeUppoerBound = new prime.db.CompositeCap();
			compositeUppoerBound.composite = newBound;
			db.CompositeCap.Add(compositeUppoerBound);



		}





	}







}
