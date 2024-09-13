using Lab5.Application.Contract.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.LoginUserScenarios;

public class LoginUserScenario : IScenario
{
    private readonly IUserService _userService;

    public LoginUserScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string ScenarioName => "User";

    public void Run()
    {
        int accountId = AnsiConsole.Ask<int>("Enter account id");
        ushort pin = AnsiConsole.Ask<ushort>("Enter account pin");

        UserLoginResult result = _userService.Login(accountId, pin);

        string message = result switch
        {
            UserLoginResult.SuccessUserLogin => "Successful login",
            UserLoginResult.FailUnknownUser => "User not found",
            UserLoginResult.FailWrongPin => "Wrong pin",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
    }
}