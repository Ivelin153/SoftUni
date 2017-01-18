using System;

namespace SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            var FirstAthlete = int.Parse(Console.ReadLine());
            var SecondAthlete = int.Parse(Console.ReadLine());
            var ThirdAthlete = int.Parse(Console.ReadLine());

            var totalTime = FirstAthlete + SecondAthlete + ThirdAthlete;

            if (totalTime <= 59)
            {
                Console.WriteLine("0:{0:d2}", totalTime);
            }
            else if (totalTime <= 119)
            {
                Console.WriteLine("1:{0:d2}", totalTime - 60);
            }
            else if (totalTime <= 179)
            {
                Console.WriteLine("2:{0:d2}", totalTime - 120);
            }
            else if (totalTime < 10)
            {
                Console.WriteLine("0:{0:d2}", totalTime);
            }
        }
    }
}