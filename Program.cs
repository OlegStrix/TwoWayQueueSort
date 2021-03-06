﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using ClassLib;
namespace TwoWayQueueSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //Количество элементов очереди
            int digitsCounts = 2000;
            Class1 a = new Class1();
            Ochered<int> b = new Ochered<int>();
            //Создание объекта класса
            var time = new Stopwatch();
            Random rand = new Random();
            for (int p = 0; p < 10; p++)
            {
                //Заполнение очереди рандомными числами 
                for (int f = 0; f < digitsCounts; f++)
                {
                    a.Enqueue(rand.Next(999999));
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
                Console.WriteLine($"\tSorting time (sec, ms): {interval.Seconds}, {interval.Milliseconds}");
                Console.WriteLine($"\tN_op = {a.N_op }\n");
                //Отчистка очереди
                a.Clear();
                //Увеличение количества элементов очереди
                digitsCounts += 2000;
                //Обнуляем время
                time.Reset();
            }
            Console.ReadKey();
        }
    }
}