
namespace BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParentheses
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var areBalanced = "YES";

            var openingParentheses = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(' || input[i] == '{' || input[i] == '[')
                {
                    openingParentheses.Push(input[i]);
                }
                else if ((input[i] == ')' || input[i] == '}' || input[i] == ']'))
                {
                    if (openingParentheses.Count == 0)
                    {
                        areBalanced = "NO";
                    }
                    else if ((input[i] == ')' && openingParentheses.Pop() != '(') || (input[i] == ']' && openingParentheses.Pop() != '[') || (input[i] == '}' && openingParentheses.Pop() != '{'))
                    {
                        areBalanced = "NO";
                    }
                }
            }

            Console.WriteLine(areBalanced);
        }
    }
}