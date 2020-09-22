#if NET20
using System;
using System.Collections.Generic;
using QuickGraph;

namespace System.Linq
{
    public static class Enumerable
    {
        public static bool All<T>(IEnumerable<T> values, Predicate<T> predicate)
        {
            foreach (var value in values)
                if (!predicate(value))
                    return false;
            return true;
        }

        public static int Count<T>(IEnumerable<T> values, Predicate<T> predicate)
        {
            int count = 0;
            foreach (var value in values)
                if (predicate(value))
                    count++;
            return count;
        }

        public static IEnumerable<T> Where<T>(IEnumerable<T> values, Predicate<T> predicate)
        {
            foreach (var value in values)
                if (predicate(value))
                    yield return value;
        }

        public static IEnumerable<T> Empty<T>()
        {
            return new EmptyEnumerator<T>();
        }

        struct EmptyEnumerator<T> 
            : IEnumerable<T>
            , IEnumerator<T>
        {
            public IEnumerator<T> GetEnumerator()
            {
                return this;
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            public T Current
            {
                get { throw new NotImplementedException(); }
            }

            public void Dispose()
            {}

            object System.Collections.IEnumerator.Current
            {
                get { throw new NotImplementedException(); }
            }

            public bool MoveNext()
            {
                return false;
            }

            public void Reset()
            {}
        }

        public static T[] ToArray<T>(IEnumerable<T> values)
        {
            return new List<T>(values).ToArray();
        }

        public static bool Any<T>(IEnumerable<T> elements, Predicate<T> filter)
        {
            foreach (var element in elements)
                if (filter(element))
                    return true;
            return false;
        }

        public static T ElementAt<T>(IEnumerable<T> elements, int index)
        {
            int count = 0;
            foreach (var element in elements)
                if (count++ == index)
                    return element;
            throw new ArgumentOutOfRangeException("index");
        }

        public static int Count<T>(IEnumerable<T> elements)
        {
            ICollection<T> collection = elements as ICollection<T>;
            if (collection != null)
                return collection.Count;

            T[] array = elements as T[];
            if (array != null)
                return array.Length;

            int count = 0;
            foreach (var element in elements)
                count++;
            return count;
        }

        public static T First<T>(IEnumerable<T> elements)
        {
            foreach (var element in elements)
                return element;
            throw new ArgumentException();
        }

        public static T FirstOrDefault<T>(IEnumerable<T> elements)
        {
            foreach (var element in elements)
                return element;
            return default(T);
        }

        public static double Sum<T>(IEnumerable<T> elements, Func<T, double> map)
        {
            double sum = 0;
            foreach (var element in elements)
                sum += map(element);
            return sum;
        }

        public static int Sum<T>(IEnumerable<T> elements, Func<T, int> map)
        {
            int sum = 0;
            foreach (var element in elements)
                sum += map(element);
            return sum;
        }
    }
}
#endif