using System;
using System.Collections.Generic;

namespace ClassLib
{
    class Class1 : Queue<int>
    {
        public ulong N_op { get; set; } = 0;
        public void Sorting()
        {
            //Создание двух вспомогательных очередей
            Queue<int> a1 = new Queue<int>();
            Queue<int> a2 = new Queue<int>();
            int i, j;
            int k = 1;
            N_op++;
            while (k < Count)
            {
                N_op += 2;
                while (Count != 0)
                {
                    N_op += 2;
                    //Заполнение двух очередей значениями
                    for (i = 0; i < k && Count != 0; i++)
                    {
                        N_op += 4 + 2;
                        a1.Enqueue(Peek());
                        N_op += 1;
                        Dequeue();
                    }

                    for (j = 0; j < k && Count != 0; j++)
                    {
                        N_op += 4 + 2;
                        a2.Enqueue(Peek());
                        N_op += 1;
                        Dequeue();
                    }
                }

                //Сортировка элементов пока не останется пустая очередь
                while (a1.Count != 0 && a2.Count != 0)
                {
                    N_op += 4;
                    i = 0;
                    N_op++;
                    j = 0;
                    N_op++;
                    while (i < k && j < k && a1.Count != 0 && a2.Count != 0)
                    {
                        N_op += 6;
                        if (a1.Peek() < a2.Peek())
                        {
                            N_op += 3;
                            Enqueue(a1.Peek());
                            N_op += 2;
                            a1.Dequeue();
                            N_op++;
                            i++;
                            N_op++;
                        }
                        else
                        {
                            Enqueue(a2.Peek());
                            N_op += 2;
                            a2.Dequeue();
                            N_op++;
                            j++;
                            N_op++;
                        }
                    }

                    //Если после прохода цикла остались элементы в одной из исходных очередей, то идет передача значений в основную
                    while (i < k && a1.Count != 0)
                    {
                        N_op += 3;
                        Enqueue(a1.Peek());
                        N_op += 2;
                        a1.Dequeue();
                        N_op++;
                        i++;
                        N_op++;
                    }

                    while (j < k && a2.Count != 0)
                    {
                        N_op += 3;
                        Enqueue(a2.Peek());
                        N_op += 2;
                        a2.Dequeue();
                        N_op++;
                        j++;
                        N_op++;
                    }
                }

                //Если после прохода цикла остались элементы в одной из исходных очередей, то идет передача значений в основную
                while (a1.Count != 0)
                {
                    N_op += 2;
                    Enqueue(a1.Peek());
                    N_op += 2;
                    a1.Dequeue();
                    N_op++;
                }

                while (a2.Count != 0)
                {
                    N_op += 2;
                    Enqueue(a2.Peek());
                    N_op += 2;
                    a2.Dequeue();
                    N_op++;
                }

                //Увеличение счеткика в два раза
                k *= 2;
                N_op++;
            }
        }
    }
}