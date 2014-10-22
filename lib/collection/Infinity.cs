using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nilnul.collection
{

	

		/// <summary>
		/// this is used in the interval.
		/// </summary>
		public class Infinity :ExtendedNaturalI{

			static private readonly Infinity _Instance = new Infinity();
			static public Infinity Instance
			{
				get
				{
					return _Instance;
				}
			}
			private Infinity()
			{
			}
				
		}

		




    
}
