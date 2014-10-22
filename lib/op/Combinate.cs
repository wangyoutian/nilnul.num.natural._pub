using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using N = nilnul.num.natural.Natural_bigInteger;

namespace nilnul.num.natural.op
{
	public partial class Combinate
		:op.Binary
	{
		static public uint Eval(uint total, uint sample)
		{
			return Permutate.Eval(total, sample) / Permutate.Eval(sample, sample);

		}
		static public Natural_bigInteger Eval(Natural_bigInteger total, Natural_bigInteger sample)
		{
			return Permutate.Eval(total, sample) / Permutate.Eval(sample, sample);

		}

		public Combinate()
			:base(Eval)
		{

		}
		static public Combinate Instance = SingletonByDefaultNew<Combinate>.Instance;

		static public op.ExprI Call(ExprI n,ExprI i) {

			return new op.binary.Expr(Instance, n, i);
		
		}


	}
}
