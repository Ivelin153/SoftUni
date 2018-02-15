namespace CustMinFunc
{
    using System;
    using System.Linq;

    class MinFunction
    {
        static void Main()
        {
            Func<int[], int> minFunction = n =>
            {
                var min = int.MaxValue;

                foreach (var numb in n)
                {
                    if (numb < min)
                    {
                        min = numb;
                    }
                }
                return min;
            };

            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(minFunction(input));

        }
    }
}

