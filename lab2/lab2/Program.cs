using System;
using System.Diagnostics;

namespace lab2
{
    class Program
    {
        private static readonly int lenArray = 50000000;
        private static readonly int[] colsThread = new int[] { 1, 2, 3, 4, 8, 16, 32};

        static void Main(string[] args)
        {
            TestThreads();
        }

        private static void TestThreads()
        {
            foreach (int j in colsThread)
            {
                ThreadSum threadSum = new ThreadSum(lenArray, j);
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                threadSum.wave();
                stopwatch.Stop();
                TimeSpan time = stopwatch.Elapsed;
                Console.WriteLine($"Sum with {j} threads is {threadSum.getArray()[0]}. This continues {time.TotalMilliseconds} milliseconds");
            }
        }
    }
}
