namespace KeyRevolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ShotTheSafe
    {
        public static void Main()
        {
            var bulletPrice = int.Parse(Console.ReadLine());
            var gunBarrelSize = int.Parse(Console.ReadLine());

            var bulletsInput = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var bulletsStack = new Stack<int>(bulletsInput);

            var locksInput = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var locksQueue = new Queue<int>(locksInput);

            var valueOfIntelligence = int.Parse(Console.ReadLine());

            var usedBullets = 0;
            while (bulletsStack.Count != 0 && locksQueue.Count != 0)
            {
                var currentBullet = bulletsStack.Peek();
                var currentLock = locksQueue.Peek();

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locksQueue.Dequeue();
                    bulletsStack.Pop();
                }
                else
                {
                    Console.WriteLine("Ping!");
                    bulletsStack.Pop();
                }
                usedBullets++;
                if (usedBullets % gunBarrelSize == 0 && bulletsStack.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                }
            }

            var bulletsCost = usedBullets * bulletPrice;
            var moneyEarned = valueOfIntelligence - bulletsCost;

            if (bulletsStack.Count == 0 && locksQueue.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
            else
            {
                Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${moneyEarned}");
            }
        }

    }
}
