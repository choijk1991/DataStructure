using System;
using DataStructure.Heap;

namespace DataStructure.Quest
{
    static class PriorityQueueQuest
    {
        public static void DisplayQuest9()
        {
            PriorityQueue<string> queue = new PriorityQueue<string>(100,
                (value1, value2) => value2.Length - value1.Length >= 0);

            queue.Enqueue("Good Morning!");
            queue.Enqueue("I'm a boy!");
            queue.Enqueue("Priority Queue!");
            queue.Enqueue("Do you like coffee!");
            queue.Enqueue("I'm so happy!");

            while (!queue.IsEmpty())
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}