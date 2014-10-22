using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using N = nilnul.num.natural.Natural_bigInteger;

namespace nilnul.num.natural.rel
{
	public partial class Const
		:nilnul.obj.rel.closed.Const<N>
		,
		ConstI
	{
		public Const(obj.RelI<N,N> rel,obj.op.ConstI<N> a, obj.op.ConstI<N> b)
			:base(rel,a,b)
		{

		}
	}
}
