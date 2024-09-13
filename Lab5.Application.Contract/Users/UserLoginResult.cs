namespace Lab5.Application.Contract.Users;

public record UserLoginResult()
{
    public sealed record SuccessUserLogin() : UserLoginResult;
    public sealed record FailUnknownUser() : UserLoginResult;
    public sealed record FailWrongPin() : UserLoginResult;
}