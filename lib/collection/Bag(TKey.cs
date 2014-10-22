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
	public partial class Bag<TKey> : Dict<TKey>
	{
		public Bag(
			IEqualityComparer<TKey> eq
			)
			: this(eq.ToNotNull())
		{
		}
		public Bag(
			NotNull2<IEqualityComparer<TKey>> eq
			)
			: base(eq)
		{

		}



		public Bag(IEqualityComparer<TKey> eq,Bag<TKey> other )
			: base(eq,other)
		{

		}

		public Bag(NotNull2<IEqualityComparer<TKey>> eq,NotNull2<IEnumerable<TKey>> elements )
			: base(eq,elements)
		{
			

		}
		public Bag(IEqualityComparer<TKey> eq, IEnumerable<TKey> elements)
			: this(eq.ToNotNull(), elements.ToNotNull())
		{
		}
		public Bag(IEqualityComparer<TKey> eq, NotNull2<IEnumerable<TKey>> elements)
			: this(eq.ToNotNull(), elements)
		{
		}



		protected override void _update(TKey key_notNull,  N index_notNull) {

			if (index_notNull == 0)
			{
				Remove(key_notNull);	//true if found, false otherwise according to Dict doc.
				return;
			}

			base._update(key_notNull, index_notNull);
		
		}




	}
}
