using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nilnul.num.tuple;
using nilnul.num.matrix;

namespace nilnul.num.sequence
{
	class Fibonacci
	{
		static void Main(string[] args)
		{

			System.Diagnostics.Debug.WriteLine(
				Item3(12)

				);
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

			for (int i = 2; i < index; i++)
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


			}
			return fM1 + fM2;



		}



		public static ulong Item1_5(uint index)
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



		public static ulong Item2(uint index)
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



		public static ulong Item3(uint index)
		{

			uint[,] m = new uint[2, 2] { { 0, 1 }, { 1, 1 } };
			uint[,] a = (uint[,])(m.Clone());



			for (int i = 0; i < index; i++)
			{
				m = Multiply.ToArray(a, m);	//todo: this can be done in power, thus optimizable by binary parallel tasks.

			}

			return m[0, 0];





		}

		static uint[,] InitMatrix = new uint[,] {{0,1},{1,1} };

		static public uint Item_matrix(uint index)
		{

			if (index == 0)
			{
				return 0;

			}
			else
			{
				var m=nilnul.num.matrix.PowX.Eval(InitMatrix,index);
				return m[0, 0];
			}
		}





	}
}
