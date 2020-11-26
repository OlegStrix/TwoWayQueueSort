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
            Class1 a = new Class1();
            int f,p;
            int digitsCounts = 500000;
            var time = new Stopwatch();
            Random rand = new Random();
            for (p = 0; p < 10; p++)
            {
                for (f = 0; f < digitsCounts; f++)
                {
                    a.Enqueue(rand.Next(9999999));
                }
                time.Start();
                a.Sorting();
                time.Stop();

                TimeSpan interval = TimeSpan.FromMilliseconds((double) time.ElapsedMilliseconds);
                Console.WriteLine($"Number of sortings: {p + 1}");
                Console.WriteLine($"\tNumber of sorted items: {digitsCounts}");
                Console.WriteLine($"\tSorting time (sec, ms): {interval.Seconds}, {interval.Milliseconds}");

                digitsCounts += 500000;
                a.Clear();
                time.Reset();
            }
        }
    }
}