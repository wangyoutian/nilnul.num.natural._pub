using nilnul.num.natural.matrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nilnul.num.natural.sequence
{
	public class Fibonacci
	{
		static void Main(string[] args)
		{
			uint n =95;
			var a=System.Diagnostics.Stopwatch.StartNew();

			System.Diagnostics.Debug.WriteLine(
				Item_matrix(n)

				);
			a.Stop();
			Console.WriteLine( a.ElapsedMilliseconds);
			
			a.Restart();
			System.Diagnostics.Debug.WriteLine(
				Item(n)
				
				);
			a.Stop();
			Console.WriteLine(a.ElapsedMilliseconds);
		}


		public static ulong Item(uint index)
		{

			if (index == 0)
			{
				return 0;


			}
			if (index == 1)
			{
				return 1;

			}

			ulong fM1 = 0;
			ulong fM2 = 1;
			bool flag = true;

			for (int i = 2; i <index/*index*/; i++)
			{

				if (flag)
				{
					fM1 += fM2;


				}
				else
				{
					fM2 += fM1;
				}
				flag = !flag;
				if (i>90)
				{

					
				}

			}
			return fM1 + fM2;



		}



		public static ulong Item_twoParallel_x(uint index)
		{

			if (index == 0)
			{
				return 0;


			}
			if (index == 1)
			{
				return 1;

			}

			ulong fM1 = 0;
			ulong fM2 = 1;

			for (int i = 2; i < index; i++)
			{



				fM2 = fM1 + fM2;

				fM1 = fM2 - fM1;


			}
			return fM1 + fM2;




		}



		public static ulong Item_twoParallel(uint index)
		{

			if (index == 0)
			{
				return 0;


			}
			if (index == 1)
			{
				return 1;

			}

			ulong fM1 = 0;
			ulong fM2 = 1;

			ulong biggerOld;


			for (int i = 2; i < index; i++)
			{

				biggerOld = fM2;

				fM2 = fM1 + fM2;

				fM1 = biggerOld;

				//fM1 = fM2 - fM1;


			}
			return fM1 + fM2;




		}



		public static uint Item_matrixLoop(uint index)
		{

			uint[,] m = new uint[2, 2] { { 0, 1 }, { 1, 1 } };
			uint[,] a = (uint[,])(m.Clone());



			for (int i = 0; i < index; i++)
			{
				m = Multiply.Eval(a, m);	//todo: this can be done in power, thus optimizable by binary parallel tasks.

			}

			return m[0, 0];





		}

		static uint[,] InitMatrix = new uint[,] {{0,1},{1,1} };

		static public ulong Item_matrix(uint index)
		{

			
				var m=nilnul.num.natural.matrix.PowX.Eval(InitMatrix,index);
				return m[0, 1];
			
		}

		static public int Item_tailRecurByFold_theFold(int fn, int f_nPlus1,int n) {

			return n == 0 ? fn : Item_tailRecurByFold_theFold(f_nPlus1,fn + f_nPlus1, n - 1);
		
		
		}

		static public int Item_tailRecurByFold(int index) {
			

			return Item_tailRecurByFold_theFold(0, 1, index);
		
		}
/// <summary>
/// 
/// </summary>
/// <param name="index"></param>
/// <returns></returns>
/// <remarks>
		/// [0,1;1,1]^n*[1,0]=[F_{n-1},F_{n}].... 
/// </remarks>
		
	

		static public ulong Item_byMatrixPow(uint index)
		{


			var m = nilnul.num.natural.matrix.PowX.Eval(InitMatrix, index);
			return m[0, 1];

		}

		static public ulong Item2(uint index) {

			return Item_matrix(index);
		
		}





	}
}
