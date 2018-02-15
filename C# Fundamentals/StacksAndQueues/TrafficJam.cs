namespace TrafficJam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TrafficJam
    {
        public static void Main()
        {
            var numberOfCarsToPass = int.Parse(Console.ReadLine());

            var carsQueue = new Queue<string>();

            var input = Console.ReadLine();
            var carsCounter = 0;
            while (input != "end")
            {
                if (input == "green")
                {
                    var carsToPass = Math.Min(numberOfCarsToPass, carsQueue.Count);
                    for (int carsPassing = 0; carsPassing < carsToPass; carsPassing++)
                    {                        
                        Console.WriteLine($"{carsQueue.Dequeue()} passed!");
                        carsCounter++;
                    }
                }
                else
                {
                    carsQueue.Enqueue(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{carsCounter} cars passed the crossroads.");

        }
    }
}
