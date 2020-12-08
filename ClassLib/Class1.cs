using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Sockets;

namespace ClassLib
{
    class Ochered<T>
    {
        //Счетчик N_op для класса
        public ulong N_op1 { get; set; } = 0;
        
        class Node
        {
            public Node(T val = default(T), Node n = null)
            {
                Value = val;
                Next = n;
            }
            public Node Next;
            public T Value;
        }
        public Ochered()
        {
            top = null;
        }
        //Добавление элемента в очередь
        public void Enqueue(T value)
        {
            if (Empty == true)
            {
                N_op1 += 1 + 2;
                top = new Node(value);
            }
            else
            {
                Node tmp = top;
                N_op1++;
                while (tmp.Next != null)
                {
                    N_op1 += 2;
                    tmp = tmp.Next;
                    N_op1 += 2;
                }
                tmp.Next = new Node(value);
                N_op1 += 2;
            }
            Count++;
            N_op1++;
        }
        //Получение значения первого элемента очереди
        public T Peek() 
        {
            if (Empty == false)
            {
                N_op1++;
                return top.Value;
            }
            else
            {
                return default(T);
            }
        }
        //Удаление элемента очереди
        public T Dequeue()
        {
            if (Empty == false)
            {
                N_op1++;
                Node tmp = top;
                N_op1++;
                top = top.Next;
                N_op1 += 2;
                --Count;
                N_op1++;
                return tmp.Value;
            }
            else
            {
                return default(T);
            }
        }
        //Количество элементов очереди
        public int Count {get; private set;}
        //Проверка на наличие элементов очереди
        public bool Empty {get { return top == null; } }
        //Удаление всех элементов очереди
        public void Clean()
        {
            while (Empty != false)
            {
                Dequeue ();
                N_op1++;
            }
        }

        private Node top;
    }
    
    class Class1 : Queue<int>
    {
        //Счетчик N_op для класса
        public ulong N_op { get; set; } = 0;
        
        
        public void Sorting()
        {
            //Создание двух вспомогательных очередей

            Ochered<int> a1 = new Ochered<int>();
            Ochered<int> a2 = new Ochered<int>();
            
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