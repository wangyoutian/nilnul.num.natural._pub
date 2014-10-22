using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace nilnul.num.natural
{
    public class Gcd
    {
        static public uint Eval(uint a,uint b) {
            return a <= b ? _EvalSmallFirst(a, b) : _EvalSmallFirst(b, a);
            
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="smaller"></param>
        /// <param name="bigger"></param>
        /// <returns>0 for (0,0)</returns>
        /// <remarks>a is less than b. Note small first for big things is defined upon the definition of small that must be established first.</remarks>
        static private uint _EvalSmallFirst(uint smaller,uint bigger) {
            if (smaller==0)
            {
                return bigger;
                
            }
            return _EvalSmallFirst(bigger % smaller, smaller);

        }

        static public BigInteger Eval(BigInteger a,BigInteger b) {
 
            return BigInteger.GreatestCommonDivisor(a,b);
        
        }

        static public UintegerI Eval(UintegerI a, UintegerI b) {

            if (a is Natural && b is Natural)
            {
                return Eval(
                    ((Natural)a).toBigInteger(),
                    ((Natural)b).toBigInteger()
                    ).ToNatural();
                
            }
            throw new Exception("Unrecognized type.");
        
        
        }

		static public Natural Exec(Natural a,Natural b) {
			return new Natural( Eval(a.val, b.val));
		
		}

		static public Natural Exec(IEnumerable<Natural> a) {
			if (a.Count()==0)
			{
				return (Natural)0;
				
			}
			else
			{
				return _Exec(a.First(),a.Skip(1));
			}

		
		}

	

		static public Natural _Exec(Natural a,IEnumerable<Natural> list) {
			if (list.Count()==0)
			{
				return a;
			}
			var first = list.First();

			var gcd = Exec(a, first);
			return _Exec(gcd, list.Skip(1));
		}
    }
}
