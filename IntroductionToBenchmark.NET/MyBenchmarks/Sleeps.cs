using BenchmarkDotNet.Attributes;
using System.Threading;

namespace IntroductionToBenchmark.NET.MyBenchmarks
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class Sleeps
    {
        [Params(50, 100, 150, 200)]
        public int SleepTime { get; set; }
        [Benchmark(Baseline = true)]
        public void Sleeper() => Thread.Sleep(SleepTime);        
    }
}
