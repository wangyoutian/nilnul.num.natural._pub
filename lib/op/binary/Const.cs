using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using N = nilnul.num.natural.Natural_bigInteger;

namespace nilnul.num.natural.op.binary
{
	
		public class Const
		: 
			nilnul.obj.op.binary.closed.Const<N>
		{
			public Const(
				op.BinaryI op
				,
				ConstI arg
				,
				ConstI arg1
				
				)
				:base(op,arg,arg1)
			{

			}

		}

	
	
}
