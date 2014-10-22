using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using N = nilnul.num.natural.Natural_bigInteger;

namespace nilnul.num.natural.op.binary
{
	
		public class Expr
		: 
			nilnul.obj.op.binary.closed.Expr<N>
			,
			nilnul.num.natural.op.ExprI
		{
			public Expr(
				op.BinaryI op
				,
				ExprI arg
				,
				ExprI arg1
				
				)
				:base(op,arg,arg1)
			{

			}


			
		}

	
	
}
