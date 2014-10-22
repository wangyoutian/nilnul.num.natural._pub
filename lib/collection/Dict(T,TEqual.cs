using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nilnul.num.natural.collection
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="TKey"></typeparam>
	/// <typeparam name="TEqual"></typeparam>
	/// <remarks>
	///		this is different from Bag in that value=0 is different from no such key.
	///		while Bag makes no difference in value=0 and no such key.
	/// </remarks>
	public partial class Dict<TKey,TEqual>
		:Dict<TKey>
		where TEqual:IEqualityComparer<TKey>,new()
	{
		public Dict()
			:base(SingletonByDefaultNew<TEqual>.Instance as IEqualityComparer<TKey>)
		{
		}

		public Dict(IEnumerable<TKey> keysInMultiples)
			:base(Eq,keysInMultiples)
		{
		}

		static public TEqual Eq = SingletonByDefaultNew<TEqual>.Instance;
					
					

	}
}
