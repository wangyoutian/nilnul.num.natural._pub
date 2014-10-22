using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using N = nilnul.num.natural.Natural_bigInteger;

namespace nilnul.num.natural
{
	public partial class Literal
		:nilnul.obj.Literal2<N>
		,
		nilnul.num.natural.op.ExprI
		,
		VarI
	{
		public Literal(N n)
			:base(n)
		{

		}

	

	}
}
