namespace RecursiveFibonacci
{
    using System;
    using System.Collections.Generic;
    public class Fibonacci
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var stack = new Stack<long>();
            stack.Push(1);
            stack.Push(1);

            for (int i = 0; i < n - 2; i++)
            {
                var previousNumber = stack.Pop();
                var nextNumber = stack.Peek() + previousNumber;

                stack.Push(previousNumber);
                stack.Push(nextNumber);
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
