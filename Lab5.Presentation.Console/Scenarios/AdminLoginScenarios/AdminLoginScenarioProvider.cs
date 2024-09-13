using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contract.Admin;
using Lab5.Application.Contract.UserRoles;

namespace Lab5.Presentation.Console.Scenarios.AdminLoginScenarios;

public class AdminLoginScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _adminService;
    private readonly ICurrentService _currentService;

    public AdminLoginScenarioProvider(IAdminService service, ICurrentService currentUser)
    {
        _adminService = service;
        _currentService = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentService.UserRoles is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new AdminLoginScenario(_adminService);
        return true;
    }
}