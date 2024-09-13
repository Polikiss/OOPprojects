namespace Lab5.Application.Contract.Accounts;

public interface ICurrentAccountService
{
    public Models.Accounts.Account? Account { get; set; }
}