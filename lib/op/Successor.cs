using System;
using System.Net;
using System.Numerics;

namespace nilnul.num.natural.op
{
	public partial class Successor
		:nilnul.obj.op.binary.Closed<Natural_bigInteger>
	{
		static public Natural_bigInteger Eval(Natural_bigInteger augend, Natural_bigInteger addend) {

			return new Natural_bigInteger(augend.val + 1);
		
		}

		public Successor()
			:base(Eval)
		{

		}
	}
}
