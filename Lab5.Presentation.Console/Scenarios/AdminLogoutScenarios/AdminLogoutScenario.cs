using Lab5.Application.Contract.Admin;

namespace Lab5.Presentation.Console.Scenarios.AdminLogoutScenarios;

public class AdminLogoutScenario : IScenario
{
    private readonly IAdminService _adminService;

    public AdminLogoutScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string ScenarioName => "Logout";

    public void Run()
    {
        _adminService.Logout();
    }
}