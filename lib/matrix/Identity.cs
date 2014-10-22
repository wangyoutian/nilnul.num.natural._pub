using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nilnul.num.natural.matrix
{
	public partial class Identity
	{
		static public uint[,] CreateUint(uint n) { 
			uint[,] r=new uint[n,n];
			for (int i = 0; i < n; i++)
			{
				r[i, i] = 1;

				
			}
			return r;
		}

		static public ulong[,] CreateUlong(uint n)
		{
			ulong[,] r = new ulong[n, n];
			for (int i = 0; i < n; i++)
			{
				r[i, i] = 1;


			}
			return r;
		}

		//static public Square Create(ulong n)
		//{

		//	double[,] r = new double[n, n];
		//	for (ulong i = 0; i < n; i++)
		//	{
		//		r[i, i] = 1;


		//	}

		//	return new Square(new Matrix1(r));

		//}
		//static public Square Create(long n)
		//{

		//	checked
		//	{
		//		return Create((ulong)n);
		//	}

		//}
	}
}
