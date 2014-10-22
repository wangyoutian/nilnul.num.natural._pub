using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace nilnul.num.natural.op


{
	public partial class Multiply2 
		:nilnul.obj.op.binary.Closed<Natural_bigInteger>
    {
	

		static public Natural_bigInteger	Eval(
			Natural_bigInteger	multiplicand,
			Natural_bigInteger multiplier
			) {

				return  new Natural_bigInteger( multiplicand.val * multiplier.val);
		
		}


		public Multiply2()
			:base(Eval)
		{

		}

		
        
    }
	
}
