using BenchmarkDotNet.Attributes;
using System.Text;

namespace IntroductionToBenchmark.NET.MyBenchmarks
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]    
    public class StringBuilderVsString
    {
        private const string text = "hello world!";                
        
        [Params(1, 10, 100, 500, 1000)]
        public int iteratorMaxValue;

        [Benchmark(Baseline = true)]
        public void BuildTextUsingString()
        {
            string SampleText1 = text;
            for(int i = 0; i < iteratorMaxValue; i++)
            {
                SampleText1 = SampleText1 + i;
            }
        }

        [Benchmark]
        public void BuildTextUsingStringBuilder()
        {
            StringBuilder SampleText2 = new(text);
            for (int i = 0; i < iteratorMaxValue; i++)
            {
                SampleText2.Append(i);
            }
        }
    }
}