using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contract.UserRoles;
using Lab5.Application.Contract.Users;
using Lab5.Application.Models.Users;

namespace Lab5.Presentation.Console.Scenarios.UserLogoutScenarios;

public class UserLogoutScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;
    private readonly ICurrentService _currentService;

    public UserLogoutScenarioProvider(IUserService service, ICurrentService currentUser)
    {
        _userService = service;
        _currentService = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentService.UserRoles is not UserRole.User)
        {
            scenario = null;
            return false;
        }

        scenario = new UserLogoutScenario(_userService);
        return true;
    }
}