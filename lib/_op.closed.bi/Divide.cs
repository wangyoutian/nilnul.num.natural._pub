using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nilnul.num.natural
{
	public partial class Divide
	{
		public static Natural Eval(Natural n,Count divisor)
		{

			return new Natural(n.val / divisor.val);
		}
		public static Natural Eval(Natural n,int divisor)
		{

			return Eval(n,new Count(divisor));
		}
	}
}
