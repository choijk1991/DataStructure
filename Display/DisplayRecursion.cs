using System;
using DataStructure.Recursion;

namespace DataStructure.Display
{
    public static class DisplayRecursion
    {
        public static void DisplayHanoiTowerMoving(int frisbeeCount, char from, char by, char to)
        {
            if (frisbeeCount == 1)
            {
                Console.WriteLine("원반 " + frisbeeCount + " : " + from + " -> " + to);
                return;
            }

            DisplayHanoiTowerMoving(frisbeeCount - 1, from, to, by);
            Console.WriteLine("원반 " + frisbeeCount + " : " + from + " -> " + to);
            DisplayHanoiTowerMoving(frisbeeCount - 1, by, from, to);
        }

        public static void DisplayFibonacciValue()
        {
            int result = RecursionFunctions.GetFibonacciValue(7);

            Console.WriteLine(result);
        }

        public static void DisplayFactorial()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(i + "! = " + RecursionFunctions.GetFactorialValue(i));
            }
        }

        public static void DisplayFibonacciSequence()
        {
            for (int i = 1; i <= 15; i++)
            {
                if (i != 1)
                {
                    Console.Write(", ");
                }

                Console.Write(RecursionFunctions.GetFibonacciValue(i));
            }
        }

        public static void DisplayRecursiveBinarySearch()
        {
            int[] array = {1, 3, 5, 7, 9};

            DisplayRecursiveBinarySearch(array, 7);
            DisplayRecursiveBinarySearch(array, 9);
        }

        private static void DisplayRecursiveBinarySearch(int[] array, int target)
        {
            int result = array.SearchByRecursiveBinary(0, array.Length, target);

            if (result == -1)
            {
                Console.WriteLine("탐색 실패");
                return;
            }

            Console.WriteLine("해당 Index : " + result);
        }
    }
}