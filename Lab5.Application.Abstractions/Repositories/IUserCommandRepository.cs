using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.Commands;

namespace Lab5.Application.Abstractions.Repositories;

public interface IUserCommandRepository
{
    public Account? FindAccountById(int id);
    public decimal ShowBalance(int id);
    public void UpdateBalance(int id, decimal amount);
    public string ShowHistory(int id);
    public void AddCommandInHistory(long id, CommandName commandName);
}