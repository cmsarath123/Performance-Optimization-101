using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace IntroductionToBenchmark.NET.MyBenchmarks.CleanCodeUseCase
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]    
    public class CleanCodeBenchmarkWithBogus
    {
        private static readonly MethodExtractingExampleWithBogus methodExtractingExample = new();

        [Benchmark]
        public List<string> GetAllSkusOneMethod() => methodExtractingExample.GetAllSkusOneMethod();        

        [Benchmark]
        public List<string> GetAllSkusExtracted() => methodExtractingExample.GetAllSkusExtracted();
    }
}
