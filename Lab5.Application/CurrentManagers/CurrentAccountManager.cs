using Lab5.Application.Contract.Accounts;
using Lab5.Application.Models.Accounts;

namespace Lab5.Application.CurrentManagers;

public class CurrentAccountManager : ICurrentAccountService
{
    public Account? Account { get; set; }
}