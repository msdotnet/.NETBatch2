namespace DigitalBank.Core.Contracts
{
    public interface ILoanAccount : IAccount
    {
        double Amount { get; }
        double Emi { get; }
        double Tenure { get; init; }

        double CalculateEmi();
    }
}