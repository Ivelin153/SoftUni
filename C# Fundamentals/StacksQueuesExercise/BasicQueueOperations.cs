namespace BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class QueueOperations
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var elementsToEnqueue = input[0];
            var elementsToDequeue = input[1];
            var elementToFind = input[2];

            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var queue = new Queue<int>();

            for (int i = 0; i < elementsToEnqueue; i++)
            {
                queue.Enqueue(numbers[i]);
            }
            for (int i = 0; i < elementsToDequeue; i++)
            {
                queue.Dequeue();
            }
            if (queue.Contains(elementToFind))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count > 0)
                {
                    Console.WriteLine(queue.OrderBy(x => x).First());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }

        }
    }
}
