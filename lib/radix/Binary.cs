using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nilnul.num.natural.radix
{
	public partial class Binary
	{
		private nilnul.collection.set.Set<char> _digits=new nilnul.collection.set.Set<char>(new []{'0','1'});

		public nilnul.collection.set.Set<char> digits
		{
			get { return _digits; }
			
		}


		
	}
}
