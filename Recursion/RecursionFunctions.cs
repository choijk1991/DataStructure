using System;

namespace DataStructure.Recursion
{
    public static class RecursionFunctions
    {
        public static void CallRecursive(int round)
        {
            if (round == 0) return;

            Console.WriteLine("Recursive Call! " + round);

            CallRecursive(round - 1);
        }

        public static int GetFactorialValue(int start)
        {
            if (start == 0) return 1;

            return start * GetFactorialValue(start - 1);
        }

        public static int GetFibonacciValue(int inputValue)
        {
            Console.WriteLine("Fibonacci Parameter : " + inputValue);

            switch (inputValue)
            {
                case 1:
                    return 0;
                case 2:
                    return 1;
                default:
                    return GetFibonacciValue(inputValue - 1) + GetFibonacciValue(inputValue - 2);
            }
        }
        
        public static int SearchByRecursiveBinary(this int[] array, int first, int last, int target)
        {
            if (first > last) return -1;

            int middle = (first + last) / 2;

            if (array[middle] == target) return middle;
            if (target < array[middle]) return SearchByRecursiveBinary(array, first, middle - 1, target);

            return SearchByRecursiveBinary(array, middle + 1, last, target);
        }
    }
}
