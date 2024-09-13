using Lab5.Application.Models.Users;

namespace Lab5.Application.Contract.UserRoles;

public interface ICurrentService
{
    public UserRole? UserRoles { get; set; }
}