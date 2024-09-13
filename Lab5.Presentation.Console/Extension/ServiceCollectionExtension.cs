using Lab5.Presentation.Console.Scenarios.AdminLoginScenarios;
using Lab5.Presentation.Console.Scenarios.AdminLogoutScenarios;
using Lab5.Presentation.Console.Scenarios.CreateAccountScenarios;
using Lab5.Presentation.Console.Scenarios.LoginUserScenarios;
using Lab5.Presentation.Console.Scenarios.ReplenishmentScenarios;
using Lab5.Presentation.Console.Scenarios.ShowBalanceScenarios;
using Lab5.Presentation.Console.Scenarios.ShowHistoryScenarios;
using Lab5.Presentation.Console.Scenarios.UserLogoutScenarios;
using Lab5.Presentation.Console.Scenarios.WithdrawalScenarios;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Presentation.Console.Extension;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginUserScenarioProvider>();
        collection.AddScoped<IScenarioProvider, UserLogoutScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AdminLoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AdminLogoutScenarioProvider>();

        collection.AddScoped<IScenarioProvider, CreateAccountScenarioProvider>();

        collection.AddScoped<IScenarioProvider, ReplenishmentScenarioProvider>();
        collection.AddScoped<IScenarioProvider, WithdrawalScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ShowBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ShowHistoryScenarioProvider>();

        return collection;
    }
}