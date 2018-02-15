namespace PredicatParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var people = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.None);

            var commandInput = Console.ReadLine();

            while (commandInput != "Party!")
            {
                var command = commandInput
                    .Split(new char[] { ' ' }, StringSplitOptions.None);

                var toDo = command[0];
                var criteria = command[1];
                var criteriaII = char.Parse(command[2]);


                switch (criteria)
                {
                    case "StartsWith":

                        break;

                    case "EndsWith":

                        break;

                    case "Length":

                        break;
                    default:
                        break; ;
                }

                Action<string[], string, char> action = (;
                {
                    switch (toDo)
                    {
                        case "Remove":

                            break;

                        case "Double":

                            break;

                        default:
                            break;
                    }
                }
            }
        }
    }
}
