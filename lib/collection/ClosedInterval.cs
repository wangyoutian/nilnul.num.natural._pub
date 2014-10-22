using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using nat = nilnul.num.natural.Natural;

namespace nilnul.collection
{
	public partial class ClosedInterval : IEnumerable<nilnul.num.natural.Natural>,HashsetI
	{
		private nilnul.num.natural.Natural _left;

		public nilnul.num.natural.Natural left
		{
			get { return _left; }
			set { _left = value; }
		}
		private nilnul.num.natural.Natural _right;

		public nilnul.num.natural.Natural right
		{
			get { return _right; }
			set { _right = value; }
		}


		public ClosedInterval(nilnul.num.natural.Natural left, nilnul.num.natural.Natural right)
		{
			this.left = left;
			this.right = right;
		}

		public ClosedInterval(int left,int right)
			:this(new nat(left),new nat(right))
		{
		}
					


		public IEnumerator<num.natural.Natural> GetEnumerator()
		{
			for (BigInteger i = left.val; i < right.val; i++)
			{
				yield return new nilnul.num.natural.Natural(i);

			}
		}

		public HashSet<nat> toHashSet()
		{
			var r = new HashSet<nat>();

			foreach (var item in this)
			{
				r.Add(item);

			}
			return r;
		}


		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public HashSet<HashSet<nat>> Combinate() {
			return global::set.collection.nilnul.Combinate.Eval(this.toHashSet());
		}


	}
}
