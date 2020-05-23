using System;
using DataStructure.Stack;
using DataStructure.Tree;

namespace DataStructure.Display
{
    public static class DisplayTree
    {
        public static void DisplayBinaryTree()
        {
            TreeNode<int> node1 = new TreeNode<int> {Data = 1};
            TreeNode<int> node2 = new TreeNode<int> {Data = 2};
            TreeNode<int> node3 = new TreeNode<int> {Data = 3};
            TreeNode<int> node4 = new TreeNode<int> {Data = 4};

            node1.LeftNode = node2;
            node1.RightNode = node3;
            node2.LeftNode = node4;

            Console.WriteLine(node1.LeftNode.Data);
            Console.WriteLine(node1.LeftNode.LeftNode.Data);
        }

        public static void DisplayExpressionTree()
        {
            string expression = "12+7*";

            TreeNode<char> expTree = DisplayTree.MakeExpressionTree(expression);
        }
        
        public static TreeNode<char> MakeExpressionTree(string expression)
        {
            ListStack<TreeNode<char>> stack = new ListStack<TreeNode<char>>();

            foreach (char character in expression)
            {
                TreeNode<char> currentNode = new TreeNode<char>();

                if (char.IsDigit(character))
                {
                    currentNode.Data = character;
                }
                else
                {
                    currentNode.RightNode = new TreeNode<char> { Data = stack.Pop().Data };
                    currentNode.LeftNode = new TreeNode<char> { Data = stack.Pop().Data };

                    currentNode.Data = character;
                }

                stack.Push(currentNode);
            }

            return stack.Pop();
        }

    }
}
