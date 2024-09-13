using Lab5.Application.Contract.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.ShowHistoryScenarios;

public class ShowHistoryScenario : IScenario
{
    private readonly IUserService _userService;

    public ShowHistoryScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string ScenarioName => "Show History";

    public void Run()
    {
        UserCommandResult result = _userService.ShowHistory();
        if (result is UserCommandResult.SuccessWithResult<string> success)
        {
            string history = success.Result;
            AnsiConsole.WriteLine(history);
            AnsiConsole.Ask<string>("Enter to continue");
            return;
        }

        AnsiConsole.WriteLine("Fail");
        AnsiConsole.Ask<string>("Enter to continue");
    }
}