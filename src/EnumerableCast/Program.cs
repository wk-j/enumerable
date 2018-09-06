using System;
using System.Collections;
using System.Collections.Generic;

namespace EnumerableCast {

    static class Extensions {
        public static IEnumerable<TResult> Cast1<TResult>(this IEnumerable source) {
            IEnumerable<TResult> typedSource = source as IEnumerable<TResult>;
            if (typedSource != null) {
                return typedSource;
            }

            if (source == null) {
                throw new ArgumentException(nameof(source));
            }

            return CastIterator1<TResult>(source);
        }
        private static IEnumerable<TResult> CastIterator1<TResult>(IEnumerable source) {
            foreach (object obj in source) {
                yield return (TResult)obj;
            }
        }

        public static IEnumerable<TResult> OfType1<TResult>(this IEnumerable source) {
            if (source == null) {
                throw new ArgumentException(nameof(source));
            }

            return OfTypeIterator<TResult>(source);
        }

        private static IEnumerable<TResult> OfTypeIterator<TResult>(IEnumerable source) {
            foreach (object obj in source) {
                if (obj is TResult result) {
                    yield return result;
                }
            }
        }
    }

    class Program {
        static void Main(string[] args) {
            List<object> o = new List<object> {
                1,
                2,
                "Hello",
             };

            var i = o.OfType1<int>();
            var s = o.OfType1<string>();

            Console.WriteLine(i);
            Console.WriteLine(s);
        }
    }
}
