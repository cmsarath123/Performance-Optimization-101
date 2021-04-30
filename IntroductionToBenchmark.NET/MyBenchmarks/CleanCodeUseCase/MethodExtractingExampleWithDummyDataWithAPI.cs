using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntroductionToBenchmark.NET.MyBenchmarks.CleanCodeUseCase
{
    public class MethodExtractingExampleWithDummyDataWithAPI
    {
        public static readonly HttpClient client = new()
        {
            BaseAddress = new Uri("http://localhost:5000")
        };

        public async Task<List<string>> GetAllSkusOneMethod()
        {
            var list = new List<string>();

            foreach(DataRow row in SharedDataWithDummyData.ClothingData.Rows)
            {
                var name = row["Name"].ToString();
                var material = row["Material"].ToString();
                var colors = (List<string>)row["AvailableColors"];

                foreach(var color in colors)
                {
                    var sku = $"{name} made by {material} in {color}";
                    list.Add(sku);
                }
            }

            await client.GetStringAsync("/");

            return list;
        }

        public async Task<List<string>> GetAllSkusExtracted()
        {
            var list = new List<string>();
            ParseClothingData(list);
            await client.GetStringAsync("/");
            return list;
        }

        //[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private static void ParseClothingData(List<string> list)
        {
            foreach (DataRow row in SharedDataWithDummyData.ClothingData.Rows)
            {
                var name = row["Name"].ToString();
                var material = row["Material"].ToString();
                var colors = (List<string>)row["AvailableColors"];
                ParseColors(list, name, material, colors);
            }
        }

        //[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private static void ParseColors(List<string> list, string name, string material, List<string> colors)
        {
            foreach (var color in colors)
            {
                var sku = $"{name} made by {material} in {color}";
                list.Add(sku);
            }            
        }
    }
}
