using DataStructure.Heap;

namespace DataStructure.Sort
{
    static class Sort
    {
        public static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] <= array[j + 1]) continue;

                    int temp = array[j];

                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
        /*
        public static void RadixSort(int[] array, int num, int maxLen)
        {

        }
        */
        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int insertionValue = array[i];
                int j;

                for (j = i - 1; j >= 0; j--)
                {
                    if (array[j] <= insertionValue) break;

                    array[j + 1] = array[j];
                }

                array[j + 1] = insertionValue;
            }
        }

        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int maxIndex = i;

                for (int j = i + 1; j < array.Length; j++) // Minimum Value
                {
                    if (array[j] >= array[maxIndex]) continue;

                    maxIndex = j;
                }

                int temp = array[i];

                array[i] = array[maxIndex];
                array[maxIndex] = temp;
            }
        }

        public static void HeapSort(int[] array)
        {
            AdvancedHeap<int> heap = new AdvancedHeap<int>(100, (value1, value2) => value2 - value1 >= 0);

            foreach (int value in array)
            {
                heap.Insert(value);
            }

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = heap.Delete();
            }
        }
    }
}