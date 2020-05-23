using System;
using DataStructure.Stack;

namespace DataStructure.Display
{
    public static class DisplayStack
    {
        public static void DisplayCalculationInfix()
        {
            Calculator calculator = new Calculator();

            string form1 = "1+2*3";
            string form2 = "(1+2)*3";
            string form3 = "((1-2)+3)*(5-2)";

            Console.WriteLine(form1 + " = " + calculator.CalculateInfix(form1));
            Console.WriteLine(form2 + " = " + calculator.CalculateInfix(form2));
            Console.WriteLine(form3 + " = " + calculator.CalculateInfix(form3));
        }

        public static void DisplayCalculationPostfix()
        {
            Calculator calculator = new Calculator();

            Console.WriteLine(calculator.CalculatePostFix("42*8+"));
            Console.WriteLine(calculator.CalculatePostFix("123+*4/"));
        }

        public static void DisplayInfixToPostFix()
        {
            InFixToPostFixConverter converter = new InFixToPostFixConverter();

            Console.WriteLine(converter.GetPostFix("1+2*3"));
            Console.WriteLine(converter.GetPostFix("(1+2)X3"));
            Console.WriteLine(converter.GetPostFix("((1-2)+3)X(5-2)"));
        }

        public static void DisplayArrayStack()
        {
            ArrayStack<int> stack = new ArrayStack<int>();

            for (int i = 1; i <= 5; i++)
            {
                stack.Push(i);
            }

            while (!stack.IsEmpty())
            {
                stack.Pop();
                Console.Write(stack.CurrentData + " ");
            }
        }

        public static void DisplayListStack()
        {
            ListStack<int> stack = new ListStack<int>();

            for (int i = 1; i <= 5; i++)
            {
                stack.Push(i);
            }

            while (!stack.IsEmpty())
            {
                stack.Pop();
                Console.Write(stack.CurrentData + " ");
            }
        }
    }
}
