using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using N = nilnul.num.natural.Natural_bigInteger;

namespace nilnul.num.natural.op.unary
{
	
		public class Const
		: 
			nilnul.obj.op.unary.closed.Const<N>
		{
			public Const(
				op.UnaryI op
				,
				ConstI arg
				
				
				)
				:base(op,arg)
			{

			}

		}

	
	
}
