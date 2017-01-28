using System;
using System.Globalization;
class Program
{
    static double lineLength(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
    }

    static double distanceToCenter(double x, double y)
    {
        return Math.Sqrt(Math.Pow((0 - x), 2) + Math.Pow((0 - y), 2));
    }

    static void printClosestPointFirst(double x1, double y1, double x2, double y2)
    {
        if (distanceToCenter(x1, y1) > distanceToCenter(x2, y2))
        {
            Console.Write("(" + x2 + ", " + y2 + ")");
            Console.WriteLine("(" + x1 + ", " + y1 + ")");
        }
        else
        {
            Console.Write("(" + x1 + ", " + y1 + ")");
            Console.WriteLine("(" + x2 + ", " + y2 + ")");
        }
    }

    static void printLongerLine(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
    {
        if (lineLength(x1, y1, x2, y2) >= lineLength(x3, y3, x4, y4))
        {
            printClosestPointFirst(x1, y1, x2, y2);
        }
        else if (lineLength(x1, y1, x2, y2) < lineLength(x3, y3, x4, y4))
        {
            printClosestPointFirst(x3, y3, x4, y4);
        }
    }

    static void Main(string[] args)
    {
        double x1 = double.Parse(Console.ReadLine());
        double y1 = double.Parse(Console.ReadLine());
        double x2 = double.Parse(Console.ReadLine());
        double y2 = double.Parse(Console.ReadLine());
        double x3 = double.Parse(Console.ReadLine());
        double y3 = double.Parse(Console.ReadLine());
        double x4 = double.Parse(Console.ReadLine());
        double y4 = double.Parse(Console.ReadLine());

        printLongerLine(x1, y1, x2, y2, x3, y3, x4, y4);
    }
}