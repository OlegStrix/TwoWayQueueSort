using System;
using System.Collections.Generic;
using ClassLib;
namespace TwoWayQueueSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> a = new Queue<int>();
            a.Enqueue(3);
            a.Enqueue(-2);
            a.Enqueue(1);

            Class1.Sorting(a);
        }
    }
}