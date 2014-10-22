using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using N = nilnul.num.natural.Natural_bigInteger;

namespace nilnul.num.natural
{
	public partial class Rel
		:nilnul.obj.rel.Closed<N>
		,
		nilnul.num.natural.RelI
	{
		public Rel(Func<N,N,bool> func)
			:base(func)
		{

		}
		
		
	}
}
