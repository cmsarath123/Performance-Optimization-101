using Newtonsoft.Json;
using System;

namespace IntroductionToBenchmark.NET.MyBenchmarks.Bogus
{
    public static class ExtensionsForTesting
    {
        public static void Dump(this object obj)
        {
            Console.WriteLine(obj.DumpString());
        }

        public static string DumpString(this object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}
