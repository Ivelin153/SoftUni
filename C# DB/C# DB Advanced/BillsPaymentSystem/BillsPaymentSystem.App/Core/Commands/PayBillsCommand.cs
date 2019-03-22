namespace BillsPaymentSystem.App.Core.Commands
{
    using BillsPaymentSystem.App.Core.Contracts;
    using BillsPaymentSystem.Data;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    class PayBillsCommand : ICommand
    {
        private readonly BillsPaymentSystemContext context;

        public PayBillsCommand(BillsPaymentSystemContext context)
        {
            this.context = context;
        }

        public string Execute(string[] args)
        {
            var userId = int.Parse(args[0]);
            var amount = decimal.Parse(args[1]);

            var user = this.context.Users
                .Include(x => x.PaymentMethods)
                .ThenInclude(x => x.CreditCard)
                .Include(x => x.PaymentMethods)
                .ThenInclude(x => x.BankAccount)
                .FirstOrDefault(u => u.UserId == userId);

            var bankAccountsTotal = user.PaymentMethods
                    .Where(x => x.BankAccount != null)
                    .Sum(x => x.BankAccount.Balance);

            var creditCardTotal = user.PaymentMethods
                    .Where(x => x.CreditCard != null)
                    .Sum(x => x.CreditCard.LimitLeft);

            var totalAmount = bankAccountsTotal + creditCardTotal;

            if (totalAmount >= amount)
            {
                var bankAccounts = user.PaymentMethods
                        .Where(x => x.BankAccount != null)
                        .Select(x => x.BankAccount)
                        .OrderBy(x => x.BankAccountId);

                foreach (var bankAccount in bankAccounts)
                {
                    if (bankAccount.Balance >= amount)
                    {
                        bankAccount.Withdraw(amount);
                        amount = 0;
                    }
                    else
                    {
                        amount -= bankAccount.Balance;
                        bankAccount.Withdraw(bankAccount.Balance);
                    }

                    if (amount == 0)
                    {
                        return "";

                    }
                }
                var creditCards =
                    user.PaymentMethods.Where(x => x.CreditCard != null).Select(x => x.CreditCard).OrderBy(x => x.CreditCardId);

                foreach (var creditCard in creditCards)
                {
                    if (creditCard.LimitLeft >= amount)
                    {
                        creditCard.Withdraw(amount);
                        amount = 0;

                    }
                    else
                    {
                        amount -= creditCard.LimitLeft;
                        creditCard.Withdraw(creditCard.LimitLeft);
                    }

                    if (amount == 0)
                    {
                        return "";

                    }
                }
            }
            return "Insufficient funds!";
        }
    }
}
