using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using N = nilnul.num.natural.Natural_bigInteger;

namespace nilnul.num.natural.interval
{
	public partial class LeftOpenToRightInf
		: IntervalI
	{

		private N _lowerBound;

		public N lowerBound
		{
			get { return _lowerBound; }
			set { _lowerBound = value; }
		}



		public LeftOpenToRightInf(N lowerBound)
		{
			this.lowerBound = lowerBound;

		}

		public bool contains(N n)
		{
			return n > lowerBound ;
		}




		public IEnumerator<N> GetEnumerator()
		{
			for (N	i = lowerBound+1; ; i++)
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
