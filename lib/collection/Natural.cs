using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nilnul.collection
{
	public partial class Natural:ExtendedNaturalI
	{
		nilnul.num.natural.Natural _val;

		public nilnul.num.natural.Natural val { get{
			return _val;
		}
			set {
				_val = value;
			}
		}


		public Natural(nilnul.num.natural.Natural n)
		{
			this.val = n;
		}
					
	}
}
