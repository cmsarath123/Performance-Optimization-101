using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace IntroductionToBenchmark.NET.MyBenchmarks.CleanCodeUseCase
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class CleanCodeBenchmarkWithDummyData
    {
        private static readonly MethodExtractingExampleWithDummyData methodExtractingExample = new();


        [Benchmark]
        public List<string> GetAllSkusExtracted() => methodExtractingExample.GetAllSkusExtracted();

        [Benchmark]
        public List<string> GetAllSkusOneMethod() => methodExtractingExample.GetAllSkusOneMethod();

    }
}
