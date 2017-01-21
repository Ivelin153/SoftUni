using System;

namespace BooleanVariables
{
    class BooleanVariables
    {
        static void Main(string[] args)
        {
            string ss = Console.ReadLine();
            if (Convert.ToBoolean(ss))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
            
        }
    }
}
