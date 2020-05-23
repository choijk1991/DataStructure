namespace DataStructure.Sort
{
    static class MergeSort
    {
        public static void Sort(int[] array, int left, int right)
        {
            if (left >= right) return;

            int middle = (left + right) / 2;

            Sort(array, left, middle);
            Sort(array, middle+1, right);
            MergeBothArea(array, left, middle, right);
        }

        private static void MergeBothArea(int[] array, int left, int middle, int right)
        {
            int frontIndex = left;
            int rearIndex = middle + 1;
            int[] sortArray = new int[right + 1];
            int startIndex = left;

            while (frontIndex <= middle && rearIndex <= right)
            {
                if (array[frontIndex] <= array[rearIndex])
                {
                    sortArray[startIndex] = array[frontIndex++];
                }
                else
                {
                    sortArray[startIndex] = array[rearIndex++];
                }

                startIndex++;
            }

            if (frontIndex > middle)
            {
                for (int i = rearIndex; i <= right; i++, startIndex++)
                {
                    sortArray[startIndex] = array[i];
                }
            }
            else
            {
                for (int i = frontIndex; i <= middle; i++, startIndex++)
                {
                    sortArray[startIndex] = array[i];
                }
            }

            for (int i = left; i <= right; i++)
            {
                array[i] = sortArray[i];
            }
        }
    }
}