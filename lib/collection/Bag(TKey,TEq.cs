using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using nilnul.num.natural;
using N = nilnul.num.natural.Natural_bigInteger;

namespace nilnul.num.natural.collection
{
	/// <summary>
	/// value =0 is equivalent to there is no such key, while Dict is not.
	/// </summary>
	/// <typeparam name="TKey"></typeparam>
	public partial class Bag<TKey, TEq> : Bag<TKey>
		where TEq : IEqualityComparer<TKey>, new()
	{

		public Bag(

		)
			: base(Eq)
		{
		}

		static public readonly IEqualityComparer<TKey> Eq = SingletonByDefaultNew<TEq>.Instance;



		public Bag(Bag<TKey> other)
			: base( Eq,other)
		{

		}

		public Bag(NotNull2<IEnumerable<TKey>> elements)
			: base(Eq,elements)
		{
	

		}
		public Bag(IEnumerable<TKey> elements)
			: base(Eq,elements)
		{
		}





		static public partial class Empty
		{
			static public bool Be(Bag<TKey, TEq> bag)
			{

				return bag.cardinality > 0;

			}

			public class Adj
				:nilnul.bit.Adjective_FroFunc<Bag<TKey,TEq>>
			{

				public Adj()
					:base(Be)
				{
				}
			}

			public class Assertion
				:nilnul.bit.AssertionFroAdjSingleton<Bag<TKey,TEq>,Adj>
			{

			}

			public class Noun
				:nilnul.bit.AdjectiveType<Bag<TKey,TEq>,Adj>
			{

				public Noun(Bag<TKey,TEq> bag)
					:base(bag)
				{
				}
					

			}

			public class NounAntonym
				:nilnul.bit.AdjectiveAntonymType<Bag<TKey,TEq>,Adj>
			{

				public NounAntonym(Bag<TKey,TEq> bag)
					:base(bag)
				{
				}
					

			}
					

		}


	}
}
