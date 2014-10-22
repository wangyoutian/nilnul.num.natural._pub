using System;
using System.Net;
using System.Numerics;

using N = nilnul.num.natural.Natural_bigInteger;

namespace nilnul.num.natural.op
{
	public partial class Unary
		:
		nilnul.obj.op.unary.Closed<N>
		,
		UnaryI
	{
		public Unary(Func<N,N> func)
			:base(func)
		{

		}

		
	}
}
