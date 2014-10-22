using System;
using System.Net;

namespace nilnul.num.natural.relation
{

    /// <summary>
    /// this is the sign of the number.
    /// </summary>
	static public partial class PositiveX
	{
		

        static public bool Positive(this UintegerI a) {
            if (a is Natural)
            {
                Natural b = (Natural)a;
                return b.GreaterThan(0);
                
            }
            if (a is PositiveIntegerI)
            {
                return true;
                
            }
          
            throw new Exception("Unrecognized type.");
 
        
        }


	}
}
