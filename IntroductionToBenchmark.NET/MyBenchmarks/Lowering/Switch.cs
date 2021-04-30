using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToBenchmark.NET.MyBenchmarks.Lowering
{
    public class Switch
    {
        public void SwitchDemo()
        {
            var names = new[] { "Vishnu", "Harsha", "Kavi", "Sarath" };
            var random = new Random();
            var name = names[random.Next(0, 3)];
            switch (name)
            {
                case "Vishnu":
                    Console.WriteLine($"His name is {name}");
                    break;
                case "Harsha":
                    Console.WriteLine($"His name is {name}");
                    break;
                case "Kavi":
                    Console.WriteLine($"His name is {name}");
                    break;
                case "Sarath":
                    Console.WriteLine($"His name is {name}");
                    break;
                case "Kumar":
                    Console.WriteLine($"His name is {name}");
                    break;
                case "Bhanu":
                    Console.WriteLine($"His name is {name}");
                    break;
                case "Jeeva":
                    Console.WriteLine($"His name is {name}");
                    break;
                default:
                    Console.WriteLine($"His name is Gislen software");
                    break;
            }
        }
    }
}
