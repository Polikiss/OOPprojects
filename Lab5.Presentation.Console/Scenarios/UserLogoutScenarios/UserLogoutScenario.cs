using Lab5.Application.Contract.Users;

namespace Lab5.Presentation.Console.Scenarios.UserLogoutScenarios;

public class UserLogoutScenario : IScenario
{
    private readonly IUserService _userService;

    public UserLogoutScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string ScenarioName => "Logout";

    public void Run()
    {
        _userService.Logout();
    }
}