using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contract.Users;
using Lab5.Application.CurrentManagers;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.Users;
using Lab5.Application.Users;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class ApplicationTests
{
    [Fact]
    public void Balance_ShouldReplenish_AfterReplenishment()
    {
        // Arrange
        IUserCommandRepository userCommandRepository = Substitute.For<IUserCommandRepository>();
        var currentAccount = new CurrentAccountManager();
        var currentUserRole = new CurrentManager();
        var account = new Account(77, 88, 1111);
        currentUserRole.UserRoles = UserRole.User;
        currentAccount.Account = account;
        var userService = new UserService(userCommandRepository, currentUserRole, currentAccount);

        // Act
        UserCommandResult result = userService.Replenishment(10);

        // Assert
        Assert.IsType<UserCommandResult.Success>(result);
    }

    [Fact]
    public void Balance_ShouldWithdraw_AfterWithdrawal()
    {
        // Arrange
        IUserCommandRepository userCommandRepository = Substitute.For<IUserCommandRepository>();
        var currentAccount = new CurrentAccountManager();
        var currentUserRole = new CurrentManager();
        currentUserRole.UserRoles = UserRole.User;
        currentAccount.Account = new Account(77, 88, 1111);
        var userService = new UserService(userCommandRepository, currentUserRole, currentAccount);

        // Act
        UserCommandResult result = userService.Withdrawal(10);

        // Assert
        Assert.IsType<UserCommandResult.Success>(result);
    }

    [Fact]
    public void Balance_ShouldNotWithdrawal_AfterWithdrawal_NotEnoughMoney()
    {
        // Arrange
        IUserCommandRepository userCommandRepository = Substitute.For<IUserCommandRepository>();
        var currentAccount = new CurrentAccountManager();
        var currentUserRole = new CurrentManager();
        var account = new Account(77, 88, 1111);
        currentUserRole.UserRoles = UserRole.User;
        currentAccount.Account = account;
        var userService = new UserService(userCommandRepository, currentUserRole, currentAccount);

        // Act
        UserCommandResult result = userService.Withdrawal(90);

        // Assert
        Assert.IsType<UserCommandResult.Fail>(result);
    }
}