namespace BillsPaymentSystem.App.Core.Contracts
{
    interface ICommand
    {
        string Execute(string[] args);
    }
}
