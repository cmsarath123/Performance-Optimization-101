using Bogus;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace IntroductionToBenchmark.NET.MyBenchmarks.CleanCodeUseCase
{
    public static class SharedDataWithBogus
    {
        private static readonly Faker Faker = new() {
            Random = new Randomizer(420)
        };

        public static DataTable ClothingData { get; } = new();

        static SharedDataWithBogus()
        {
            ClothingData.Columns.Add("Name", typeof(string));
            ClothingData.Columns.Add("Material", typeof(string));
            ClothingData.Columns.Add("AvailableColors", typeof(List<string>));

            for(var i = 0; i< 100; i++)
            {
                var name = Faker.Commerce.ProductName();
                var material = Faker.Commerce.ProductMaterial();
                var numberOfColors = Faker.Random.Int(1, 6);
                var colors = Enumerable.Range(0, numberOfColors)
                    .Select(x => Faker.Commerce.Color()).ToList();

                ClothingData.Rows.Add(name, material, colors);
            }
        }
    }
}
