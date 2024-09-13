using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contract.UserRoles;
using Lab5.Application.Contract.Users;
using Lab5.Application.Models.Users;

namespace Lab5.Presentation.Console.Scenarios.ShowHistoryScenarios;

public class ShowHistoryScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;
    private readonly ICurrentService _currentService;

    public ShowHistoryScenarioProvider(IUserService service, ICurrentService currentUser)
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

        scenario = new ShowHistoryScenario(_userService);
        return true;
    }
}