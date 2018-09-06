## Enumerable

```bash
private static IEnumerable<TResult> OfTypeIterator<TResult>(IEnumerable source) {
    foreach (object obj in source) {
        if (obj is TResult result) {
            yield return result;
        }
    }
}
```