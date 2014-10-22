using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace nilnul.num.natural
{
	public partial class Plural
	:Natural
	{
		

		public override BigInteger val {
			get {
				return _val;

			}
			set {
				PluralX.Assert(value);
				_val = value;
			}
		}

		public Plural(BigInteger val)
			:base(val)
		{
			this.val = val;
		}
					
	}

}
