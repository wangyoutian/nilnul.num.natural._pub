using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nilnul.num.natural.encoding
{
	public partial class FixedLen
	{
		static public string Encode( Natural_bigInteger n, Natural_bigInteger bitsLen) {

			StringBuilder sb = new StringBuilder();

			var quotient = n;
			var residue = n;

			while (bitsLen>0)
			{
				quotient = op.DivRem.Eval(ref residue, 2);
//				sb.Append(residue);
				sb.Insert(0, residue);
				residue = quotient;
				bitsLen--;
				
			}



			if (residue>0)
			{
				return ("overflown");
			}

			return sb.ToString();


			throw new NotImplementedException();
		
		}

		static public string Encode1(Natural_bigInteger num, Natural_bigInteger bitsLen)
		{

			StringBuilder sb = new StringBuilder();

			var quotient = num;
			var residue = num;

			while (bitsLen > 0)
			{
				quotient = op.DivRem.Eval(ref residue, 2);
				//				sb.Append(residue);
				sb.Insert(0, residue);
				residue = quotient;
				bitsLen--;

			}



			if (residue > 0)
			{
				throw new  OverflowException();
				return ("overflown");
			}

			return sb.ToString();


			throw new NotImplementedException();

		}



		[Serializable]
		public class OverflowException : Exception
		{
			public OverflowException() { }
			public OverflowException(string message) : base(message) { }
			public OverflowException(string message, Exception inner) : base(message, inner) { }
			protected OverflowException(
			  System.Runtime.Serialization.SerializationInfo info,
			  System.Runtime.Serialization.StreamingContext context)
				: base(info, context) { }
		}

	}
}
