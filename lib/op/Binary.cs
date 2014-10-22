using System;
using System.Net;
using System.Numerics;

using N = nilnul.num.natural.Natural_bigInteger;

namespace nilnul.num.natural.op
{
	public partial class Binary
		:
		nilnul.obj.op.binary.Closed<N>
		,
		BinaryI
	{
		public Binary(Func<N,N,N> func)
			:base(func)
		{

		}

		

		
	}
}
