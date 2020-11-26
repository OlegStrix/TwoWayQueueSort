using System;
using System.Collections.Generic;
namespace ClassLib
{
    public static class Class1
    {
        public static ulong N_op { get; set; } = 0;
        public static void Sorting(Queue<int> a)
        {
            N_op++;
            Queue<int> a1 = new Queue<int>();
            Queue<int> a2 = new Queue<int>();
            int i, j;
            int k = 1;
            N_op++;
            while (k < a.Count)
            {
                N_op += 2;
                while (a.Count != 0)
                {
                    N_op += 2;
                    for (i = 0; i < k && a.Count != 0; i++)
                    {
                        N_op += 4 + 2 + 1;
                        a1.Enqueue(a.Peek());
                        a.Dequeue();
                    }

                    for (j = 0; j < k && a.Count != 0; j++)
                    {
                        N_op += 4 + 2 + 1;
                        a2.Enqueue(a.Peek());
                        a.Dequeue();
                    }
                }

                while (a1.Count != 0 && a2.Count != 0)
                {
                    N_op += 4;
                    i = 0;
                    j = 0;
                    N_op += 2;
                    while (i < k && j < k && a1.Count != 0 && a2.Count != 0)
                    {
                        N_op += 6;
                        if (a1.Peek() < a2.Peek())
                        {
                            N_op += 3;
                            a.Enqueue(a1.Peek());
                            N_op += 2;
                            a1.Dequeue();
                            N_op++;
                            i++;
                            N_op++;
                        }
                        else
                        {
                            a.Enqueue(a2.Peek());
                            N_op += 2;
                            a2.Dequeue();
                            N_op++;
                            j++;
                            N_op++;
                        }
                    }

                    while (i < k && a1.Count != 0)
                    {
                        N_op += 3;
                        a.Enqueue(a1.Peek());
                        N_op += 2;
                        a1.Dequeue();
                        N_op++;
                        i++;
                        N_op++;
                    }

                    while (j < k && a2.Count != 0)
                    {
                        N_op += 3;
                        a.Enqueue(a2.Peek());
                        N_op += 2;
                        a2.Dequeue();
                        N_op++;
                        j++;
                        N_op++;
                    }
                }

                while (a1.Count != 0)
                {
                    N_op += 2;
                    a.Enqueue(a1.Peek());
                    N_op += 2;
                    a1.Dequeue();
                    N_op++;
                }

                while (a2.Count != 0)
                {
                    N_op += 2;
                    a.Enqueue(a2.Peek());
                    N_op += 2;
                    a2.Dequeue();
                    N_op++;
                }

                k *= 2;
                N_op++;
            }
        }
    }
}