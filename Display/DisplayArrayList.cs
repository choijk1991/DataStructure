using System;
using DataStructure.List;

namespace DataStructure.Display
{
    public static class DisplayArrayList
    {
        public static void DisplayArrayRead()
        {
            int[] array = new int[10];
            int readCount = 0;

            while (true)
            {
                Console.Write("Input Integer : ");
                int readData = int.Parse(Console.ReadLine());

                if (readData < 1) break;

                array[readCount++] = readData;
            }

            for (int i = 0; i < readCount; i++)
            {
                if (i != 0)
                {
                    Console.Write(", ");
                }

                Console.Write(array[i]);
            }
            Console.WriteLine();
        }

        public static void DisplayPoint()
        {
            ArrayList<Point> list = new ArrayList<Point>();

            list.InsertData(new Point(2, 1));
            list.InsertData(new Point(2, 2));
            list.InsertData(new Point(3, 1));
            list.InsertData(new Point(3, 2));

            Console.WriteLine("Current Data Count : " + list.DataCount);

            Console.WriteLine(list);
            DisplayDeletePointData(list);
            Console.WriteLine(list);
        }

        private static void DisplayDeletePointData(ArrayList<Point> list)
        {
            Point point = new Point(2, 0);

            if (!list.GetFirstData()) return;

            if (Point.ComparePoint(point, list.CurrentData) == 1)
            {
                list.RemoveData();
            }

            while (list.GetNextData())
            {
                if (Point.ComparePoint(point, list.CurrentData) == 1)
                {
                    list.RemoveData();
                }
            }
        }

        public static void DisplayArrayListExample()
        {
            ArrayList<int> list = new ArrayList<int>();

            list.InsertData(11);
            list.InsertData(11);
            list.InsertData(22);
            list.InsertData(22);
            list.InsertData(33);

            Console.WriteLine("Current Data Count : " + list.DataCount);

            Console.WriteLine(list);
            Console.WriteLine(list);

            Console.WriteLine("Current Data Count : " + list.DataCount);

            Console.WriteLine(list);
        }

        private static void DisplayDeleteData(ArrayList<int> list)
        {
            if (!list.GetFirstData()) return;

            int target = 22;

            if (list.CurrentData == target)
            {
                list.RemoveData();
            }

            while (list.GetNextData())
            {
                if (list.CurrentData == target)
                {
                    list.RemoveData();
                }
            }
        }
    }
}