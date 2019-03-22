namespace BillsPaymentSystem.App.Core.Commands
{
    using BillsPaymentSystem.App.Core.Contracts;
    using BillsPaymentSystem.Data;
    using BillsPaymentSystem.Models.Enums;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class UserInfoCommand : ICommand
    {
        private readonly BillsPaymentSystemContext context;

        public UserInfoCommand(BillsPaymentSystemContext context)
        {
            this.context = context;
        }

        public string Execute(string[] args)
        {
            int userId = int.Parse(args[0]);

            var user = this.context.Users
                .Include(x => x.PaymentMethods)
                .ThenInclude(x => x.CreditCard)
                .Include(x => x.PaymentMethods)
                .ThenInclude(x => x.BankAccount)
                .FirstOrDefault(u => u.UserId == userId);

            if (user == null)
            {
                throw new ArgumentNullException("There is no user with that Id");
            }
            var sb = new StringBuilder();

            sb.AppendLine("Bank Accounts:");

            sb.AppendLine($"User: {user.FirstName} {user.LastName}");

            var bankAccounts = user.PaymentMethods
                .Where(x => x.BankAccount != null)
                .Select(x => x.BankAccount).ToArray();

            foreach (var item in bankAccounts)
            {
                sb.AppendLine($"-- ID: {item.BankAccountId}")
                .AppendLine($"--- Balance: {item.Balance:f2}")
                .AppendLine($"--- Bank: {item.BankName}")
               .AppendLine($"--- SWIFT: {item.SwiftCode}");
            }

            sb.AppendLine("Credit Cards:");

            var creditCards = user.PaymentMethods
                .Where(x => x.CreditCard != null)
                .Select(x => x.CreditCard).ToArray();

            foreach (var item in creditCards)
            {
                sb.AppendLine($"-- ID: {item.CreditCardId}")
                .AppendLine($"--- Limit: {item.Limit:f2}")
                .AppendLine($"--- Money Owed: {item.MoneyOwed:f2}")
                .AppendLine($"--- Limit Left: {item.LimitLeft}")
                .AppendLine($"--- Expiration Date: {item.ExpirationDate.ToString(@"yyyy/MM", CultureInfo.InvariantCulture)}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
