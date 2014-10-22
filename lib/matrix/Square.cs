using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nilnul.bit;
using Matrix1 = nilnul.num.matrix._1.Matrix;

namespace nilnul.num.matrix
{
	public partial class Square:Matrix1
	{//
		//Matrix1 _matrix;

		public Square(Matrix1 m)
		{
			Assert(m);
			this.elments2= m.elments2;
		
		}

		public Square(double[,] m) {
			AssertX.Eval(m.GetLongLength(0) == m.GetLongLength(1));

			this.elments2 = m;
		
		}

		



		static public void Assert(Matrix1 m) {
			AssertX.Eval(Is(m));
		}

		static public bool Is(Matrix1 m) {
			if (m.columnsCount ==m.rowsCount)
			{
				return true;
				
			}
			return false;
		}
					
	}
}
