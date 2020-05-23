using System;
using DataStructure.Heap;

namespace DataStructure.Display
{
    static class DisplayHeap
    {
        public static void DisplayPriorityQueue()
        {
            PriorityQueue<char> queue = new PriorityQueue<char>(100, (value1, value2) => value2 - value1 < 0);

            queue.Enqueue('A');
            queue.Enqueue('B');
            queue.Enqueue('C');

            Console.WriteLine(queue.Dequeue());

            queue.Enqueue('A');
            queue.Enqueue('B');
            queue.Enqueue('C');

            Console.WriteLine(queue.Dequeue());

            while (!queue.IsEmpty())
            {
                Console.WriteLine(queue.Dequeue());
            }
        }

        public static void DisplayAdvancedHeap()
        {
            AdvancedHeap<char> heap = new AdvancedHeap<char>(
                100, 
                (value1, value2) => value2 - value1 < 0
            );

            heap.Insert('A');
            heap.Insert('B');
            heap.Insert('C');

            Console.WriteLine(heap.Delete());

            heap.Insert('A');
            heap.Insert('B');
            heap.Insert('C');

            Console.WriteLine(heap.Delete());

            while (!heap.IsEmpty())
            {
                Console.WriteLine(heap.Delete());
            }
        }

        public static void DisplayArrayHeap()
        {
            ArrayHeap<char> heap = new ArrayHeap<char>(100);

            heap.InsertValue('A', 1);
            heap.InsertValue('B', 2);
            heap.InsertValue('C', 3);

            Console.WriteLine(heap.Delete());

            heap.InsertValue('A', 1);
            heap.InsertValue('B', 2);
            heap.InsertValue('C', 3);

            Console.WriteLine(heap.Delete());

            while (!heap.IsEmpty())
            {
                Console.WriteLine(heap.Delete());
            }
        }
    }
}