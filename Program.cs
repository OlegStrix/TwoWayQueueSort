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
            //Количество элементов очереди
            int digitsCounts = 500000; 
            var time = new Stopwatch();
            Random rand = new Random();
            for (int p = 0; p < 10; p++)
            {
                //Заполнение очереди рандомными числами 
                for (int f = 0; f < digitsCounts; f++)
                {
                    a.Enqueue(rand.Next(9999999));
                }
                //Начало отсчета времени
                time.Start();
                //Вызов сортировки
                a.Sorting();
                //Конец отсчета времени
                time.Stop();
                
                
                //Представление интервала времени в удобном формате
                TimeSpan interval = TimeSpan.FromMilliseconds((double) time.ElapsedMilliseconds);
                Console.WriteLine($"Number of sortings: {p + 1}");
                Console.WriteLine($"\tNumber of sorted items: {digitsCounts}");
                Console.WriteLine($"\tSorting time (sec, ms): {interval.Seconds}, {interval.Milliseconds}\n");
                //Отчистка очереди
                a.Clear();
                //Увеличение количества элементов очереди
                digitsCounts += 500000;
                //Обнуляем время
                time.Reset();
            }
        }
    }
}