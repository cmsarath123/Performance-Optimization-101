using BenchmarkDotNet.Attributes;
using System.Buffers;

namespace IntroductionToBenchmark.NET.MyBenchmarks.Array
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class ArrayPoolBenchmarks
    {
        [Params(1, 10, 100, 1000, 2000)]
        public int Size { get; set; }

        [Benchmark]
        public void RegularArray()
        {
            int[] array = new int[Size];
        }
        [Benchmark]
        public void SharedArrayPool()
        {
            var pool = ArrayPool<int>.Shared;
            int[] array = pool.Rent(Size);
            pool.Return(array);
        }
    }
}
