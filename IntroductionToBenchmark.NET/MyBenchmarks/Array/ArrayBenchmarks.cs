using BenchmarkDotNet.Attributes;
using System.Linq;
using System;

namespace IntroductionToBenchmark.NET.MyBenchmarks.Array
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class ArrayBenchmarks
    {
        private int[] _myArray;

        [Params(100, 1000, 2000)]
        public int Size { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            _myArray = new int[Size];

            for(int i = 0; i < Size; i++)
            {
                _myArray[i] = i;
            }
        }

        [Benchmark(Baseline = true)]
        public int[] Original() => _myArray.Skip(Size / 2).Take(Size / 4).ToArray();

        [Benchmark]
        public int[] ArrayCopy()
        {
            var newArray = new int[Size / 4];
            System.Array.Copy(_myArray, Size / 2, newArray, 0, Size / 4);
            return newArray;
        }

        [Benchmark]
        public Span<int> Span() => _myArray.AsSpan().Slice(Size / 2, Size / 4);
    }
}
