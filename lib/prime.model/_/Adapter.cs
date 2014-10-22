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
	public partial class Adapter
	{
		public const long MAX = long.MaxValue;

		Reader _reader;
		public Reader reader {
			get {
				return _reader;
			}
			private set {
				_reader = value;
			}
		}

		public Adapter(Reader reader)
		{
			this.reader = reader;

		}

		public Adapter()
		{
			this.reader = new Reader();
		}

		public void populateAndCommit(BigInteger bound) {
			populateAndCommit((long)bound);
		}

		public void populateAndCommit(long bound) {
			
			populateToCover(bound);
			reader.connection.SaveChanges();

		
		}

		
		static public void PopulateAndCommit(BigInteger bound)
		{
			PopulateAndCommit((long)bound);


		}

		static public void PopulateAndCommit(long bound)
		{
			var buffer=new Adapter(new Reader());
			buffer.populateAndCommit(bound);
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
		private bool _isNextPrime2(long _plural)
		{
			//var ordered = db.Primes.OrderBy(c => c.sn);

			//long curPrime;

			long sqrtFloor = (long)(_plural.SqrtFloor());

			foreach (var item in reader.connection.ObjectStateManager.GetObjectStateEntries(EntityState.Added).Where(c => c.Entity is Prime).Select(d => d.Entity as Prime).Where(e => e.num <= sqrtFloor).Union(reader.connection.Prime.Where(f => f.num <= sqrtFloor)).Select(g => g.num))
			{

				if (_plural % item == 0)
				{
					return false;

				}
			}

			return true;

		}

		public void populateToCover(long plural) {

			PluralX.Assert(plural);
			_populateToCover(plural);

			//
		}



		private void _populateToCover(long _plural) {

			var upperPrimability = reader.GetUpperPrimability1();

			if (upperPrimability == null)	//init
			{
				_populateToCover_FromNull(_plural);
				return;
			}
			else
			{
				if (_plural>upperPrimability.Item2)
				{
					_populateToCover(upperPrimability.Item1, upperPrimability.Item2, _plural);

				}
			}
		}


		public void populateToCover(Plural p)
		{
			_populateToCover((long)p);
			

		}

		

		private void _Insert(long sn, long prime)
		{

			var rec = new Prime();

			rec.sn = sn;
			rec.num = prime;

			reader.connection.Prime.AddObject(rec);

		}




		/// <summary>
		/// upperPrimability is null
		/// </summary>
		/// <param name="p"></param>
		private void _populateToCover_FromNull(long p)
		{

			_populateToCover(0, 1, p);



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
		private long _PopulateToCover_FromSomeToMaxOrNot(long primeSn, long currentBound, long newBound)
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
		private void _populateToCover(long currentPrimeSn, long currentBound, long newBound)
		{


			//long sn = 0;

			var newBoundDecreased=newBound-1;
			

			for (long i = currentBound; i < newBoundDecreased; )
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
				var compositeUppoerBound=reader.connection.Prime_CompositeUpperBound.FirstOrDefault();
				if (compositeUppoerBound!=null)
				{
					reader.connection.Prime_CompositeUpperBound.DeleteObject(compositeUppoerBound);
					
				}


			}
			else
			{
				var compositeUppoerBound = reader.connection.Prime_CompositeUpperBound.FirstOrDefault();
				if (compositeUppoerBound != null)
				{
					compositeUppoerBound.Val = newBound;

				}
				else
				{
					compositeUppoerBound = new Prime_CompositeUpperBound();
					compositeUppoerBound.Val = newBound;
					reader.connection.Prime_CompositeUpperBound.AddObject(compositeUppoerBound);
				}

			}
		}
	}
}
