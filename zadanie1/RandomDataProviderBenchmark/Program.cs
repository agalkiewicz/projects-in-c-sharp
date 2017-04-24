using System;
using System.Diagnostics;
using Library;

namespace RandomDataProviderBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            uint number = 1;
            for (int i = 0; i < 7; i++)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                RandomDataProvider provider = new RandomDataProvider(
                    bookCount: number,
                    readerCount: number,
                    rentingCount: number);
                DataRepository repository = new DataRepository(provider);

                stopwatch.Stop();

                System.Console.Out.WriteLine(
                    "[{0}] Books/Readers/Rentings: {1}\t Time: {2} ms",
                    i,
                    number,
                    stopwatch.ElapsedMilliseconds);

                number *= 5;
            }

            System.Console.Out.WriteLine("FINISHED");
            Console.ReadKey();
        }
    }
}
