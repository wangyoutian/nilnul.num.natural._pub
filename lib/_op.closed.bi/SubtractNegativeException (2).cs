using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nilnul.num.natural
{
	[global::System.Serializable]
	public class SubtractNegativeException : System.ApplicationException
	{
		//
		// For guidelines regarding the creation of new exception types, see
		//    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
		// and
		//    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
		//

		public SubtractNegativeException() { }
		public SubtractNegativeException(string message) : base(message) { }
		public SubtractNegativeException(string message, Exception inner) : base(message, inner) { }
		protected SubtractNegativeException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context)
			: base(info, context) { }
	}
	
}
