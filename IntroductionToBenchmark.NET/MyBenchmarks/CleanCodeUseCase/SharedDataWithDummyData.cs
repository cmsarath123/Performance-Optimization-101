using Bogus;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToBenchmark.NET.MyBenchmarks.CleanCodeUseCase
{
    public static class SharedDataWithDummyData
    {
        public static DataTable ClothingData { get; } = new();

        static SharedDataWithDummyData()
        {
            ClothingData.Columns.Add("Name", typeof(string));
            ClothingData.Columns.Add("Material", typeof(string));
            ClothingData.Columns.Add("AvailableColors", typeof(List<string>));

            for(var i = 0; i< 100; i++)
            {
                var name = "cloth "+ i;
                var material = "material "+ i;
                var colors = new List<string> { "red", "green", "blue", "black", "white", "orange" };
                ClothingData.Rows.Add(name, material, colors);
            }
        }
    }
}
