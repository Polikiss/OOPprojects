using Lab5.Application.Contract.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.ReplenishmentScenarios;

public class ReplenishmentScenario : IScenario
{
    private readonly IUserService _userService;

    public ReplenishmentScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string ScenarioName => "Replenishment";

    public void Run()
    {
        uint amount = AnsiConsole.Ask<uint>("Enter amount");

        UserCommandResult result = _userService.Replenishment(amount);

        string message = result switch
        {
            UserCommandResult.Success => "Success",
            UserCommandResult.Fail => "Fail",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Enter to continue");
    }
}