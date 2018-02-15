namespace HotPotato
{
    using System;
    using System.Collections.Generic;

    public class HotPotato
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ');
            var tossLimit = int.Parse(Console.ReadLine());

            var queue = new Queue<string>(input);


            while (queue.Count != 1)
            {
                for (int tossCounter = 1; tossCounter < tossLimit; tossCounter++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");

        }
    }
}
