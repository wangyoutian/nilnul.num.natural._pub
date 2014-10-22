using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using T=nilnul.num.natural.Natural2;

namespace nilnul.num.natural
{
	public partial class LessThan
		
				//if it's unbound.
	{

		static private readonly LessThan _Instance = new LessThan();
		static public LessThan Instance
		{
			get
			{
				return _Instance;
			}
		}
		private LessThan()
		{
		}
				
		public  Sign compare(Natural2 x, Natural2 y)
		{

			var r = x.val - y.val;
			if (r>0)
			{
				return Sign.Gt;
				
			}
			else if(
				r==0
				)
			{
				return Sign.Eq;
			}
			return Sign.Lt;
			
			
		}




		public bool gt(T x,T y) {
			return compare(x, y) == Sign.Gt;
		}

		public bool lt(T x, T y){

				return compare(x, y) == Sign.Lt;

		}

		public bool eq(T x, T y) {
			return compare(x, y) == Sign.Eq;
		
		}

		public bool neq(T x, T y)
		{
			return !eq(x,y);

		}



		public bool ge(T x, T y) {
			return gt(x, y) || eq(x, y);
		
		}

		public bool le(T x, T y)
		{
			return lt(x, y) || eq(x, y);

		}


		

		#region subclass Cut
		public partial class Cut
		{
			public T pinpoint;

			public bool eq;


			public Cut(T pinpoint)
			{
				this.pinpoint = pinpoint;
				eq = true;
			}

			public Cut(T pinpoint,bool eq)
				:this(pinpoint)
			{
				this.eq = eq;
			}




		}
		#endregion

		public bool contains(T item1, T item2)
		{
			return lt(item1,item2);
		}


	}
}
