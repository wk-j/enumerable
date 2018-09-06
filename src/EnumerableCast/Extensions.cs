using System;
using System.Collections;
using System.Collections.Generic;

namespace EnumerableCast {
    static class Extensions {

        public static IEnumerable<TResult> OfTypeWithIs<TResult>(this IEnumerable source) {
            if (source == null) {
                throw new ArgumentException(nameof(source));
            }
            foreach (object obj in source) {
                if (obj is TResult result) {
                    yield return result;
                }
            }
        }

        public static IEnumerable<TResult> OfTypeWithIsCast<TResult>(this IEnumerable source) {
            if (source == null) {
                throw new ArgumentException(nameof(source));
            }
            foreach (object obj in source) {
                if (obj is TResult) {
                    yield return (TResult)obj;
                }
            }
        }
    }
}
