namespace ArrayManipulator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class ArrayManipulator
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<string> manipulator = new List<string>();
            manipulator.Add("default");

            while (manipulator[0] != "print")
            {
                manipulator = Console.ReadLine()
                    .Split(' ').ToList();
                switch (manipulator[0])
                {
                    case "add":

                        var index = int.Parse(manipulator[1]);
                        var number = int.Parse(manipulator[2]);
                        input.Insert(index, number);
                        break;


                    case "addMany":
                        var position = int.Parse(manipulator[1]);
                        for (int i = 2; i < manipulator.Count; i++)
                        {
                            var rangeToAdd = int.Parse(manipulator[i]);

                            input.Insert(position, rangeToAdd);
                            position++;
                        }
                        break;

                    case "contains":
                        var findNumber = int.Parse(manipulator[1]);

                        if (input.Contains(findNumber))
                        {
                            Console.WriteLine(input.IndexOf(findNumber));
                        }
                        else
                        {
                            Console.WriteLine("-1");
                        }
                        break;

                    case "remove":
                        var removeNumber = int.Parse(manipulator[1]);
                        input.RemoveAt(removeNumber);

                        break;

                    case "shift":

                        int shift = int.Parse(manipulator[1]);
                        for (int i = 0; i < shift; i++)
                        {
                            var old = input[0];
                            input.RemoveAt(0);
                            input.Add(old);
                        }
                        break;

                    case "sumPairs":

                        for (int i = 0; i < input.Count - 1; i++)
                        {
                            input[i] = ((input[i]) + (input[i + 1]));
                            input.RemoveAt(i + 1);
                        }

                        break;
                }
            }
            Console.WriteLine($"[{string.Join(", ", input)}]");
        }
    }
}
