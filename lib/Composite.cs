using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nilnul.num.natural
{
	/// <summary>
	/// A composite number is a number which can be represented by the product of two positive integers, neither of which can be itself.

	/// </summary>
	public partial class Composite
	{

	}

	static public partial class CompositeX
	{
		/// <summary>
		/// determine whether a natural is a composite.
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// 		/// don't be too pusseld for a best to abstain from a soso.

		/// </remarks>
		static public bool IsComposite(Natural n) {

			if (n.val==0 || n.val==1)
			{
				return false;
				
			}
			else
			{
				return !prime.SetX2._IsPrime(n.val);
			}



		
		}
		
	}
}
