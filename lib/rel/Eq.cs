using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using N = nilnul.num.natural.Natural_bigInteger;

namespace nilnul.num.natural.rel
{
	public partial class Eq
		:nilnul.num.natural.Rel
	{

		static public Eq Instance = SingletonByDefaultNew<Eq>.Instance;
		static public bool Be(N a,N b) {
			return a.val==b.val;

			throw new NotImplementedException();
		
		}
		public Eq()
			:base(Be)
		{

		}

		static public rel.Expr Call(op.ExprI a, op.ExprI b)
		{
			return new rel.Expr(SingletonByDefaultNew<Eq>.Instance, a, b);

		}

		static public rel.Const  Call(op.ConstI a, op.ConstI b)
		{
			return new rel.Const(SingletonByDefaultNew<Eq>.Instance, a, b);

		}







		


	}
}
