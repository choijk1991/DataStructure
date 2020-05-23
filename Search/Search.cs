namespace DataStructure.Search
{
    static class Search
    {
        public static int InterpolSearch(int[] array, int first, int last, int target)
        {
            if (array[first] > target) return -1;
            if (array[last] < target) return -1;

            int middle = (int) ((double) (target - array[first]) / (array[last] - array[first]) * (last - first) + first);

            if (array[middle] == target) return middle;
            if (target < array[middle]) return InterpolSearch(array, first, middle - 1, target);

            return InterpolSearch(array, middle + 1, last, target);
        }
    }
}