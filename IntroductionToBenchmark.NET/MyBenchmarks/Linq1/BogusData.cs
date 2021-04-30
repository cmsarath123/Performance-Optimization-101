using Bogus;
using System.Collections.Generic;
using System.Linq;

namespace IntroductionToBenchmark.NET.MyBenchmarks.Linq1
{
    public class BogusData
    {
        private readonly Faker<Drink> _faker = new();
        private readonly List<Drink> _drinks;

        public BogusData()
        {
            _drinks = _faker.RuleFor(x => x.Name, faker => faker.Name.FullName())
                            .RuleFor(x => x.IsAlcoholic, faker => faker.Random.Bool())
                            .Generate(40000);
        }

        public int AlcoholicDrinksCountWithWhere()
        {
            return _drinks.Where(x => x.IsAlcoholic).Count();
        }

        public int AlcoholicDrinksCountWithDirectCount()
        {
            return _drinks.Count(x => x.IsAlcoholic);
        }

        public int AlcoholicDrinksCountWithForLoop()
        {
            int count = 0;
            for(int i = 0; i < _drinks.Count; i++ )
                if (_drinks[i].IsAlcoholic)
                    count++;
            return count;
        }

        public int AlcoholicDrinksCountWithForEachLoop()
        {
            int count = 0;
            foreach (Drink item in _drinks)
                if (item.IsAlcoholic)
                    count++;
                        
            return count;
        }

        public List<string> NonAlcoholicDrinkNamesForLoop()
        {
            List<string> brands = new();
            for (int i = 0; i < _drinks.Count; i++)
                if (!_drinks[i].IsAlcoholic)
                    brands.Add(_drinks[i].Name);
            
            return brands;
        }

        public List<string> NonAlcoholicDrinkNamesWhereSelectToList()
        {
            return _drinks.Where(x => !x.IsAlcoholic).Select(x => x.Name).ToList();
        }
    }
}