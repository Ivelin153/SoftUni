namespace HitList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KillEm
    {
        public static void Main()
        {
            var targetInfoIndex = int.Parse(Console.ReadLine());

            var info = new Dictionary<string, Dictionary<string, string>>();
            var input = Console.ReadLine();
            while (input != "end transmissions")
            {
                var data = input.Split(new char[] { '=', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
                var personName = data[0];
                if (!info.ContainsKey(personName))
                {
                    info[personName] = new Dictionary<string, string>();
                }

                for (int counter = 1; counter < data.Length; counter += 2)
                {
                    var currentData = data[counter];
                    if (!info[personName].ContainsKey(currentData))
                    {
                        info[personName].Add(data[counter], data[counter + 1]);
                    }
                    else
                    {
                        info[personName].Remove(data[counter]);
                        info[personName].Add(data[counter], data[counter + 1]);
                    }

                }
                input = Console.ReadLine();
            }

            var command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var currentInfoIndex = 0;
            foreach (var person in info.Where(k => k.Key == command[1]))
            {
                Console.WriteLine($"Info on {person.Key}:");

                foreach (var data in person.Value.OrderBy(k => k.Key))
                {
                    currentInfoIndex += data.Key.Length;
                    currentInfoIndex += data.Value.Length;
                    Console.WriteLine($"---{data.Key}: {data.Value}");
                }
                Console.WriteLine($"Info index: {currentInfoIndex}");
            }

            if (currentInfoIndex >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetInfoIndex - currentInfoIndex} more info.");
            }

        }
    }
}
