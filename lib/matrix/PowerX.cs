using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nilnul.collection;
using nilnul.num.natural;
using nilnul.collection.matrix;
using nilnul.collection.matrix.square;

namespace nilnul.num.natural.matrix
{
	/// <summary>
	/// compute the result of power
	/// </summary>
	/// 

	static public class PowX
	{
		static public Square<uint> Eval(this Square<uint> m,uint p) {
			if (m==null )
			{
				return null;
				
			}

			if (m.components==null)
			{
				return null;
				
			}
			


			return new Square<uint>(_Eval(m.components, p));

		
		}



		static public uint[,] Eval(this uint[,] a, uint p){
			var r = Eval(new Square<uint>(a), p);
			
			
			return r==null?null:r.components;
		}





		static private uint[,] _Eval(uint[,] a,uint p) {
			
			if (p==0)
			{
				return Identity.CreateUint((uint)a.GetLength(0));
				
			}

			if (p==1)
			{
				return a;
				
			}


			
			var l=p/2;
			var r=p-l-l;


			var t = _Eval(a, l);
			return Multiply.Eval(
				Multiply.Eval(t, t)
				,
				_Eval(a, r)
			);
			

			

		
		}
		//static private ulong[,] _Eval(ulong[,] a, uint p)
		//{

		//	if (p == 0)
		//	{
		//		return Identity.CreateUlong((uint)a.GetLength(0));

		//	}

		//	if (p == 1)
		//	{
		//		return a;

		//	}



		//	var l = p / 2;
		//	var r = p - l - l;


		//	var t = _Eval(a, l);
		//	return Multiply.Eval(
		//		Multiply.Eval(t, t)
		//		,
		//		_Eval(a, r)
		//	);





		//}

	}
	
}
