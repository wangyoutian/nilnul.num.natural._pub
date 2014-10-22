using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using N = nilnul.num.natural.Natural_bigInteger;

namespace nilnul.num.natural.interval
{
	public partial class OpenClose
		:IntervalI
	{
		private N _upperOpenBound;

		public N upperOpenBound
		{
			get { return _upperOpenBound; }
			set { _upperOpenBound = value; }
		}

		private N _lowerBound;

		public N lowerBound
		{
			get { return _lowerBound; }
			set { _lowerBound = value; }
		}
		

		
		public OpenClose(N lower, N upperOpenBound)
		{
			this.upperOpenBound = upperOpenBound;
			this.lowerBound = lower;

		}

		public OpenClose(int a,N upperBound)
			:this(new N(a),upperBound)
		{

		}

		public OpenClose(int a,int b)
			:this(a,new N(b))
		{

		}
		



		public bool contains(N n) {

			return n > lowerBound && n <= upperOpenBound;
		
		}


		public IEnumerator<N> GetEnumerator()
		{
			for (N i = lowerBound+1 ; i <= upperOpenBound; i++)
			{
				yield return i;

			}
			yield break;
			throw new NotImplementedException();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
			throw new NotImplementedException();
		}

	}
}
