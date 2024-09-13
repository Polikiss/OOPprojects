using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contract.Admin;
using Lab5.Application.Contract.UserRoles;
using Lab5.Application.Models.Users;

namespace Lab5.Presentation.Console.Scenarios.CreateAccountScenarios;

public class CreateAccountScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _adminService;
    private readonly ICurrentService _currentService;

    public CreateAccountScenarioProvider(IAdminService service, ICurrentService currentUser)
    {
        _adminService = service;
        _currentService = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentService.UserRoles is not UserRole.Admin)
        {
            scenario = null;
            return false;
        }

        scenario = new CreateAccountScenario(_adminService);
        return true;
    }
}