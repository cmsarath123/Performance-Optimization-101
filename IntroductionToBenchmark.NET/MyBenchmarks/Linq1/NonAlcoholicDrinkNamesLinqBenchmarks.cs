using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace IntroductionToBenchmark.NET.MyBenchmarks.Linq1
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class NonAlcoholicDrinkNamesLinqBenchmarks
    {
        private static readonly BogusData data = new();
        
        
        [Benchmark(Baseline =true)]
        public List<string> NonAlcoholicDrinkNamesForLoop() => data.NonAlcoholicDrinkNamesForLoop();

        [Benchmark]
        public List<string> NonAlcoholicDrinkNamesWhereSelectToList() => data.NonAlcoholicDrinkNamesWhereSelectToList();
    }
}
