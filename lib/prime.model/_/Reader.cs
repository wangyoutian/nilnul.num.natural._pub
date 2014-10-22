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
	public partial class Reader
	{
		PrimeEntities2 _connection;
		public PrimeEntities2 connection {
			get {
				return _connection;
			}
		}

		public Reader()
		{
			_connection = Db.CreateConnection();

		}

		public const long MAX = long.MaxValue;
		//static void Main(string[] args)
		//{
		//    System.Diagnostics.Debug.WriteLine(IsPrime2(50));
		//}



		/// <summary>
		/// </summary>
		/// <param name="r"></param>
		/// <returns></returns>
		/// <remarks>
		/// 	todo: statemanager

		/// </remarks>
		public IEnumerable<Prime> SequenceUpTo(long r) {

			return connection.Prime.Where(cc => cc.num <= r).OrderBy(ccc => ccc.num);		
		}



		public bool IsPrime3(long primeCandidate) {
			PopulateToCover(primeCandidate);
			return connection.Prime.Any(c =>(long) (c.num) == primeCandidate);

		}




		 public bool? IsPrime2(long primeCandidate)
		{


			if (primeCandidate > PopulateSomeMore2())
			{

				return null;
			}


			return connection.Prime.Any(c =>(long)( c.num) == primeCandidate);


		}


		public bool? IsPrimeNow(long primeCandidate)
		{


			if (primeCandidate>(long)GetMaxPrime())
			{
				return null;
				
			}
			long p = (long)primeCandidate;


			return connection.Prime.Any(c =>( c.num) == p);
			


		}

		public bool contains(BigInteger primeCandidate)
		{

			return Contains((long)primeCandidate);

		}
		public bool Contains(long primeCandidate)
		{

			return connection.Prime.Any(c => (c.num) == primeCandidate);

		}


		 public UnaOpCallI<bool> IsPrimeNow2(long primeCandidate)
		{


			if (primeCandidate > (long)GetMaxPrime())
			{
				return new UnaFuncCall2<long,bool>(primeCandidate,IsPrime3,"IsPrime");

			}


			return Identity<bool>.Call(
					connection.Prime.Any(c => (long)(c.num) == primeCandidate)
				)
				;



		}


		public string IsPrimeNowString(long primeCandidate)
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

		 void Main(string[] args)
		{
			var r = IsPrimeNowString(long.MaxValue);

		}





		 public Prime GetMaxRecord()
		{
			lock (connection)
			{
				return connection.Prime.OrderByDescending(c => c.sn).First();

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


		 public Prime GetMaxRecord2()
		{
			
				return connection.Prime.Aggregate((w,a)=>w.num>a.num?w:a);;

	

		}


		 public Prime GetMaxRecord3()
		{

			return connection.Prime.Aggregate<Prime,Prime>(null,(w, a) => a==null? w: (( w.num > a.num) ? w : a )); ;



		}


		 public Prime GetMaxRecord4()
		 {

			 Prime seed=new Prime();
			 seed.sn=0;
			 seed.num=1;
			 return connection.Prime.Aggregate<Prime, Prime>(seed, (w, a) =>  ((w.num > a.num) ? w : a)); ;



		 }

		 public Prime GetMaxRecord_byCheckNull()
		 {


			 if (connection.Prime.Any())
			 {
				 return connection.Prime.Aggregate((w, a) => ((w.num > a.num) ? w : a)); ;

				 
			 }
			 else
			 {
				 return null;
			 }
		



		 }


		 public long? GetMaxPrime4()
		{
			var t = GetMaxRecord3();

			if (t==null)
			{
				return null;
				
			}

			return t.num;

			




		}



		 public long? GetMaxPrime_longNull()
		{
			lock (connection)
			{
				if (connection.Prime.Any())
				{
					return GetMaxPrime();

				}
				return null;

			}




		}
		 public long GetMaxPrime()
		{
			
				return connection.Prime.Max(c => c.num);

			



		}



		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		/// 
		[Obsolete("see GetUpperPrimability")]
		 public Tuple<long, bool> CheckedPluralPrimability()
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
		 public Tuple<long, bool> GetUpperPrimability()
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


		 public Tuple<long,long, bool> GetUpperPrimability1()
		 {	
			 var maxRec = GetMaxRecord_byCheckNull();
			 if (maxRec==null)
			 {
				 return null;
			 }

	
			 var composite = GetCompositeUpperBound();

			 if (composite == null)
			 {
				 return new Tuple<long, long,bool>(maxRec.sn,maxRec.num, true);

			 }

			 return new Tuple<long,long, bool>(maxRec.sn,composite.Value, false);

		 }

		 public long? GetCompositeUpperBound() {

			var r=connection.Prime_CompositeUpperBound.FirstOrDefault();
			if (r==null)
			{
				return null;
				
			}
			return  r.Val;
		
		}


	






		public long PopulateSomeMore2() {
			return PopulateSomeMore2(500);
		}



	

		 public long PopulateSomeMore2( int BatchSize)
		{
			long maxPrime;

			lock (connection)
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
					connection.Prime.AddObject(new Prime() { sn = maxSn, num =(long) maxPrime });

				}

				connection.SaveChanges();
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
		 public bool _isNextPrime2(BigInteger i)
		{

			//var ordered = db.Primes.OrderBy(c => c.sn);

			//long curPrime;

			long sqrtFloor = (long)(i.SqrtFloor());

			foreach (var item in connection.ObjectStateManager.GetObjectStateEntries(EntityState.Added).Where(c => c.Entity is Prime).Select(d => d.Entity as Prime).Where(e => e.num <= sqrtFloor).Union(connection.Prime.Where(f => f.num <= sqrtFloor)).Select(g => g.num))
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
         private bool _isNextPrime2(long _plural)
        {

            //var ordered = db.Primes.OrderBy(c => c.sn);

            //long curPrime;

            long sqrtFloor = (long)(_plural.SqrtFloor());

            foreach (var item in connection.ObjectStateManager.GetObjectStateEntries(EntityState.Added).Where(c => c.Entity is Prime).Select(d => d.Entity as Prime).Where(e => e.num <= sqrtFloor).Union(connection.Prime.Where(f => f.num <= sqrtFloor)).Select(g => g.num))
            {

                if (_plural % item == 0)
                {
                    return false;

                }
            }

            return true;

        }

	



		 public bool _isNextPrime2(Plural i)
		{

			return _isNextPrime2(i.val);


		}


		 public void PopulateToCover(Plural p)
		{

			lock (connection)
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

		 private void _Insert(long sn, long prime)
		{

			var rec = new Prime();

			rec.sn = sn;
			rec.num = prime;

			connection.Prime.AddObject(rec);

		}




		/// <summary>
		/// upperPrimability is null
		/// </summary>
		/// <param name="p"></param>
		 private void _PopulateToCover_FromNull(long p)
		{

			long sn;

			if (p == long.MaxValue)
			{
				sn = _PopulateToCover_FromNullToLessMax(p - 1);

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


		 private long _PopulateToCover_FromNullToLessMax(long p)
		{

			long sn = 0;
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
		private long _PopulateToCover_FromSomeToMaxOrNot(long primeSn, long bound, long p)
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


		 private long _PopulateToCover_FromNullToMaxOrNot(long p)
		{

			long sn = 0;

			for (long i = 1; i < p; )
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





		 public void PopulateToCover(long upperBound)
		{
			///

			lock (connection)
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
