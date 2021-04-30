using BenchmarkDotNet.Running;
using Bogus;
using IntroductionToBenchmark.NET.MyBenchmarks;
using IntroductionToBenchmark.NET.MyBenchmarks.CleanCodeUseCase;
using IntroductionToBenchmark.NET.MyBenchmarks.DateParsers;
using IntroductionToBenchmark.NET.MyBenchmarks.Linq1;
using System;
using static System.IO.File;
using System.Linq;
using System.Runtime.CompilerServices;
using IntroductionToBenchmark.NET.MyBenchmarks.TaskVsValueTask;
using IntroductionToBenchmark.NET.MyBenchmarks.Bogus;
using IntroductionToBenchmark.NET.MyBenchmarks.Array;
using IntroductionToBenchmark.NET.MyBenchmarks.StructVsClass;

namespace IntroductionToBenchmark.NET
{
    class Program
    {
        public static void Main(string[] args)
        {
            var (myChoice, readText) = (default(int), ReadAllLines(@"Menu.txt")?.ToList());
            if(readText != null && readText.Count > 0)
                do
                {
                    readText.ForEach(x => Console.WriteLine(x));
                    if (!int.TryParse(Console.ReadLine(), out myChoice))
                        myChoice = -1;                    
                    ProgramDecider(myChoice);
                } while (myChoice != default);
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static BenchmarkDotNet.Reports.Summary ProgramDecider(int programId) => programId switch
        {
            1 => BenchmarkRunner.Run<Sleeps>(),
            2 => BenchmarkRunner.Run<Md5VsSha256>(),
            3 => ((Func<BenchmarkDotNet.Reports.Summary>)(() => {
                SampleBogus sample = new();
                sample.ExplainMe();
                return null;
            }))(),
            4 => BenchmarkRunner.Run<StringBuilderVsString>(),
            5 => BenchmarkRunner.Run<DateParserBenchmark>(),
            6 => BenchmarkRunner.Run<StructVsClass>(),
            7 => BenchmarkRunner.Run<CleanCodeBenchmarkWithBogus>(),
            8 => BenchmarkRunner.Run<CleanCodeBenchmarkWithDummyData>(),
            9 => BenchmarkRunner.Run<CleanCodeBenchmarkWithDummyDataWithAPI>(),            
            10 => ((Func<BenchmarkDotNet.Reports.Summary>)(() => {
                Randomizer randomizer1 = new Randomizer(200);
                return BenchmarkRunner.Run<AlcoholicDrinksCountLinqBenchmarks>();
            }))(),            
            11 => ((Func<BenchmarkDotNet.Reports.Summary>)(() => {
                Randomizer randomizer2 = new Randomizer(200);
                return BenchmarkRunner.Run<NonAlcoholicDrinkNamesLinqBenchmarks>();
            }))(),
            12 => BenchmarkRunner.Run<TaskBenchmark>(),
            13 => BenchmarkRunner.Run<ArrayBenchmarks>(),
            14 => BenchmarkRunner.Run<ArrayPoolBenchmarks>(),
            _ => ((Func<BenchmarkDotNet.Reports.Summary>)(() =>
            {
                Console.WriteLine(programId == default ? "\nOh Nooo! \n" : "Invalid choice, Are you alright ? \n");
                if (programId != default)
                    programId = -1;
                return null;
            }))(),
        };
    }
}