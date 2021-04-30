using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntroductionToBenchmark.NET.MyBenchmarks.CleanCodeUseCase
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class CleanCodeBenchmarkWithDummyDataWithAPI
    {
        private static readonly MethodExtractingExampleWithDummyDataWithAPI methodExtractingExample = new();

        [Benchmark]
        public async Task<List<string>> GetAllSkusExtracted() => await methodExtractingExample.GetAllSkusExtracted();

        [Benchmark]
        public async Task<List<string>> GetAllSkusOneMethod() => await methodExtractingExample.GetAllSkusOneMethod();

    }
}
