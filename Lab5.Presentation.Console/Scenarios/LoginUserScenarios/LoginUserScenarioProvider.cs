using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contract.UserRoles;
using Lab5.Application.Contract.Users;

namespace Lab5.Presentation.Console.Scenarios.LoginUserScenarios;

public class LoginUserScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;
    private readonly ICurrentService _currentService;

    public LoginUserScenarioProvider(IUserService service, ICurrentService currentUser)
    {
        _userService = service;
        _currentService = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentService.UserRoles is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new LoginUserScenario(_userService);
        return true;
    }
}