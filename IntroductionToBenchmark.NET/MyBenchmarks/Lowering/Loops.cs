namespace IntroductionToBenchmark.NET.MyBenchmarks.Lowering
{
    public class Loops
    {
        private static readonly string[] Names = new[] { "Vishnu", "Harsha", "Kavi", "Sarath" };

        public static void WhileLoop()
        {
            int i = 0;
            while (i < Names.Length)
            {
                var name = Names[i];
                _ = $"Name is {name}";
                i++;
            }
        }

        public static void ForLoop()
        {
            for (int i = 0; i < Names.Length; i++)
            {
                var name = Names[i];
                _ = $"Name is {name}";
            }
        }

        public static void ForEachLoop()
        {
            foreach (var name in Names)
            {
                _ = $"Name is {name}";
            }            
        }        
    }
}
