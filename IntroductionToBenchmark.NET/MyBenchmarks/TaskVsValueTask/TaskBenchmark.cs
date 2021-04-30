using BenchmarkDotNet.Attributes;
using System.Threading.Tasks;

namespace IntroductionToBenchmark.NET.MyBenchmarks.TaskVsValueTask
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class TaskBenchmark
    {
        private static readonly FxClient fxClient = new();

        [Benchmark(Baseline = true)]
        public async Task<FxRate> GetFxRateAsyncTask()
        {
            return await fxClient.GetFxRateAsyncTask("USD", "INR");
        }
           
        [Benchmark]
        public async ValueTask<FxRate> GetFxRateAsyncValueTask2Times()
        {
            return await fxClient.GetFxRateAsyncValueTask("USD", "INR");
        }
    }
}
