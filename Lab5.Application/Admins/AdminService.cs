using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contract.Admin;
using Lab5.Application.CurrentManagers;
using Lab5.Application.Models.AdminPasswords;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Admins;

public class AdminService : IAdminService
{
    private readonly IAdminCommandRepository _repository;
    private readonly AdminPassword _password;
    private readonly CurrentManager _currentAdminManager;

    public AdminService(IAdminCommandRepository repository, CurrentManager currentAdminManager, AdminPassword password)
    {
        _repository = repository;
        _password = password;
        _currentAdminManager = currentAdminManager;
    }

    public AdminLoginResult Login(string password)
    {
        if (password.Equals(_password.Password, StringComparison.Ordinal) is false)
        {
            return new AdminLoginResult.FailAdminLogin();
        }

        _currentAdminManager.UserRoles = UserRole.Admin;

        return new AdminLoginResult.SuccessAdminLogin();
    }

    public void Logout()
    {
        _currentAdminManager.UserRoles = null;
    }

    public AdminCommandsResult CreateAccount(short pin)
    {
        _repository.CreateAccount(pin);
        return new AdminCommandsResult.Success();
    }
}