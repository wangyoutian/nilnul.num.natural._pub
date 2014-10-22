using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using N = nilnul.num.natural.Natural_bigInteger;

namespace nilnul.num.natural.op.unary
{
	
		public class Expr
		: 
			nilnul.obj.op.unary.closed.Expr<N>
		{
			public Expr(
				op.UnaryI op
				,
				ExprI arg
			
				
				)
				:base(op,arg)
			{

			}

		}

	
	
}
