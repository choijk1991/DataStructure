using System;
using DataStructure.Tree;

namespace DataStructure.Search
{
    class BinarySearchTree
    {
        public TreeNode<int> Root { private set; get; }

        public TreeNode<int> Search(int value)
        {
            TreeNode<int> current = Root;

            while (current != null)
            {
                if (value == current.Data) return current;

                current = value < current.Data ? current.LeftNode : current.RightNode;
            }

            return null;
        }

        public TreeNode<int> Remove(int value)
        {
            TreeNode<int> virtualRoot = new TreeNode<int>();
            
            virtualRoot.RightNode = virtualRoot;
            
            TreeNode<int> parent = virtualRoot;
            TreeNode<int> current = Root;

            while (current != null && current.Data != value)
            {
                parent = current;
                current = value < current.Data ? current.LeftNode : current.RightNode;
            }

            if (current == null) return null;

            SwitchChildNode(current, parent);
            ReBalance();

            return current;
        }

        public void ShowAllElements()
        {
            InorderTraverse(Root);
            Console.WriteLine();
        }

        private void InorderTraverse(TreeNode<int> node)
        {
            if (node == null) return;

            InorderTraverse(node.LeftNode);

            Console.Write(node.Data+" ");

            InorderTraverse(node.RightNode);
        }

        public void SwitchChildNode(TreeNode<int> target, TreeNode<int> parent)
        {
            switch (target.CountChildren())
            {
                case 0:
                    if (parent.LeftNode == target)
                    {
                        parent.LeftNode = null;
                    }
                    else
                    {
                        parent.RightNode = null;
                    }
                    break;
                case 1:
                    TreeNode<int> targetChildren = target.LeftNode ?? target.RightNode;

                    if (parent.LeftNode == target)
                    {
                        parent.LeftNode = targetChildren;
                    }
                    else
                    {
                        parent.RightNode = targetChildren;
                    }
                    break;
                case 2:
                    TreeNode<int> alternation = target.RightNode;
                    TreeNode<int> alterParent = target;

                    while (alternation.LeftNode != null)
                    {
                        alterParent = alternation;
                        alternation = alternation.LeftNode;
                    }

                    int targetData = target.Data;

                    target.Data = alternation.Data;

                    if (alterParent.LeftNode == alternation)
                    {
                        alterParent.LeftNode = alternation.RightNode;
                    }
                    else
                    {
                        alterParent.RightNode = alternation.RightNode;
                    }

                    target = alternation;
                    target.Data = targetData;

                    break;
            }
        }

        public void Insert(int value)
        {
            TreeNode<int> currentNode = Root;
            TreeNode<int> parentNode = null;

            while (currentNode != null)
            {
                if (value.Equals(currentNode.Data)) return;

                parentNode = currentNode;

                currentNode = value < currentNode.Data ? currentNode.LeftNode : currentNode.RightNode;
            }

            TreeNode<int> newNode = new TreeNode<int> {Data = value};

            if (parentNode != null)
            {
                if (value < parentNode.Data)
                {
                    parentNode.LeftNode = newNode;
                }
                else
                {
                    parentNode.RightNode = newNode;
                }
            }
            else
            {
                Root = newNode;
            }

            ReBalance();
        }

        private void ReBalance()
        {
            int difference = GetHeightDifference(Root);

            if (difference > 1)
            {
                Root = GetHeightDifference(Root.LeftNode) > 0 ? RotateByLeftLeft(Root) : RotateByLeftRight(Root);
            }
            else if (difference < -1)
            {
                Root = GetHeightDifference(Root.RightNode) < 0 ? RotateByRightRight(Root) : RotateByRightLeft(Root);
            }
        }

        private TreeNode<int> RotateByRightRight(TreeNode<int> node)
        {
            TreeNode<int> parent = node;
            TreeNode<int> child = parent.RightNode;

            parent.RightNode = child.LeftNode;
            child.LeftNode = parent;

            return child;
        }

        private TreeNode<int> RotateByRightLeft(TreeNode<int> node)
        {
            TreeNode<int> parent = node;
            TreeNode<int> child = parent.RightNode;

            parent.RightNode = RotateByLeftLeft(child);

            return RotateByRightRight(parent);
        }

        private TreeNode<int> RotateByLeftLeft(TreeNode<int> node)
        {
            TreeNode<int> parent = node;
            TreeNode<int> child = parent.LeftNode;

            parent.LeftNode = child.RightNode;
            child.RightNode = parent;

            return child;
        }

        private TreeNode<int> RotateByLeftRight(TreeNode<int> node)
        {
            TreeNode<int> parent = node;
            TreeNode<int> child = parent.LeftNode;

            parent.LeftNode = RotateByRightRight(child);

            return RotateByLeftLeft(parent);
        }

        private int GetHeightDifference(TreeNode<int> node)
        {
            if (node == null) return 0;

            int leftSubHeight = GetNodeHeight(node.LeftNode);
            int rightSubHeight = GetNodeHeight(node.RightNode);

            return leftSubHeight - rightSubHeight;
        }

        private int GetNodeHeight(TreeNode<int> node)
        {
            if (node == null) return 0;

            int heightLeft = GetNodeHeight(node.LeftNode);
            int rightHeight = GetNodeHeight(node.RightNode);

            return heightLeft > rightHeight ? heightLeft + 1 : rightHeight + 1;
        }
    }
}