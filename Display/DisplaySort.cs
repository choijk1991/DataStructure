using System;
using DataStructure.Sort;

namespace DataStructure.Display
{
    static class DisplaySort
    {
        public static void DisplayBubbleSort()
        {
            int[] array = {3, 2, 4, 1};

            Sort.Sort.BubbleSort(array);

            foreach (var element in array)
            {
                Console.WriteLine(element);
            }
        }

        public static void DisplayQuickSort()
        {
            int[] array = {5, 1, 3, 7, 9, 2, 4, 6, 8};
            //int[] array = {3, 3, 3};

            QuickSort.Sort(array, 0, array.Length - 1);

            foreach (int value in array)
            {
                Console.WriteLine(value);
            }
        }

        public static void DisplayMergeSort()
        {
            int[] array = {3, 2, 4, 1, 7, 6, 5};

            MergeSort.Sort(array, 0, array.Length);

            foreach (var value in array)
            {
                Console.WriteLine(value);
            }
        }

        public static void DisplayHeapSort()
        {
            int[] array = {3, 4, 2, 1};

            Sort.Sort.HeapSort(array);

            foreach (int value in array)
            {
                Console.WriteLine(value);
            }
        }

        public static void DisplayInsertionSort()
        {
            int[] array = {5, 3, 2, 4, 1};

            Sort.Sort.InsertionSort(array);

            foreach (var element in array)
            {
                Console.WriteLine(element);
            }
        }

        public static void DisplaySelectionSort()
        {
            int[] array = { 3, 2, 4, 1 };

            Sort.Sort.SelectionSort(array);

            foreach (var element in array)
            {
                Console.WriteLine(element);
            }
        }
    }
}