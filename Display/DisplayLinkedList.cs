using System;
using DataStructure.List;

namespace DataStructure.Display
{
    public static class DisplayLinkedList
    {
        public static void DisplayDoublyLinkedList()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

            for (int i = 1; i <= 8; i++)
            {
                list.Insert(i);
            }

            if (list.ReadFirst())
            {
                Console.Write(list.CurrentData);

                while (list.ReadNext())
                {
                    Console.Write(", " + list.CurrentData);
                }

                while (list.ReadPrevious())
                {
                    Console.Write(", "+list.CurrentData);
                }

                Console.WriteLine();
            }
        }

        public static void DisplayCircuitLinkedList()
        {
            CircuitLinkedList<int> list = new CircuitLinkedList<int>();
            
            list.InsertFromLast(3);
            list.InsertFromLast(4);
            list.InsertFromLast(5);
            list.InsertFromFront(1);
            list.InsertFromFront(2);
            
            Console.WriteLine(list);

            list.RemoveData(data => data % 2 == 0);

            Console.WriteLine(list);
        }

        public static void DisplaySimpleLinkedListClass()
        {
            SimpleLinkedList<int> list = new SimpleLinkedList<int>();

            list.SetSortRule(SetArrayStandard);

            list.Insert(11);
            list.Insert(11);
            list.Insert(22);
            list.Insert(22);
            list.Insert(33);

            Console.WriteLine("현재 데이터의 수 : " + list.CountData);
            Console.WriteLine(list);

            list.RemoveData(22);

            Console.WriteLine("현재 데이터의 수 : " + list.CountData);
            Console.WriteLine(list);
        }

        public static bool SetArrayStandard(int left, int right)
        {
            return left > right;
        }

        public static void DisplaySimpleLinkedList()
        {
            Node<int> head = null;
            Node<int> tail = null;

            while (true)
            {
                Console.Write("Input Integer : ");
                int data = int.Parse(Console.ReadLine());

                if (data < 1) break;

                Node<int> newNode = new Node<int>
                {
                    Data = data,
                    NextNode = null
                };

                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    tail.NextNode = newNode;
                }

                tail = newNode;
            }

            Console.WriteLine("Print All Data");

            if (head == null)
            {
                Console.WriteLine("There is No Data");
            }
            else
            {
                Node<int> current = head;
                Console.Write(current.Data);

                while (current.NextNode != null)
                {
                    current = current.NextNode;
                    Console.Write(", " + current.Data);
                }

                Console.WriteLine();
            }

            Console.WriteLine("Remove All Node");

            if (head == null)
            {
                Console.WriteLine("There is No Data");
            }
            else
            {
                Node<int> toNextHead = head.NextNode;

                Console.WriteLine(head.Data+" 삭제");

                head = toNextHead;

                while (toNextHead != null)
                {
                    Console.WriteLine(head.Data+" 삭제");
                    toNextHead = toNextHead.NextNode;
                    head = toNextHead;
                }
            }
        }
    }
}
