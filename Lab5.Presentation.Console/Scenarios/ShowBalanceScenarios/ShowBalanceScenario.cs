using System.Globalization;
using Lab5.Application.Contract.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.ShowBalanceScenarios;

public class ShowBalanceScenario : IScenario
{
    private readonly IUserService _userService;

    public ShowBalanceScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string ScenarioName => "Show Balance";

    public void Run()
    {
        UserCommandResult result = _userService.ShowBalance();
        if (result is UserCommandResult.SuccessWithResult<decimal> success)
        {
            decimal balance = success.Result;
            AnsiConsole.WriteLine(balance.ToString(CultureInfo.InvariantCulture));
            AnsiConsole.Ask<string>("Enter to continue");
            return;
        }

        AnsiConsole.WriteLine("Fail");
        AnsiConsole.Ask<string>("Enter to continue");
    }
}