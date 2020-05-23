using System;
using System.Linq;

namespace DataStructure.Stack
{
    public class Calculator
    {
        private readonly InFixToPostFixConverter _converter;

        public Calculator()
        {
            _converter = new InFixToPostFixConverter();
        }

        public int CalculateInfix(string inFixForm)
        {
            string postFix = _converter.GetPostFix(inFixForm);

            return CalculatePostFix(postFix);
        }

        public int CalculatePostFix(string postFixForm)
        {
            ListStack<int> stack = new ListStack<int>();

            foreach (var current in postFixForm)
            {
                if (char.IsDigit(current))
                {
                    stack.Push(int.Parse(current.ToString()));
                    continue;
                }

                int right = stack.Pop();
                int left = stack.Pop();
                int result = Calculate(left, current, right);

                stack.Push(result);
            }

            return stack.Pop();
        }

        private int Calculate(int left, char op, int right)
        {
            if (op == '+') return left + right;
            if (op == '-') return left - right;
            if (op == '/') return left / right;
            if (new[] {'X', 'x', '*'}.Contains(op)) return left * right;

            throw new Exception("Invalid Operator");
        }
    }
}