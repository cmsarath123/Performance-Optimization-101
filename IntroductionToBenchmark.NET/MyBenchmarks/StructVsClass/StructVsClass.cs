using BenchmarkDotNet.Attributes;

namespace IntroductionToBenchmark.NET.MyBenchmarks.StructVsClass
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class StructVsClass
    {
        private const int ITEMS = 10000;
        class VectorClass
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        struct VectorStruct
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        [Benchmark]
        public void WithClass()
        {
            VectorClass[] vectors = new VectorClass[ITEMS];
            for (int i = 0; i < ITEMS; i++)
            {
                vectors[i] = new VectorClass();
                vectors[i].X = 5;
                vectors[i].Y = 10;
            }
        }
        [Benchmark]
        public void WithStruct()
        {
            VectorStruct[] vectors = new VectorStruct[ITEMS];
            // At this point all the vectors instances are already allocated with default values
            for (int i = 0; i < ITEMS; i++)
            {
                vectors[i].X = 5;
                vectors[i].Y = 10;
            }
        }
    }
}
