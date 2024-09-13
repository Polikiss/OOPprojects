using Lab5.Application.Contract.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.WithdrawalScenarios;

public class WithdrawalScenario : IScenario
{
    private readonly IUserService _userService;

    public WithdrawalScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string ScenarioName => "Withdrawal";

    public void Run()
    {
        uint amount = AnsiConsole.Ask<uint>("Enter amount");

        UserCommandResult result = _userService.Withdrawal(amount);

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