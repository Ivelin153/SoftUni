namespace MatchingBrackets
{
    using System;
    using System.Collections.Generic;
    public class BracketsMatcher
    {
        public static void Main()
        {
            var input = Console.ReadLine();


            var openingBrackets = new Stack<int>();

            for (int counter = 0; counter < input.Length; counter++)
            {
                if (input[counter] == '(')
                {
                    openingBrackets.Push(counter);
                }
                if (input[counter] == ')')
                {
                    var openBracketIndex = openingBrackets.Pop();
                    var lenght = counter - openBracketIndex + 1;
                    Console.WriteLine(input.Substring(openBracketIndex, lenght));
                }
            }
        }
    }
}
