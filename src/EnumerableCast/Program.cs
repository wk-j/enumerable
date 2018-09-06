using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace EnumerableCast {

    /*
      Method |     Mean |     Error |    StdDev |  Gen 0 | Allocated |
    -------- |---------:|----------:|----------:|-------:|----------:|
     Default | 39.61 ns | 0.6720 ns | 0.5611 ns | 0.0533 |     168 B |
      IsCast | 32.37 ns | 0.4824 ns | 0.4028 ns | 0.0533 |     168 B |
      IsOnly | 32.32 ns | 0.5458 ns | 0.4558 ns | 0.0533 |     168 B |
     */

    public class Config : ManualConfig {
        public Config() {
            Add(Job.Dry.WithLaunchCount(10));
        }
    }

    [MemoryDiagnoser]
    // [Config(typeof(Config))]
    public class Test {
        List<object> a = new List<object>();

        [GlobalSetup]
        public void Setup() {
            foreach (var i in Enumerable.Range(1, 100_000)) {
                a.Add(i);
                a.Add("Hello" + i);
                a.Add(DateTime.Now);
            }
        }

        [Benchmark]
        public void Default() {
            var dates = a.OfType<DateTime>();
            var ints = a.OfType<int>();
            var strings = a.OfType<int>();
        }

        [Benchmark]
        public void IsCast() {
            var dates = a.OfTypeWithIsCast<DateTime>();
            var ints = a.OfTypeWithIsCast<int>();
            var strings = a.OfTypeWithIsCast<int>();
        }

        [Benchmark]
        public void IsOnly() {
            var dates = a.OfTypeWithIs<DateTime>();
            var ints = a.OfTypeWithIs<int>();
            var strings = a.OfTypeWithIs<int>();
        }
    }

    class Program {
        static void Main(string[] args) {
            BenchmarkRunner.Run<Test>();
        }
    }
}
