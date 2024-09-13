using Lab5.Application.Contract.UserRoles;
using Lab5.Application.Models.Users;

namespace Lab5.Application.CurrentManagers;

public class CurrentManager : ICurrentService
{
    public UserRole? UserRoles { get; set; }
}