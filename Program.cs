using System;
using System.Collections.Generic;
namespace TwoWayQueueSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> a = new Queue<int>();
            a.Enqueue(3);
            a.Enqueue(-2);
            a.Enqueue(10);

            foreach (var x in a)
            {
                Console.Write(x + " ");
            }
        }
    }
}