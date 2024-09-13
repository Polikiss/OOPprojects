using Lab5.Application.Contract.Admin;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.AdminLoginScenarios;

public class AdminLoginScenario : IScenario
{
    private readonly IAdminService _adminService;

    public AdminLoginScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string ScenarioName => "Admin";

    public void Run()
    {
        string password = AnsiConsole.Ask<string>("Enter password");

        AdminLoginResult result = _adminService.Login(password);

        if (result is AdminLoginResult.FailAdminLogin)
        {
            Environment.Exit(0);
        }

        AnsiConsole.WriteLine("Successful login");
    }
}