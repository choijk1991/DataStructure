using System;
using DataStructure.Stack;

namespace DataStructure.Quest
{
    public static class StackQuest
    {
        public static void DisplayQuest1()
        {
            CircuitListStack<int> stack = new CircuitListStack<int>();

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