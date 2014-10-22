using System;
using System.Net;
using System.Numerics;

using N = nilnul.num.natural.Natural_bigInteger;

namespace nilnul.num.natural.op
{
	public partial class Add
		:nilnul.obj.op.binary.Closed<Natural_bigInteger>
	{
		static public Natural_bigInteger Eval(Natural_bigInteger augend, Natural_bigInteger addend) {

			return new Natural_bigInteger(augend.val + addend.val);
		
		}

		public Add()
			:base(Eval)
		{

		}
		public class Call
		
		{

			private N _left;

			public N left
			{
				get { return _left; }
				set { _left = value; }
			}
			private N _right;

			public N right
			{
				get { return _right; }
				set { _right = value; }
			}
			
			
			public Call(N left,N right)
			{
				this.left = left;
				this.right = right;

			}
		}

	

		
	}
}
