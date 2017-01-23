using System;
using System.Numerics;
namespace DifferentIntegerSize
{
    class DiferentIntegerSize
    {
        static void Main(string[] args)
        {
            #region
            //try
            //{
            //    var intToCheck = long.Parse(Console.ReadLine());
            //    Console.WriteLine("{0} can fit in:", intToCheck);
            //    if (intToCheck >= SByte.MinValue && intToCheck <= SByte.MaxValue)
            //    {
            //        Console.WriteLine("* sbyte");
            //    }
            //    if (intToCheck >= Byte.MinValue && intToCheck <= Byte.MaxValue)
            //    {
            //        Console.WriteLine("* byte");
            //    }
            //    if (intToCheck >= short.MinValue && intToCheck <= short.MaxValue)
            //    {
            //        Console.WriteLine("* short");
            //    }
            //    if (intToCheck <= ushort.MaxValue && intToCheck >= 0)
            //    {
            //        Console.WriteLine("* ushort");
            //    }
            //    if (intToCheck >= int.MinValue && intToCheck <= int.MaxValue)
            //    {
            //        Console.WriteLine("* int");
            //    }
            //    if (intToCheck <= uint.MaxValue && intToCheck >= 0)
            //    {
            //        Console.WriteLine("* uint");
            //    }
            //    if (intToCheck >= long.MinValue && intToCheck <= long.MaxValue)
            //    {
            //        Console.WriteLine("* long");
            //    }

            //}
            //catch (Exception)
            //{

            //    Console.WriteLine("can't fit in any type");
            //}
            #endregion
            BigInteger input = BigInteger.Parse(Console.ReadLine());
            bool isSbyte = (input >= sbyte.MinValue) && (input <= sbyte.MaxValue);
            bool isByte = (input >= Byte.MinValue) && (input <= Byte.MaxValue);
            bool isShort = (input >= short.MinValue) && (input <= short.MaxValue);
            bool isUshort = (input >= ushort.MinValue) && (input <= ushort.MaxValue);
            bool isInt = (input >= int.MinValue) && (input <= int.MaxValue);
            bool isUint = (input >= uint.MinValue) && (input <= uint.MaxValue);
            bool isLong = (input >= long.MinValue) && (input <= long.MaxValue);

            if (isSbyte || isByte || isShort || isUshort || isInt || isUint || isLong)
            {
                Console.WriteLine("{0} can fit in:", input);
                if (isSbyte)
                {
                    Console.WriteLine("* sbyte");
                }
                if (isByte)
                {
                    Console.WriteLine("* byte");
                }
                if (isShort)
                {
                    Console.WriteLine("* short");
                }
                if (isUshort)
                {
                    Console.WriteLine("* ushort");
                }
                if (isInt)
                {
                    Console.WriteLine("* int");
                }
                if (isUint)
                {
                    Console.WriteLine("* uint");
                }
                if (isLong)
                {
                    Console.WriteLine("* long");
                }
            }
            else
            {
                Console.WriteLine("{0} can't fit in any type", input);
            }
        }
    }
}