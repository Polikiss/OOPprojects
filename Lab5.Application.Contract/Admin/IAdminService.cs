namespace Lab5.Application.Contract.Admin;

public interface IAdminService
{
    public AdminLoginResult Login(string password);

    public void Logout();
    public AdminCommandsResult CreateAccount(short pin);
}