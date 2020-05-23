using System;
using DataStructure.ComplexityAnalyze;
using DataStructure.Search;
using DataStructure.Tree;

namespace DataStructure.Display
{
    public static class DisplaySearch
    {
        public static void DisplayInterpolSearch()
        {
            int[] array = {1, 3, 5, 7, 9};

            int index = Search.Search.InterpolSearch(array, 0, array.Length - 1, 2);
            
            Console.WriteLine(index);
        }

        public static void DisplayBinarySearchTree3()
        {
            BinarySearchTree tree = new BinarySearchTree();
            int[] array = {1, 2, 3, 4, 5, 6, 7, 8, 9};

            foreach (int value in array)
            {
                tree.Insert(value);
            }

            Console.WriteLine("Root : " + tree.Root.Data);

            TreeNode<int> leftNode = tree.Root.LeftNode;
            TreeNode<int> rightNode = tree.Root.RightNode;

            while (true)
            {
                DisplaySubNodeData(leftNode, rightNode);

                leftNode = leftNode.LeftNode;
                rightNode = rightNode.RightNode;

                if (leftNode == null || rightNode == null) break;
            }
        }

        private static void DisplaySubNodeData(TreeNode<int> leftNode, TreeNode<int> rightNode)
        {
            Console.Write("Left : " + leftNode.Data + " ");
            Console.Write("Right : " + rightNode.Data);
            Console.WriteLine();
        }

        public static void DisplayBinarySearchTree2()
        {
            BinarySearchTree tree = new BinarySearchTree();
            int[] array = {5, 8, 1, 6, 4, 9, 3, 2, 7};

            foreach (int value in array)
            {
                tree.Insert(value);
            }

            tree.ShowAllElements();

            int[] deleteArray = {3, 8, 1, 6};

            foreach (int value in deleteArray)
            {
                tree.Remove(value);
                tree.ShowAllElements();
            }

            tree.ShowAllElements();
        }

        public static void DisplayBinarySearchTree()
        {
            BinarySearchTree tree = new BinarySearchTree();
            int[] array = {9, 1, 6, 2, 8, 3, 5};

            foreach (int value in array)
            {
                tree.Insert(value);
            }

            int[] delArray = {1, 4, 6, 7};

            foreach (int value in delArray)
            {
                DisplayNodeSearch(tree, value);
            }
        }
        
        private static void DisplayNodeSearch(BinarySearchTree tree, int value)
        {
            var node = tree.Search(value);

            if (node == null)
            {
                Console.WriteLine("탐색 실패 : " + value);
            }
            else
            {
                Console.WriteLine("탐색 성공 : " + node.Data);
            }
        }

        public static void DisplaySearchPerformance()
        {
            DisplayFindResultByLinear(new[] { 3, 5, 2, 4, 9 }, 4);
            DisplayFindResultByLinear(new[] { 3, 5, 2, 4, 9 }, 7);
            DisplayFindResultByBinary(new[] { 1, 3, 5, 7, 9 }, 7);
            DisplayFindResultByBinary(new[] { 1, 3, 5, 7, 9 }, 4);

            int[] array1 = new int[50];
            int[] array2 = new int[500];
            int[] array3 = new int[50000];

            DisplayFindResultByBinary(array1, 1);
            DisplayFindResultByBinary(array2, 2);
            DisplayFindResultByBinary(array3, 3);
        }

        /// <summary>
        /// 특정 배열에 대한 선형 탐색 수행 결과 반환
        /// </summary>
        private static void DisplayFindResultByLinear(int[] array, int target)
        {
            int findResult = array.SearchByLinear(target);
            string displayResult = findResult != -1 ? "Index Number of 4 : " + findResult : "Searching Failed";

            Console.WriteLine(displayResult);
        }

        private static void DisplayFindResultByBinary(int[] array, int target)
        {
            int findResult = array.SearchByBinary(target);
            string displayResult = findResult != -1 ? "Index Number of 4 : " + findResult : "Searching Failed";

            Console.WriteLine(displayResult);
        }
    }
}
