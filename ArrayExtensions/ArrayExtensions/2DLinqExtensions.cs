using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayExtensions
{
    public static class Array2DLinqExtensions
    {
        public static T Aggregate<T>(this T[,] obj, Func<T, T, T> func)
        {
            return obj.SelectMany().Aggregate(func);
        }

        public static TAccumulate Aggregate<TSource, TAccumulate>(this TSource[,] source, TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func)
        {
            return source.SelectMany().Aggregate(seed, func);
        }

        public static TResult Aggregate<TSource, TAccumulate, TResult>(this TSource[,] source,
            TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
        {
            return source.SelectMany().Aggregate(seed, func, resultSelector);
        }
        
        public static bool Any<T>(this T[,] obj, Func<T, bool> checkerFunc)
        {
            return obj.SelectMany().Any(checkerFunc);
        }

        public static bool Any<TSource>(this TSource[,] source)
        {
            return source != null && (source.GetLength(0) > 0 || source.GetLength(1) > 0);
        }
        
        public static bool All<T>(this T[,] obj, Func<T, bool> checkerFunc)
        {
            return obj.SelectMany().All(checkerFunc);
        }

        public static IEnumerable<TResult> Cast<TResult>(this object[,] source)
        {
            return source.SelectMany().Cast<TResult>();
        }

        public static IEnumerable<TSource> Concat<TSource>(this TSource[,] first, IEnumerable<TSource> second)
        {
            return first.SelectMany().Concat(second);
        }

        public static bool Contains<TSource>(this TSource[,] source, TSource value)
        {
            return source.SelectMany().Contains(value);
        }

        public static bool Contains<TSource>(this TSource[,] source, TSource value,
            IEqualityComparer<TSource> comparer)
        {
            return source.SelectMany().Contains(value, comparer);
        }

        public static int Count<TSource>(this TSource[,] source)
        {
            if(source == null)
                throw new ArgumentNullException();
            
            return source.GetLength(0) * source.GetLength(1);
        }

        public static int Count<TSource>(this TSource[,] source, Func<TSource, bool> predicate)
        {
            return source.SelectMany().Count(predicate);
        }

        public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this TSource[,] source)
        {
            return source.SelectMany().DefaultIfEmpty();
        }

        public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this TSource[,] source,
            TSource defaultValue)
        {
            return source.SelectMany().DefaultIfEmpty(defaultValue);
        }

        public static IEnumerable<TSource> Distinct<TSource>(this TSource[,] source)
        {
            return source.SelectMany().Distinct();
        }

        public static IEnumerable<TSource> Distinct<TSource>(this TSource[,] source,
            IEqualityComparer<TSource> comparer)
        {
            return source.SelectMany().Distinct(comparer);
        }

        public static TSource ElementAt<TSource>(this TSource[,] source, int index)
        {
            if(source == null)
                throw new ArgumentNullException();
            
            var iSize = source.GetLength(0);
            var jSize = source.GetLength(1);
            if (iSize == 0 && jSize == 0)
                throw new InvalidOperationException();
            
            return source[iSize / index,
                          jSize % index];
        }

        public static TSource ElementAtOrDefault<TSource>(this TSource[,] source, int index)
        {
            if(source == null)
                throw new ArgumentNullException();

            var iSize = source.GetLength(0);
            var jSize = source.GetLength(1);
            if (iSize == 0 && jSize == 0)
                return default(TSource);
            
            return source[iSize / index,
                          jSize % index];
        }

        public static IEnumerable<TSource> Except<TSource>(this TSource[,] first, IEnumerable<TSource> second)
        {
            return first.SelectMany().Except(second);
        }

        public static IEnumerable<TSource> Except<TSource>(this TSource[,] first, IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            return first.SelectMany().Except(second, comparer);
        }

        public static TSource First<TSource>(this TSource[,] source)
        {
            if(source == null)
                throw new ArgumentNullException();
            
            if(!source.Any())
                throw new KeyNotFoundException();

            return source[0, 0];
        }

        public static TSource First<TSource>(this TSource[,] source, Func<TSource, bool> predicate)
        {
            return source.SelectMany().First(predicate);
        }

        public static TSource FirstOrDefault<TSource>(this TSource[,] source)
        {
            if(source == null)
                throw new ArgumentNullException();

            return source.Any() ? source[0, 0] : default(TSource);
        }

        public static TSource FirstOrDefault<TSource>(this TSource[,] source, Func<TSource, bool> predicate)
        {
            return source.SelectMany().FirstOrDefault(predicate);
        }

        public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this TSource[,] source,
            Func<TSource, TKey> keySelector)
        {
            return source.SelectMany().GroupBy(keySelector);
        }

        public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this TSource[,] source,
            Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            return source.SelectMany().GroupBy(keySelector, comparer);
        }

        public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(
            this TSource[,] source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            return source.SelectMany().GroupBy(keySelector, elementSelector);
        }

        public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(
            this TSource[,] source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey> comparer)
        {
            return source.SelectMany().GroupBy(keySelector, elementSelector, comparer);
        }

        public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(this TSource[,] source,
            Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector)
        {
            return source.SelectMany().GroupBy(keySelector, resultSelector);
        }

        public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(this TSource[,] source,
            Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            return source.SelectMany().GroupBy(keySelector, resultSelector, comparer);
        }

        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(this TSource[,] source,
            Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector,
            Func<TKey, IEnumerable<TElement>, TResult> resultSelector)
        {
            return source.SelectMany().GroupBy(keySelector, elementSelector, resultSelector);
        }

        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(this TSource[,] source,
            Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector,
            Func<TKey, IEnumerable<TElement>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return source.SelectMany().GroupBy(keySelector, elementSelector, resultSelector, comparer);
        }

        public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this TOuter[,] outer,
            IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
            Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
        {
            return outer.SelectMany().GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector);
        }

        public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this TOuter[,] outer,
            IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
            Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return outer.SelectMany().GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        public static IEnumerable<TSource> Intersect<TSource>(this TSource[,] first, IEnumerable<TSource> second)
        {
            return first.SelectMany().Intersect(second);
        }

        public static IEnumerable<TSource> Intersect<TSource>(this TSource[,] first, IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            return first.SelectMany().Intersect(second, comparer);
        }

        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this TOuter[,] outer,
            IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector)
        {
            return outer.SelectMany().Join(inner, outerKeySelector, innerKeySelector, resultSelector);
        }

        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this TOuter[,] outer,
            IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return outer.SelectMany().Join(inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        public static TSource Last<TSource>(this TSource[,] source)
        {
            if(source == null)
                throw new ArgumentNullException();

            var i = source.GetLength(0);
            var j = source.GetLength(1);
            if(i == 0 && j == 0)
                throw new ArgumentException("Empty array");
            
            return source[i > 0 ? i - 1 : 0, j > 0 ? j - 1 : 0];
        }

        public static TSource Last<TSource>(this TSource[,] source, Func<TSource, bool> predicate)
        {
            return source.SelectMany().Last(predicate);
        }

        public static TSource LastOrDefault<TSource>(this TSource[,] source)
        {
            if(source == null)
                throw new ArgumentNullException();

            var i = source.GetLength(0);
            var j = source.GetLength(1);
            if (i == 0 && j == 0)
                return default(TSource);
            
            return source[i - 1, j - 1];
        }

        public static TSource LastOrDefault<TSource>(this TSource[,] source, Func<TSource, bool> predicate)
        {
            return source.SelectMany().LastOrDefault(predicate);
        }

        public static long LongCount<TSource>(this TSource[,] source)
        {
            if(source == null)
                throw new ArgumentNullException();
            
            return (long)source.GetLength(0) * (long)source.GetLength(1);
        }

        public static long LongCount<TSource>(this TSource[,] source, Func<TSource, bool> predicate)
        {
            return source.SelectMany().LongCount(predicate);
        }

        public static Decimal Max(this Decimal[,] source)
        {
            return source.SelectMany().Max();
        }
    
        public static double Max(this double[,] source)
        {
            return source.SelectMany().Max();
        }
    
        public static int Max(this int[,] source)
        {
            return source.SelectMany().Max();
        }
    
        public static long Max(this long[,] source)
        {
            return source.SelectMany().Max();
        }
    
        
        public static float Max(this float[,] source)
        {
            return source.SelectMany().Max();
        }
    
        public static TSource Max<TSource>(this TSource[,] source)
        {
            return source.SelectMany().Max();
        }
    
        public static Decimal Max<TSource>(this TSource[,] source, Func<TSource, Decimal> selector)
        {
            return source.SelectMany().Max(selector);
        }
    
        public static double Max<TSource>(this TSource[,] source, Func<TSource, double> selector)
        {
            return source.SelectMany().Max(selector);
        }
    
        public static int Max<TSource>(this TSource[,] source, Func<TSource, int> selector)
        {
            return source.SelectMany().Max(selector);
        }
        
        public static long Max<TSource>(this TSource[,] source, Func<TSource, long> selector)
        {
            return source.SelectMany().Max(selector);
        }
    
        public static Decimal? Max<TSource>(this TSource[,] source, Func<TSource, Decimal?> selector)
        {
            return source.SelectMany().Max(selector);
        }
    
        public static double? Max<TSource>(this TSource[,] source, Func<TSource, double?> selector)
        {
            return source.SelectMany().Max(selector);
        }
    
        public static int? Max<TSource>(this TSource[,] source, Func<TSource, int?> selector)
        {
            return source.SelectMany().Max(selector);
        }
    
        public static long? Max<TSource>(this TSource[,] source, Func<TSource, long?> selector)
        {
            return source.SelectMany().Max(selector);
        }
    
        public static float? Max<TSource>(this TSource[,] source, Func<TSource, float?> selector)
        {
            return source.SelectMany().Max(selector);
        }
    
        public static float Max<TSource>(this TSource[,] source, Func<TSource, float> selector)
        {
            return source.SelectMany().Max(selector);
        }
    
        public static TResult Max<TSource, TResult>(this TSource[,] source, Func<TSource, TResult> selector)
        {
            return source.SelectMany().Max(selector);
        }
    
        public static TSource Min<TSource>(this TSource[,] source)
        {
            return source.SelectMany().Min();
        }
    
        public static Decimal Min<TSource>(this TSource[,] source, Func<TSource, Decimal> selector)
        {
            return source.SelectMany().Min(selector);
        }
        
        public static double Min<TSource>(this TSource[,] source, Func<TSource, double> selector)
        {
            return source.SelectMany().Min(selector);
        }
    
        public static int Min<TSource>(this TSource[,] source, Func<TSource, int> selector)
        {
            return source.SelectMany().Min(selector);
        }
    
        public static long Min<TSource>(this TSource[,] source, Func<TSource, long> selector)
        {
            return source.SelectMany().Min(selector);
        }
    
        public static Decimal? Min<TSource>(this TSource[,] source, Func<TSource, Decimal?> selector)
        {
            return source.SelectMany().Min(selector);
        }
    
        public static double? Min<TSource>(this TSource[,] source, Func<TSource, double?> selector)
        {
            return source.SelectMany().Min(selector);
        }
    
        public static int? Min<TSource>(this TSource[,] source, Func<TSource, int?> selector)
        {
            return source.SelectMany().Min(selector);
        }
    
        public static long? Min<TSource>(this TSource[,] source, Func<TSource, long?> selector)
        {
            return source.SelectMany().Min(selector);
        }
    
        public static float? Min<TSource>(this TSource[,] source, Func<TSource, float?> selector)
        {
            return source.SelectMany().Min(selector);
        }
    
        public static float Min<TSource>(this TSource[,] source, Func<TSource, float> selector)
        {
            return source.SelectMany().Min(selector);
        }
    
        public static TResult Min<TSource, TResult>(this TSource[,] source, Func<TSource, TResult> selector)
        {
            return source.SelectMany().Min(selector);
        }
    
        public static IEnumerable<TResult> OfType<TResult>(this object[,] source)
        {
            return source.SelectMany().OfType<TResult>();
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this TSource[,] source,
            Func<TSource, TKey> keySelector)
        {
            return source.SelectMany().OrderBy(keySelector);
        }
    
        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this TSource[,] source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            return source.SelectMany().OrderBy(keySelector, comparer);
        }
    
        public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(this TSource[,] source, Func<TSource, TKey> keySelector)
        {
            return source.SelectMany().OrderByDescending(keySelector);
        }
    
        public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(this TSource[,] source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            return source.SelectMany().OrderByDescending(keySelector, comparer);
        }

        public static IEnumerable<TSource> Reverse<TSource>(this TSource[,] source)
        {
            return source.SelectMany().Reverse();
        }
    
        public static IEnumerable<TResult> Select<TSource, TResult>(this TSource[,] source, Func<TSource, TResult> selector)
        {
            return source.SelectMany().Select(selector);
        }
    
        public static IEnumerable<TResult> Select<TSource, TResult>(this TSource[,] source, Func<TSource, int, TResult> selector)
        {
            return source.SelectMany().Select(selector);
        }
    
        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this TSource[,] source, Func<TSource, IEnumerable<TResult>> selector)
        {
            return source.SelectMany().SelectMany(selector);
        }
    
        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this TSource[,] source, Func<TSource, int, IEnumerable<TResult>> selector)
        {
            return source.SelectMany().SelectMany(selector);
        }
    
        public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this TSource[,] source, 
            Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
        {
            return source.SelectMany().SelectMany(collectionSelector, resultSelector);
        }
    
        public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this TSource[,] source, 
            Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
        {
            return source.SelectMany().SelectMany(collectionSelector, resultSelector);
        }
    
        public static bool SequenceEqual<TSource>(this TSource[,] first, IEnumerable<TSource> second)
        {
            return first.SelectMany().SequenceEqual(second);
        }
    
        public static bool SequenceEqual<TSource>(this TSource[,] first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            return first.SelectMany().SequenceEqual(second, comparer);
        }

        public static TSource Single<TSource>(this TSource[,] source)
        {
            return source.SelectMany().Single();
        }
    
        public static TSource Single<TSource>(this TSource[,] source, Func<TSource, bool> predicate)
        {
            return source.SelectMany().Single(predicate);
        }
    
        public static TSource SingleOrDefault<TSource>(this TSource[,] source)
        {
            return source.SelectMany().SingleOrDefault();
        }
    
        public static TSource SingleOrDefault<TSource>(this TSource[,] source, Func<TSource, bool> predicate)
        {
            return source.SelectMany().SingleOrDefault(predicate);
        }

        public static IEnumerable<TSource> Skip<TSource>(this TSource[,] source, int count)
        {
            return source.SelectMany().Skip(count);
        }
    
        public static IEnumerable<TSource> SkipWhile<TSource>(this TSource[,] source, Func<TSource, bool> predicate)
        {
            return source.SelectMany().SkipWhile(predicate);
        }
    
        public static IEnumerable<TSource> SkipWhile<TSource>(this TSource[,] source, Func<TSource, int, bool> predicate)
        {
            return source.SelectMany().SkipWhile(predicate);
        }

        public static Decimal Sum<TSource>(this TSource[,] source, Func<TSource, Decimal> selector)
        {
            return source.SelectMany().Sum(selector);
        }
    
        public static double Sum<TSource>(this TSource[,] source, Func<TSource, double> selector)
        {
            return source.SelectMany().Sum(selector);
        }
    
        public static int Sum<TSource>(this TSource[,] source, Func<TSource, int> selector)
        {
            return source.SelectMany().Sum(selector);
        }
    
        public static long Sum<TSource>(this TSource[,] source, Func<TSource, long> selector)
        {
            return source.SelectMany().Sum(selector);
        }
    
        public static Decimal? Sum<TSource>(this TSource[,] source, Func<TSource, Decimal?> selector)
        {
            return source.SelectMany().Sum(selector);
        }
    
        public static double? Sum<TSource>(this TSource[,] source, Func<TSource, double?> selector)
        {
            return source.SelectMany().Sum(selector);
        }
    
        public static int? Sum<TSource>(this TSource[,] source, Func<TSource, int?> selector)
        {
            return source.SelectMany().Sum(selector);
        }
    
        public static long? Sum<TSource>(this TSource[,] source, Func<TSource, long?> selector)
        {
            return source.SelectMany().Sum(selector);
        }
    
        public static float? Sum<TSource>(this TSource[,] source, Func<TSource, float?> selector)
        {
            return source.SelectMany().Sum(selector);
        }
    
        public static float Sum<TSource>(this TSource[,] source, Func<TSource, float> selector)
        {
            return source.SelectMany().Sum(selector);
        }
    
        public static IEnumerable<TSource> Take<TSource>(this TSource[,] source, int count)
        {
            return source.SelectMany().Take(count);
        }
    
        public static IEnumerable<TSource> TakeWhile<TSource>(this TSource[,] source, Func<TSource, bool> predicate)
        {
            return source.SelectMany().TakeWhile(predicate);
        }
    
        public static IEnumerable<TSource> TakeWhile<TSource>(this TSource[,] source, Func<TSource, int, bool> predicate)
        {
            return source.SelectMany().TakeWhile(predicate);
        }
    
        public static TSource[] ToArray<TSource>(this TSource[,] source)
        {
            if(source == null)
                throw new ArgumentNullException();

            var iSize = source.GetLength(0);
            var jSize = source.GetLength(1);
            
            var res = new TSource[iSize * jSize];
            Buffer.BlockCopy(source, 0, res, 0, res.Length);
            return res;
        }

        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this TSource[,] source,
            Func<TSource, TKey> keySelector)
        {
            return source.SelectMany().ToDictionary(keySelector);
        }
    
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this TSource[,] source, 
            Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            return source.SelectMany().ToDictionary(keySelector, comparer);
        }
    
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this TSource[,] source, Func<TSource, TKey> keySelector, 
            Func<TSource, TElement> elementSelector)
        {
            return source.SelectMany().ToDictionary(keySelector, elementSelector);
        }
    
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this TSource[,] source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            return source.SelectMany().ToDictionary(keySelector, elementSelector, comparer);
        }

        public static List<TSource> ToList<TSource>(this TSource[,] source)
        {
            return new List<TSource>(source.ToArray());
        }

        public static ILookup<TKey, TSource> ToLookup<TSource, TKey>(this TSource[,] source,
            Func<TSource, TKey> keySelector)
        {
            return source.SelectMany().ToLookup(keySelector);
        }

        public static ILookup<TKey, TSource> ToLookup<TSource, TKey>(this TSource[,] source,
            Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            return source.SelectMany().ToLookup(keySelector, comparer);
        }
    
        public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(this TSource[,] source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            return source.SelectMany().ToLookup(keySelector, elementSelector);
        }
    
        public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(this TSource[,] source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            return source.SelectMany().ToLookup(keySelector, elementSelector, comparer);
        }
    
        public static IEnumerable<TSource> Union<TSource>(this TSource[,] first, IEnumerable<TSource> second)
        {
            return first.SelectMany().Union(second);
        }
    
        public static IEnumerable<TSource> Union<TSource>(this TSource[,] first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            return first.SelectMany().Union(second, comparer);
        }
    
        public static IEnumerable<TSource> Where<TSource>(this TSource[,] source, Func<TSource, bool> predicate)
        {
            return source.SelectMany().Where(predicate);
        }
    
        public static IEnumerable<TSource> Where<TSource>(this TSource[,] source, Func<TSource, int, bool> predicate)
        {
            return source.SelectMany().Where(predicate);
        }
    
        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this TFirst[,] first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
        {
            return first.SelectMany().Zip(second, resultSelector);
        }
            
        public static IEnumerable<T> SelectMany<T>(this T[,] arr)
        {
            if(arr == null)
                throw new ArgumentNullException();
            
            var xSize = arr.GetLength(0);
            var ySize = arr.GetLength(1);
            for (var i = 0; i < xSize; i++)
            {
                for (var j = 0; j < ySize; j++)
                {
                    yield return arr[i, j];
                }
            }
        }
    }
}
