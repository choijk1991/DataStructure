using System.Linq;

namespace DataStructure.Stack
{
    public class InFixToPostFixConverter
    {
        private int GetOperatorPriority(char op)
        {
            char[] parenthesis = {'('};
            char[] provisional = {'+', '-'};
            char[] multiply = {'X', '/', '*'};

            if (parenthesis.Contains(op)) return 1;
            if (provisional.Contains(op)) return 2;
            if (multiply.Contains(op)) return 3;

            return 0;
        }

        private int CompareOperators(char left, char right)
        {
            int leftPriority = GetOperatorPriority(left);
            int rightPriority = GetOperatorPriority(right);

            if (leftPriority > rightPriority) return 1;
            if (leftPriority < rightPriority) return -1;

            return 0;
        }

        public string GetPostFix(string inFix)
        {
            ListStack<char> stack = new ListStack<char>();
            char[] postFixArray = new char[inFix.Length];
            int index = 0;

            for (var i = 0; i < inFix.Length; i=i+1)
            {
                char current = inFix[i];
                if (char.IsNumber(current))
                {
                    postFixArray[index++] = current;
                    continue;
                }

                if (current == '(')
                {
                    stack.Push(current);
                    continue;
                }

                if (current == ')')
                {
                    while (true)
                    {
                        char temp = stack.Pop();
                        if (temp == '(') break;
                        postFixArray[index++] = temp;
                    }

                    continue;
                }

                while (ContinueCompareOperators(stack, current))
                {
                    stack.Pop();
                    postFixArray[index++] = stack.CurrentData;
                }

                stack.Push(current);
            }

            while (!stack.IsEmpty())
            {
                stack.Pop();
                postFixArray[index++] = stack.CurrentData;
            }

            return new string(postFixArray).Replace('\0', ' ').Trim();
        }

        private bool ContinueCompareOperators(ListStack<char> stack, char current)
        {
            if (stack.IsEmpty()) return false;

            return CompareOperators(stack.Peek(), current) >= 0;
        }
    }
}