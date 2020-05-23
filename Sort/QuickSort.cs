namespace DataStructure.Sort
{
    static class QuickSort
    {
        public static void Sort(int[] array, int left, int right)
        {
            if (left > right) return;

            int pivot = Partition(array, left, right);

            Sort(array, left, pivot - 1);
            Sort(array, pivot + 1, right);
        }

        private static void Swap(int[] array, int index1, int index2)
        {
            int temp = array[index1];

            array[index1] = array[index2];
            array[index2] = temp;
        }

        private static int Partition(int[] array, int left, int right)
        {
            int pivot = array[left];
            int low = left + 1;
            int high = right;

            while (low <= high)
            {
                while (low <= right && pivot >= array[low])
                {
                    low++;
                }

                while (high >= left+1 && pivot <= array[high])
                {
                    high--;
                }

                if (low <= high)
                {
                    Swap(array, low, high);
                }
            }

            Swap(array, left, high);

            return high;
        }
    }
}