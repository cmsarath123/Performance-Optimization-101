using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToBenchmark.NET.MyBenchmarks.Lowering
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class LoopsBenchmark
    {
        [Benchmark(Baseline = true)]
        public void WhileLoop() => Loops.WhileLoop();

        [Benchmark]
        public void ForLoop() => Loops.ForLoop();

        [Benchmark]
        public void ForEachLoop() => Loops.ForEachLoop();

    }                       
}
