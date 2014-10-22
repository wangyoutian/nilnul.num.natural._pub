using System;
using System.Net;


namespace nilnul.num.natural.op
{
	public partial class Subtract
		:nilnul.obj.op.binary.Closed<Natural_bigInteger>
	{
		static public Natural_bigInteger Eval(Natural_bigInteger minuend, Natural_bigInteger subtrahend)
		{
			return new Natural_bigInteger(minuend.val - subtrahend.val);

		
		}
		public Subtract()
			:base(Eval)
		{

		}

	}

}
