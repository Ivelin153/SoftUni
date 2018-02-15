namespace AppliedArithmetics
{
    using System;
    using System.Linq;

    class Program
    {

        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int[]> add = a =>
            {
                for (int i = 0; i < a.Length; i++)
                {
                    a[i]++;
                }
                return a;
            };

            Func<int[], int[]> multiply = a =>
            {
                for (int i = 0; i < a.Length; i++)
                {
                    a[i] *= 2;
                }
                return a;
            };

            Func<int[], int[]> subtract = a =>
            {
                for (int i = 0; i < a.Length; i++)
                {
                    a[i]--;
                }
                return a;
            };
            Action<int[]> print = a =>
            {
                Console.WriteLine(string.Join(" ", a));
            };


            var commnad = Console.ReadLine();
            while (commnad != "end")
            {
                switch (commnad)
                {
                    case "add":
                        add(numbers);
                        break;

                    case "multiply":
                        multiply(numbers);
                        break;

                    case "subtract":
                        subtract(numbers);
                        break;

                    case "print":
                        print(numbers);
                        break;

                    default:
                        break;
                }
                commnad = Console.ReadLine();
            }

        }
    }

}
