namespace SimpleTextEditor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            var numberOfLines = int.Parse(Console.ReadLine());

            var currentString = String.Empty;
            var previousVersion = new Stack<string>();

            previousVersion.Push(currentString);

            for (int i = 0; i < numberOfLines; i++)
            {
                var input = Console.ReadLine()
                    .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                switch (input[0])
                {
                    case "1":
                        currentString += input[1];
                        previousVersion.Push(currentString);
                        break;

                    case "2":
                        var lenght = int.Parse(input[1]);
                        currentString = currentString.Remove(currentString.Length - lenght, lenght);
                        previousVersion.Push(currentString);
                        break;
                    case "3":
                        var index = int.Parse(input[1]) - 1;
                        Console.WriteLine(currentString[index]);
                        break;
                    case "4":
                        previousVersion.Pop();
                        currentString = previousVersion.Peek();
                        break;
                }
            }
        }
    }
}
