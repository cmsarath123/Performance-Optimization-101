using BenchmarkDotNet.Attributes;

namespace IntroductionToBenchmark.NET.MyBenchmarks.DateParsers
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class DateParserBenchmark
    {
        private const string SampleDateTime = "2021-04-28T16:33:06Z";
        private static readonly DateParser parser = new();

        [Benchmark]
        public void GetYearFromDateTime() => parser.GetYearFromDateTime(SampleDateTime);

        [Benchmark]
        public void GetYearFromSplit() => parser.GetYearFromSplit(SampleDateTime);

        [Benchmark]
        public void GetYearFromSubstring() => parser.GetYearFromSubstring(SampleDateTime);

        [Benchmark]
        public void GetYearFromSpan() => parser.GetYearFromSpan(SampleDateTime);

        [Benchmark]
        public void GetYearFromSpanWithManualConversion() => parser.GetYearFromSpanWithManualConversion(SampleDateTime);
    }
}
