using Lab5.Application.Contract.Admin;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.CreateAccountScenarios;

public class CreateAccountScenario : IScenario
{
    private readonly IAdminService _adminService;

    public CreateAccountScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string ScenarioName => "Create Account";

    public void Run()
    {
        short pin = AnsiConsole.Ask<short>("Enter pin for new account");

        AdminCommandsResult result = _adminService.CreateAccount(pin);

        string message = result switch
        {
            AdminCommandsResult.Success => "Account created",
            AdminCommandsResult.Fail => "Fail",

            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Enter to continue");
    }
}