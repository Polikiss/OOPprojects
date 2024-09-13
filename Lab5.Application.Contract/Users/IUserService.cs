namespace Lab5.Application.Contract.Users;

public interface IUserService
{
    public UserLoginResult Login(int id, uint pin);
    public UserCommandResult ShowBalance();
    public UserCommandResult Withdrawal(decimal amount);
    public UserCommandResult Replenishment(decimal amount);
    public UserCommandResult ShowHistory();
    public void Logout();
}