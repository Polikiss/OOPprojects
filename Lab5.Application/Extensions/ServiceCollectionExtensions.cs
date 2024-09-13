using Lab5.Application.Admins;
using Lab5.Application.CurrentManagers;
using Lab5.Application.Users;

namespace Lab5.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection, AdminPassword password)
    {
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<IAdminService, AdminService>();

        collection.AddScoped<AdminPassword>(x => password);

        collection.AddScoped<CurrentManager>();
        collection.AddScoped<ICurrentService>(
            p => p.GetRequiredService<CurrentManager>());

        collection.AddScoped<CurrentAccountManager>();
        collection.AddScoped<ICurrentAccountService>(
            p => p.GetRequiredService<CurrentAccountManager>());
        return collection;
    }
}