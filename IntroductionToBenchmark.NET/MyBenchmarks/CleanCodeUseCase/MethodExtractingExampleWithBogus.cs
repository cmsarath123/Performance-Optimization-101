using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;

namespace IntroductionToBenchmark.NET.MyBenchmarks.CleanCodeUseCase
{
    public class MethodExtractingExampleWithBogus
    {
        public List<string> GetAllSkusOneMethod()
        {
            var list = new List<string>();

            foreach(DataRow row in SharedDataWithBogus.ClothingData.Rows)
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
            return list;
        }

        public List<string> GetAllSkusExtracted()
        {
            var list = new List<string>();
            return ParseClothingData(list);
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private static List<string> ParseClothingData(List<string> list)
        {
            foreach (DataRow row in SharedDataWithBogus.ClothingData.Rows)
            {
                var name = row["Name"].ToString();
                var material = row["Material"].ToString();
                var colors = (List<string>)row["AvailableColors"];
                ParseColors(list, name, material, colors);
            }

            return list;
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
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
