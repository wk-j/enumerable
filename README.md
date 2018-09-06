## Enumerable

```bash
private static IEnumerable<TResult> CastIterator<TResult>(IEnumerable source) {
    foreach (object obj in source) {
        yield return (TResult)obj;
    }
}
```