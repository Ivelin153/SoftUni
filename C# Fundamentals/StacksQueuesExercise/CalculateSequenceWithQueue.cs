namespace CalculateSequenceWithQueue
{
    using System;
    using System.Collections.Generic;

    class CalculateSequence
    {
        static void Main(string[] args)
        {
            var number = long.Parse(Console.ReadLine());
            var count = 0;
            var currentMember = number;
            var index = 0;

            var result = new Queue<long>();
            result.Enqueue(currentMember);

            for (int i = 0; i < 49; i++)
            {
                if (count > 2)
                {
                    count = 0;
                    index++;
                    currentMember = result.ToArray()[index];
                }
                
                if (count == 0)
                {
                    result.Enqueue(currentMember + 1);
                }
                else if (count == 1)
                {
                    result.Enqueue(2 * currentMember + 1);
                }
                else if (count == 2)
                {
                    result.Enqueue(currentMember + 2);
                }

                count++;
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}