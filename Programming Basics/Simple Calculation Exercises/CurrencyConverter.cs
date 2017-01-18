using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            var money = double.Parse(Console.ReadLine());
            var inputCurrency = Console.ReadLine();
            var outputCurrency = Console.ReadLine();
            var usd = 1.79549;
            var gbp = 2.53405;
            var eur = 1.95583;
            var convertion = 0.00;

            //USD
            #region 
            if (inputCurrency == "USD")
            {
                if (outputCurrency == "BGN")
                {
                    convertion = Math.Round(money * usd, 2);
                    Console.WriteLine("{0} BGN", convertion);
                }
                else if (outputCurrency == "EUR")
                {
                    convertion = Math.Round((money * usd) / eur, 2);
                    Console.WriteLine("{0} EUR", convertion);
                }
                else
                {
                    convertion = Math.Round((money * usd) / gbp, 2);
                    Console.WriteLine("{0} GBP", convertion);
                }
            }
            #endregion
            //endUSD

            //BGN
            #region
            else if (inputCurrency == "BGN")
            {
                if (outputCurrency == "USD")
                {
                    convertion = Math.Round(money / usd, 2);
                    Console.WriteLine("{0} USD", convertion);
                }
                else if (outputCurrency == "EUR")
                {
                    convertion = Math.Round((money / eur), 2);
                    Console.WriteLine("{0} EUR", convertion);
                }
                else
                {
                    convertion = Math.Round((money / gbp), 2);
                    Console.WriteLine("{0} GBP", convertion);
                }

            }
            #endregion
            //endBGN

            //EUR
            #region
            else if (inputCurrency == "EUR")
            {
                if (outputCurrency == "USD")
                {
                    convertion = Math.Round(money * eur / usd, 2);
                    Console.WriteLine("{0} USD", convertion);
                }
                else if (outputCurrency == "BGN")
                {
                    convertion = Math.Round((money / eur), 2);
                    Console.WriteLine("{0} BGN", convertion);
                }

                else
                {
                    convertion = Math.Round((money * eur / gbp), 2);
                    Console.WriteLine("{0} GBP", convertion);
                }
            }
            #endregion
            //endEUR

            //GBP
            #region
            else
            {
                if (outputCurrency == "USD")
                {
                    convertion = Math.Round(money * gbp / usd, 2);
                    Console.WriteLine("{0} USD", convertion);
                }
                else if (outputCurrency == "BGN")
                {
                    convertion = Math.Round((money / gbp), 2);
                    Console.WriteLine("{0} BGN", convertion);
                }
                else
                {
                    convertion = Math.Round((money * gbp / eur), 2);
                    Console.WriteLine("{0} GBP", convertion);
                }
            }
            #endregion
            //endGBP
        }
    }
}
