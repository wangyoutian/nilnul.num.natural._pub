using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace nilnul.num.natural.op

{
	public partial class Multiply 
    {


		static private readonly Multiply _Instance = new Multiply();
		private Multiply() { }
		static public Multiply Instance
		{
			get
			{
				return _Instance;
			}
		}

		static public Natural2 Exec(
			Natural2 a,
			Natural2 b
			) {

				return  new Natural2( a.val * b.val);
		
		}
				

		public override string  ToString()
		{
 	
			return "*";
			
		}

		
        
    }
	
}
