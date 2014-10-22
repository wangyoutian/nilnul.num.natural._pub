using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using N = nilnul.num.natural.Natural_bigInteger;


namespace nilnul.num.natural.collection
{
	public partial class Dict<TKey>
		:
		
		Dictionary<TKey, Natural_bigInteger>
	//  A key cannot be null, but a value can be, if the value type TValue is a reference type. http://msdn.microsoft.com/en-us/library/xfhwa508(v=vs.100).aspx

	{

		public Dict(NotNull2<IEqualityComparer<TKey>> eq)
			:base(eq.val)
		{

		}
		public Dict(IEqualityComparer<TKey> eq)
			:this(eq.ToNotNull())
		{
		}
		public Dict(IEqualityComparer<TKey> eq,Dict<TKey> dict )
			:base(dict,eq)
		{
		}

		public Dict(IEqualityComparer<TKey> eq,IEnumerable<TKey> keysInMultiples)
			:this(eq.ToNotNull(),keysInMultiples.ToNotNull())
		{

		}

		public Dict(NotNull2<IEqualityComparer<TKey>> eq, NotNull2<IEnumerable<TKey>> elements)
			: this(eq)
		{
			_addRange(elements.val);

		}

		public void unionWith(Dict<TKey> other) {

			unionWith(other as IEnumerable<KeyValuePair<TKey, N>>);
		
		}

		public void unionWith(IEnumerable<KeyValuePair<TKey,N>> other)
		{

			foreach (var item in other)
			{
				vary(item);

			}

		}

		public void addRange(NotNull2<IEnumerable<TKey>> elements)
		{

			_addRange(elements.val);

		}
		public void addRange(IEnumerable<TKey> elements)
		{

			addRange(elements.ToNotNull());

		}

		private void _addRange( IEnumerable<TKey> elements_notNull ){

			foreach (var item in elements_notNull)
			{
				add(item);

			}
		
		}
	

		
		public void add(TKey key)
		{
			if (this.ContainsKey(key))
			{
				this[key].increase();

			}
			else
			{
				this.Add(key, N.NewOne);
			}

		}

		public N cardinality
		{
			get{
			return this.Aggregate(N.Zero, (s, c) => nilnul.num.natural.Natural_bigInteger.Add(s, c.Value));
			}
		}


		public virtual N multiplicity(TKey key)
		{
			if (this.ContainsKey(key))
			{
				return this[key];

			}
			else
			{
				return  (N)( 0);
				//return null;
			}
		}


		public void update(TKey key, N index)
		{

			update(key.ToNotNull(), index.ToNotNull());


		}

		protected virtual void _update(TKey key_notNull, N index_notNull)
		{

			if (this.ContainsKey(key_notNull))
			{
				this[key_notNull] = index_notNull;
			}
			else
			{
				this.Add(key_notNull, index_notNull);
			}

		}
		public void update(NotNull2<TKey> key, NotNull2<N> index)
		{
			_update(key.val, index.val);
		}

		private void _vary(
			TKey key_notNull,
			BigInteger value
		)
		{
			var index = multiplicity(key_notNull) + value;
			_update(key_notNull, new Natural_bigInteger(index));
		}

		public void vary(NotNull2<TKey> key, BigInteger value)
		{
			_vary(key.val, value);

		}


		public void vary(TKey key, BigInteger value)
		{
			vary(key.ToNotNull(), value);

		}

		public void vary(KeyValuePair<TKey, N> keyVal)
		{
			vary(keyVal.Key, keyVal.Value);

		}



		static public partial class Empty
		{
			static public bool Be(Dict<TKey> bag)
			{

				return bag.cardinality > 0;

			}

			public class Adj
				:nilnul.bit.Adjective_FroFunc<Dict<TKey>>
			{

				public Adj()
					:base(Be)
				{
				}
			}

			public class Assertion
				:nilnul.bit.AssertionFroAdjSingleton<Dict<TKey>,Adj>
			{

			}

			public class Noun
				:nilnul.bit.AdjectiveType<Dict<TKey>,Adj>
			{

				public Noun(Dict<TKey> bag)
					:base(bag)
				{
				}
					

			}

			public class NounAntonym
				:nilnul.bit.AdjectiveAntonymType<Dict<TKey>,Adj>
			{

				public NounAntonym(Dict<TKey> bag)
					:base(bag)
				{
				}
			}
		}
	}
}
