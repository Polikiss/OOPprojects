namespace Lab5.Application.Contract.Admin;

public record AdminLoginResult()
{
    public sealed record SuccessAdminLogin() : AdminLoginResult;
    public sealed record FailAdminLogin() : AdminLoginResult;
}