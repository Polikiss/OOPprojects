using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contract.Users;
using Lab5.Application.CurrentManagers;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Users;

public class UserService : IUserService
{
    private readonly IUserCommandRepository _repository;
    private readonly CurrentManager _currentUserManager;
    private readonly CurrentAccountManager _currentAccountManager;

    public UserService(
        IUserCommandRepository repository,
        CurrentManager currentUserManager,
        CurrentAccountManager currentAccountManager)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
        _currentAccountManager = currentAccountManager;
    }

    public UserLoginResult Login(int id, uint pin)
    {
        Account? account = _repository.FindAccountById(id);

        if (account is null)
        {
            return new UserLoginResult.FailUnknownUser();
        }

        if (account.Pin != pin)
        {
            return new UserLoginResult.FailWrongPin();
        }

        _currentUserManager.UserRoles = UserRole.User;
        _currentAccountManager.Account = account;
        return new UserLoginResult.SuccessUserLogin();
    }

    public UserCommandResult ShowBalance()
    {
        if (_currentAccountManager.Account is null)
        {
            return new UserCommandResult.Fail();
        }

        decimal balance = _repository.ShowBalance(_currentAccountManager.Account.Id);
        return new UserCommandResult.SuccessWithResult<decimal>(balance);
    }

    public UserCommandResult Withdrawal(decimal amount)
    {
        if (_currentAccountManager.Account == null)
        {
            return new UserCommandResult.Fail();
        }

        decimal balance = _currentAccountManager.Account.Balance;
        if (balance - amount < 0)
        {
            return new UserCommandResult.Fail();
        }

        _currentAccountManager.Account.Balance -= amount;
        _repository.UpdateBalance(_currentAccountManager.Account.Id, _currentAccountManager.Account.Balance);
        return new UserCommandResult.Success();
    }

    public UserCommandResult Replenishment(decimal amount)
    {
        if (_currentAccountManager.Account == null)
        {
            return new UserCommandResult.Fail();
        }

        _currentAccountManager.Account.Balance += amount;
        _repository.UpdateBalance(_currentAccountManager.Account.Id, _currentAccountManager.Account.Balance);
        return new UserCommandResult.Success();
    }

    public UserCommandResult ShowHistory()
    {
        if (_currentAccountManager.Account is null)
        {
            return new UserCommandResult.Fail();
        }

        string history = _repository.ShowHistory(_currentAccountManager.Account.Id);

        return new UserCommandResult.SuccessWithResult<string>(history);
    }

    public void Logout()
    {
        _currentUserManager.UserRoles = null;
        _currentAccountManager.Account = null;
    }
}