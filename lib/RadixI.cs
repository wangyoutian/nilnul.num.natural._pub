using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nilnul.num.natural
{
	public partial interface RadixI
	{
		SortedSet<char> digits
		{
			get;
		}
	}
}
