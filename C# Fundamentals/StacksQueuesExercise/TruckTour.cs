namespace TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TruckTours
    {
        public static void Main()
        {
            var numberOfPumps = int.Parse(Console.ReadLine());

            var pumps = new Queue<int[]>();
            var index = 0;

            for (int i = 0; i < numberOfPumps; i++)
            {
                var currentPump = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                pumps.Enqueue(currentPump);
            }

            for (int i = 0; i < numberOfPumps; i++)
            {
                var petrolAmount = 0;
                var distance = 0;
                var isCurrentPumpStart = true;

                foreach (var pump in pumps)
                {
                    petrolAmount += pump[0];
                    distance += pump[1];

                    if (petrolAmount < distance)
                    {
                        isCurrentPumpStart = false;
                        break;
                    }
                   
                }

                if (isCurrentPumpStart)
                {
                    index = i;
                    break;
                }
                else
                {
                    pumps.Enqueue(pumps.Dequeue());
                }
            }
            Console.WriteLine(index);
        }
    }
}
