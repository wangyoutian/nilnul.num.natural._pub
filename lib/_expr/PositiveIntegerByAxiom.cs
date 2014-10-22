using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nilnul.num.natural
{
    /// <summary>
    /// the stored structure is UintegerI, and with some constraints.
    /// </summary>
   public  class PositiveIntegerByAxiom:PositiveIntegerI
    {

       /// <summary>
       /// 
       /// </summary>
       private UintegerI _val;
       public PositiveIntegerByAxiom(Natural val)
       {
           //check the val 

           if (Zero.Is(val))
           {
               throw new Exception("This is 0.");
           }

           this._val = val;

       }

       public UintegerI ToUinteger() {
           return _val;
       
       }
	   public override string ToString()
	   {
		   return this._val.ToString();
	   }

	   public NaturalI minimum(IEnumerable<NaturalI> subsets)
	   {
		   throw new NotImplementedException();
	   }

	   public int CompareTo(NaturalI other)
	   {
		   throw new NotImplementedException();
	   }
	}
}
