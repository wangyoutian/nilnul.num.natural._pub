using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nilnul.num.tuple
{
	public partial class UintMatrix
	{
		uint[,] _val;

		public uint[,] val {
			get {
				return _val;
			}
		}

		public UintMatrix(uint[,] val)
		{
			this._val = val;
		}

		public uint m {
			get {
				return (uint)(_val.GetLength(0));
			}
		}

		public uint n {
			get {
				return (uint)(_val.GetLength(1));
			
			
			}
		
		}

		static public uint M(uint[,] matrix)
		{

			return (uint)(matrix.GetLength(0));

		}
		static public uint N(uint[,] matrix)
		{

			return (uint)(matrix.GetLength(1));

		}


	}

	static public class MatrixX
	{
		static public uint M(this uint[,] matrix) {

			return (uint)(matrix.GetLength(0));

		
		}

		static public uint N(this uint[,] matrix)
		{

			return (uint)(matrix.GetLength(1));

		}


		
	}
}
