using System;
using System.Collections.Generic;
using System.Diagnostics;
using ClassLib;
namespace TwoWayQueueSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> a = new Queue<int>();
            int f,p;
            int DigitsCounts = 500000;
            var time = new Stopwatch();
            Random rand = new Random();
            for (p = 0; p < 10; p++)
            {
                for (f = 0; f < DigitsCounts; f++)
                {
                    a.Enqueue(rand.Next(9999999));
                }
                time.Start();
                Class1.Sorting(a);
                time.Stop();

                TimeSpan interval = TimeSpan.FromMilliseconds((double) time.ElapsedMilliseconds);
                Console.WriteLine($"Number of sortings: {p + 1}");
                Console.WriteLine($"\tNumber of sorted items: {DigitsCounts}");
                Console.WriteLine($"\tSorting time (sec, ms): {interval.Seconds}, {interval.Milliseconds}");
                Console.WriteLine($"\tN_op {Class1.N_op}\n");
                
                DigitsCounts += 500000;
                Class1.N_op = 0;
                a.Clear();
                time.Reset();
            }
        }
    }
}