using System;
using System.Collections;
using System.Collections.Generic;

namespace Weakest_Link
{
    class Program
    {
        static void Main(string[] args)
        {
            CircularLinkedList<int> myList = new CircularLinkedList<int>();

            Console.WriteLine("Введите количество игроков:");
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                myList.Add(i+1);
            }
            Console.WriteLine($"в игре игроков: {myList.Count}");

            Console.WriteLine("Выводим список игроков");
            foreach (var item in myList)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();

            bool weCanPlay = true;
            do
            {
                if (1 < myList.Count)
                {
                    myList.Remove(1);

                    Console.WriteLine($"в игре игроков осталось: {myList.Count}");

                    Console.WriteLine("Выводим список оставшихся игроков");
                    foreach (var item in myList)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Игра окончена. Невозможно вычеркнуть больше игроков.");
                    weCanPlay = false;
                }   
            } while (weCanPlay);

        }
    }

    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }

    public class CircularLinkedList<T> : IEnumerable<T>  // кольцевой связный список
    {
        Node<T> head; // головной/первый элемент
        Node<T> tail; // последний/хвостовой элемент
        int count;  // количество элементов в списке

        // добавление элемента
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            // если список пуст
            if (head == null)
            {
                head = node;
                tail = node;
                tail.Next = head;
            }
            else
            {
                node.Next = head;
                tail.Next = node;
                tail = node;
            }
            count++;
        }

        public void Remove(int elementToDelet)
        {
            Node<T> current = head;

            for (int i = 0; i < elementToDelet; i++)
            {
                tail = head;
                head = current.Next;
                current = head;
                
            }
                head = current.Next;
                tail.Next = current.Next;
                    
                count--;
        }

        public int Count { get { return count; } }

        IEnumerator IEnumerable.GetEnumerator()
        {
            Node<T> current = head;
            do
            {
                if (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
            while (current != head);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            do
            {
                if (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
            while (current != head);
        }
    }
}
            
