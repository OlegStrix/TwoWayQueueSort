using System;
using System.Collections.Generic;
namespace ClassLib
{
    class Class1 : Queue<int>
    {
        public void Sorting()
        {
            Queue<int> a1 = new Queue<int>();
            Queue<int> a2 = new Queue<int>();
            int i, j;
            var k = 1;
            while (k < Count)
            {
                while (Count != 0)
                {
                    for (i = 0; i < k && Count != 0; i++)
                    {
                        a1.Enqueue(Peek());
                        Dequeue();
                    }

                    for (j = 0; j < k && Count != 0; j++)
                    {
                        a2.Enqueue(Peek());
                        Dequeue();
                    }
                }

                while (a1.Count != 0 && a2.Count != 0)
                {
                    i = 0;
                    j = 0;
                    while (i < k && j < k && a1.Count != 0 && a2.Count != 0)
                    {
                        if (a1.Peek() < a2.Peek())
                        {
                            Enqueue(a1.Peek());
                            a1.Dequeue();
                            i++;
                        }
                        else
                        {
                            Enqueue(a2.Peek());
                            a2.Dequeue();
                            j++;
                        }
                    }

                    while (i < k && a1.Count != 0)
                    {
                        Enqueue(a1.Peek());
                        a1.Dequeue();
                        i++;
                    }

                    while (j < k && a2.Count != 0)
                    {
                        Enqueue(a2.Peek());
                        a2.Dequeue();
                        j++;
                    }
                }

                while (a1.Count != 0)
                {
                    Enqueue(a1.Peek());
                    a1.Dequeue();
                }

                while (a2.Count != 0)
                {
                    Enqueue(a2.Peek());
                    a2.Dequeue();
                }
                k *= 2;
            }
        }
    }
}