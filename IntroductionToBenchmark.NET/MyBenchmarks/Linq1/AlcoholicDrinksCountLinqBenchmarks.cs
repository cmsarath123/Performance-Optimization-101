using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace IntroductionToBenchmark.NET.MyBenchmarks.Linq1
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class AlcoholicDrinksCountLinqBenchmarks
    {
        private static readonly BogusData data = new();
        
        
        [Benchmark(Baseline =true)]
        public int AlcholicDrinksCountWithWhere() => data.AlcoholicDrinksCountWithWhere();
        
        [Benchmark]
        public int AlcholicDrinksCountWithDirectCount() => data.AlcoholicDrinksCountWithDirectCount();

        [Benchmark]
        public int AlcoholicDrinksCountWithForLoop() => data.AlcoholicDrinksCountWithForLoop();

        [Benchmark]
        public int AlcoholicDrinksCountWithForEachLoop() => data.AlcoholicDrinksCountWithForEachLoop();                
    }
}
