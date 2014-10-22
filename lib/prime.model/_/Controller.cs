using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Data;
using nilnul.num.natural;

using nilnul.num.natural.prime.model;
using nilnul.func;
using nilnul_obj.op;


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

		public const long MAX = long.MaxValue;
		//static void Main(string[] args)
		//{
		//    System.Diagnostics.Debug.WriteLine(IsPrime2(50));
		//}


		static public PrimeEntities2 db = Init();



		static public PrimeEntities2 Init() {

			return new PrimeEntities2(@"metadata=res://*/_prime.PrimeModel.csdl|res://*/_prime.PrimeModel.ssdl|res://*/_prime.PrimeModel.msl;provider=System.Data.SqlClient;provider connection string="";Data Source=.\sqlexpress;Initial Catalog=nilnulP;Integrated Security=True;MultipleActiveResultSets=True"";");
		
		}

		/// <summary>
		/// </summary>
		/// <param name="r"></param>
		/// <returns></returns>
		/// <remarks>
		/// 	todo: statemanager

		/// </remarks>
		static public IEnumerable<Prime> SequenceUpTo(long r) {

			return db.Prime.Where(cc => cc.num <= r).OrderBy(ccc => ccc.num);		
		}





		static public bool IsPrime3(long primeCandidate) {
			PopulateToCover(primeCandidate);
			return db.Prime.Any(c =>(long) (c.num) == primeCandidate);

		}




		static public bool? IsPrime2(long primeCandidate)
		{


			if (primeCandidate > PopulateSomeMore2())
			{

				return null;
			}


			return db.Prime.Any(c =>(long)( c.num) == primeCandidate);


		}


		static public bool? IsPrimeNow(long primeCandidate)
		{


			if (primeCandidate>(long)GetMaxPrime())
			{
				return null;
				
			}
			long p = (long)primeCandidate;


			return db.Prime.Any(c =>( c.num) == p);
			


		}


		static public bool Contains(long primeCandidate)
		{

			return db.Prime.Any(c => (c.num) == primeCandidate);

		}


		static public UnaOpCallI<bool> IsPrimeNow2(long primeCandidate)
		{


			if (primeCandidate > (long)GetMaxPrime())
			{
				return new UnaFuncCall2<long,bool>(primeCandidate,IsPrime3,"IsPrime");

			}


			return Identity<bool>.Call(
					db.Prime.Any(c => (long)(c.num) == primeCandidate)
				)
				;



		}


		static public string IsPrimeNowString(long primeCandidate)
		{


			var r = IsPrimeNow2(primeCandidate);

			if (r is UnaFuncCall2<long,bool>)
			{
				return ((UnaFuncCall2<long,bool>)r).ToString();
				
			}
			if(r is UnaFuncCall<bool,bool>)
			{
				return ((UnaFuncCall<bool, bool>)r).arg.ToString();

			}

			return r.ToString();
				



		}

		static void Main(string[] args)
		{
			var r = IsPrimeNowString(long.MaxValue);

		}





		static public Prime GetMaxRecord()
		{
			lock (db)
			{
				return db.Prime.OrderByDescending(c => c.sn).First();

			}


			//var maxRecord = db.Primes.Aggregate((w, next) => next.sn > w.sn ? next : w);


			//var maxRecord = db.Primes.First();
			//foreach (var item in db.Primes)
			//{
			//    if (item.sn > maxRecord.sn)
			//    {
			//        maxRecord = item;

			//    }

			//}
			//return maxRecord;


		}


		static public Prime GetMaxRecord2()
		{
			
				return db.Prime.Aggregate((w,a)=>w.num>a.num?w:a);;

	

		}


		static public Prime GetMaxRecord3()
		{

			return db.Prime.Aggregate<Prime,Prime>(null,(w, a) => a==null? w: (( w.num > a.num) ? w : a )); ;



		}


		static public long? GetMaxPrime4()
		{
			var t = GetMaxRecord3();

			if (t==null)
			{
				return null;
				
			}

			return t.num;

			




		}



		static public long? GetMaxPrime_longNull()
		{
			lock (db)
			{
				if (db.Prime.Any())
				{
					return GetMaxPrime();

				}
				return null;

			}




		}
		static public long GetMaxPrime()
		{
			
				return db.Prime.Max(c => c.num);

			



		}



		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		/// 
		[Obsolete("see GetUpperPrimability")]
		static public Tuple<long, bool> CheckedPluralPrimability()
		{
			var composite = GetCompositeUpperBound();
			if (composite == null)
			{
				var maxPrime = GetMaxPrime_longNull();


				if (maxPrime == null)
				{
					return null;

				}
				return new Tuple<long, bool>(GetMaxPrime(), true);

			}
			return new Tuple<long, bool>(composite.Value, false);

		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns>null if no record.</returns>
		static public Tuple<long, bool> GetUpperPrimability()
		{
			var composite = GetCompositeUpperBound();

			if (composite == null)
			{
				var maxPrime = GetMaxPrime_longNull();


				if (maxPrime == null)
				{
					return null;

				}
				return new Tuple<long, bool>(GetMaxPrime(), true);

			}
			return new Tuple<long, bool>(composite.Value, false);

		}

		static public long? GetCompositeUpperBound() {

			var r=db.Prime_CompositeUpperBound.FirstOrDefault();
			if (r==null)
			{
				return null;
				
			}
			return  r.Val;
		
		}





		static public long PopulateSomeMore2() {
			return PopulateSomeMore2(500);
		}



	

		static public long PopulateSomeMore2( int BatchSize)
		{
			long maxPrime;

			lock (db)
			{

				var maxRecord = GetMaxRecord();
				long maxSn = maxRecord.sn;
				maxPrime =(long)( maxRecord.num);

				for (int i = 0; i < BatchSize; i++)
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
					db.Prime.AddObject(new Prime() { sn = maxSn, num =(long) maxPrime });

				}

				db.SaveChanges();
			}
			return maxPrime;
		}



		/// <summary>
		/// there must be at least one prime in the table.
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>


		/// <summary>
		/// this will use stateManager
		/// </summary>
		/// <param name="i">a plural less than long.max</param>
		/// <returns></returns>
		static public bool _isNextPrime2(BigInteger i)
		{

			//var ordered = db.Primes.OrderBy(c => c.sn);

			//long curPrime;

			long sqrtFloor = (long)(i.SqrtFloor());

			foreach (var item in db.ObjectStateManager.GetObjectStateEntries(EntityState.Added).Where(c => c.Entity is Prime).Select(d => d.Entity as Prime).Where(e => e.num <= sqrtFloor).Union(db.Prime.Where(f => f.num <= sqrtFloor)).Select(g => g.num))
			{

				if (i % item == 0)
				{
					return false;

				}
			}

			return true;

		}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_plural">This must be a plural (a natural no less than 2).</param>
        /// <returns></returns>
        /// <remarks>
        /// find in the table anyone that divides the plural
        /// if the table is empty, 
        /// </remarks>
        static private bool _isNextPrime2(long _plural)
        {

            //var ordered = db.Primes.OrderBy(c => c.sn);

            //long curPrime;

            long sqrtFloor = (long)(_plural.SqrtFloor());

            foreach (var item in db.ObjectStateManager.GetObjectStateEntries(EntityState.Added).Where(c => c.Entity is Prime).Select(d => d.Entity as Prime).Where(e => e.num <= sqrtFloor).Union(db.Prime.Where(f => f.num <= sqrtFloor)).Select(g => g.num))
            {

                if (_plural % item == 0)
                {
                    return false;

                }
            }

            return true;

        }

	}
}
