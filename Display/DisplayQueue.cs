using System;
using DataStructure.Queue;

namespace DataStructure.Display
{
    public static class DisplayQueue
    {
        public static void DisplayDeque()
        {
            Deque<int> deque = new Deque<int>();

            deque.AddToFirst(3);
            deque.AddToFirst(2);
            deque.AddToFirst(1);

            deque.AddToLast(4);
            deque.AddToLast(5);
            deque.AddToLast(6);

            while (!deque.IsEmpty())
            {
                Console.Write(deque.RemoveFromFirst()+" ");
            }

            Console.WriteLine();

            deque.AddToFirst(3);
            deque.AddToFirst(2);
            deque.AddToFirst(1);

            deque.AddToLast(4);
            deque.AddToLast(5);
            deque.AddToLast(6);

            while (!deque.IsEmpty())
            {
                Console.Write(deque.RemoveFromLast() + " ");
            }

            Console.WriteLine();
        }

        public static void DisplayHamburgerSimulation()
        {
            ListBasedQueue<Hamburger> simulationQueue = new ListBasedQueue<Hamburger>();

            Hamburger cheese = new Hamburger("cheese", 12);
            Hamburger hotBeef = new Hamburger("hotBeef", 15);
            Hamburger doubleB = new Hamburger("doubleB", 24);

            int orderTerm = 15;
            int procedureStatus = 0;

            for (int second = 0; second < 3600; second++)
            {
                if (second % orderTerm == 0)
                {
                    Random random = new Random();
                    switch (random.Next(1, 4))
                    {
                        case 1:
                            simulationQueue.Enqueue(cheese);
                            cheese.Count++;
                            break;
                        case 2:
                            simulationQueue.Enqueue(hotBeef);
                            hotBeef.Count++;
                            break;
                        case 3:
                            simulationQueue.Enqueue(doubleB);
                            doubleB.Count++;
                            break;
                    }
                }

                if (procedureStatus <= 0 && simulationQueue.IsEmpty())
                {
                    procedureStatus = simulationQueue.Dequeue().Term;
                }

                procedureStatus--;
            }

            Console.WriteLine("Simulation Report");
            Console.WriteLine("Cheese : "+cheese.Count);
            Console.WriteLine("Bulgogi : "+hotBeef.Count);
            Console.WriteLine("Double : "+doubleB.Count);
        }

        public static void DisplayCircularQueue()
        {
            CircularBasedQueue<int> basedQueue = new CircularBasedQueue<int>();

            for (int i = 1; i <= 5; i++)
            {
                basedQueue.Enqueue(i);
            }

            while (!basedQueue.IsEmpty())
            {
                Console.Write(basedQueue.Dequeue()+" ");
            }
        }

        public static void DisplayListQueue()
        {
            ListBasedQueue<int> basedQueue = new ListBasedQueue<int>();

            for (int i = 1; i <= 5; i++)
            {
                basedQueue.Enqueue(i);
            }

            while (!basedQueue.IsEmpty())
            {
                Console.Write(basedQueue.Dequeue() + " ");
            }
        }
    }
}
