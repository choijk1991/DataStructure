using System;

namespace DataStructure.ComplexityAnalyze
{
    public static class Searcher
    {
        /// <summary>
        /// 배열에 대한 선형 탐색 수행
        /// </summary>
        public static int SearchByLinear(this int[] array, int target)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != target) continue;

                return i;
            }

            return -1;
        }

        /// <summary>
        /// 배열에 대한 이진 탐색 수행
        /// </summary>
        public static int SearchByBinary(this int[] array, int target)
        {
            int start = 0;
            int end = array.Length - 1;
            int operationCount = 0;

            while (start <= end)
            {
                int middle = (start + end) / 2;

                if (target == array[middle]) return middle;

                if (target < array[middle])
                {
                    end = middle - 1;
                }

                if (target >= array[middle])
                {
                    start = middle + 1;
                }

                operationCount++;
            }

            Console.WriteLine("Operation Count : " + operationCount);

            return -1;
        }
    }
}