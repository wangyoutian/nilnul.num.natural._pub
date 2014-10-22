using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using T=nilnul.num.natural.Natural2;

namespace nilnul.num.natural.collection
{
	public partial class Interval 
		:

		IEnumerable<Natural2>
	{
		#region ctor
		

		public Interval()
			:this(0)
		{
		}

		public Interval(int right)
		:this(0,right)
		{ 
		}

		public Interval(Plural rightExclusive)
		:this(	
	
			new LessThan.Cut(new Natural2(0))
			,
			 new LessThan.Cut(new Natural2(rightExclusive.val), false)

			
			)
		{
			
		
		}

		public Interval(BigInteger rightExclusive)
			:this(new Plural(rightExclusive))
		{

		}


		public Interval(LessThan.Cut left, LessThan.Cut right)
			: this()
		{
			this.left = left;
			this.right = right;
		}


		public Interval(int left,int right)
			:this(
			new LessThan.Cut((Natural2)left),
			new LessThan.Cut((Natural2)right,false)

		)
		{

		}


		#endregion



		public IEnumerator<Natural2> GetEnumerator()
		{
			Natural2 i = (Natural2)0;

			if (left != null)
			{
				i = left.pinpoint;

				if (!(left.eq))
				{
					i++;
				}
			}


			while (rightContains(i))
			{

				yield return new Natural2(i);
				i++;
			}



			
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}



			#region fields
	

		public LessThan.Cut _left;
		public LessThan.Cut left
		{
			get
			{
				return _left;
			}
			set
			{
				_left = value;
			}
		}

		private LessThan.Cut _right;
		public LessThan.Cut right
		{
			get
			{
				return _right;
			}
			set
			{
				_right = value;
			}
		}


		public void set()
		{

			left = new LessThan.Cut( Natural2.Zero);
			right = null;

		}



		public void set(LessThan.Cut lowerBound, LessThan.Cut upperBound)
		{

			left = lowerBound;
			right = upperBound;

		}

			#endregion




	

		#region instance methods
		
		public bool leftContains(T item) {
			if (left==null)
			{
				return true;
				
			}
			return left.eq && LessThan.Instance.eq(left.pinpoint, item) || LessThan.Instance.gt(item,left.pinpoint);
		
		}

		public bool rightContains(T item)
		{
			if (right == null)
			{
				return true;

			}
			return right.eq && LessThan.Instance.eq(right.pinpoint, item) || LessThan.Instance.lt(item, right.pinpoint);

		}


		public bool contains(T item)
		{

			return leftContains(item) && rightContains(item);

		}
		#endregion


		
	}
}
