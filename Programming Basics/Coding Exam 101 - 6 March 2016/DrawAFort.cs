using System;


namespace DrawAFort
{
    class Program
    {
        static void Main(string[] args)
        {

            var n = int.Parse(Console.ReadLine());
            var width = n * 2;
            var colSize = n / 2;
            var midSize = 2 * n - 2 * colSize - 4;

            //firstRow
            Console.WriteLine("/" + new String('^', n / 2) + '\\' + new String('_', midSize) + '/' + new String('^', n / 2) + '\\');

            // Middle rows
            for (var row = 1; row <= n - 3; row++)
                Console.WriteLine("|{0}|", new string(' ', 2 * n - 2));

            //beforeLastRows
            Console.WriteLine('|' + new String(' ', colSize+1) + new string('_', midSize) + new String(' ', colSize+1) +'|');

            //lastRow
            Console.WriteLine("\\" + new String('_', n / 2) + '/' + new String(' ', midSize) + '\\' + new String('_', n / 2) + '/');



        }
    }
}
