using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using N = nilnul.num.natural.Natural_bigInteger;

namespace nilnul.num.natural.rel
{
	public partial class Expr
		:nilnul.obj.rel.closed.Expr<N>
		,
		ExprI
	{
		public Expr(obj.RelI<N,N> rel, obj.op.ExprI3<N> a, obj.op.ExprI3<N> b)
			:base(rel,a,b)
		{

		}
	}
}
