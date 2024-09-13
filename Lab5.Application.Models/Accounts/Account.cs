namespace Lab5.Application.Models.Accounts;

public record Account(int Id, decimal Balance, short Pin)
{
    public decimal Balance { get; set; } = Balance;
}