using System;

namespace SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int spiceYielded = 0;
            int daysYielding = 0;

            if (yield >= 100)
            {
                while (yield >= 100)
                {
                    daysYielding++;
                    spiceYielded += yield - 26;
                    yield -= 10;
                }
                spiceYielded -= 26;
            }
            Console.WriteLine(daysYielding);
            Console.WriteLine(spiceYielded);

        }
    }
}
