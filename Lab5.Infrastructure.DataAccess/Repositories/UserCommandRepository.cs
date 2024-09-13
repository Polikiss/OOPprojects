using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.Commands;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class UserCommandRepository : IUserCommandRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserCommandRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public Account? FindAccountById(int id)
    {
        const string sql = """
                           select account_id, balance, account_pin
                           from account
                           where account_id = @id;
                           """;

        NpgsqlConnection connection = Task
            .Run(async () => await _connectionProvider.GetConnectionAsync(default)
                .ConfigureAwait(false)).GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("id", id);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
        {
            return null;
        }

        return new Account(
            Id: reader.GetInt32(0),
            Balance: reader.GetDecimal(1),
            Pin: reader.GetInt16(2));
    }

    public decimal ShowBalance(int id)
    {
        const string sql = """
                           select account_id, balance
                           from account
                           where account_id = @id;
                           """;

        NpgsqlConnection connection = Task
            .Run(async () => await _connectionProvider.GetConnectionAsync(default)
                .ConfigureAwait(false)).GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("id", id);

        using NpgsqlDataReader reader = command.ExecuteReader();
        reader.Read();
        decimal balance = reader.GetDecimal(1);
        return balance;
    }

    public string ShowHistory(int id)
    {
        const string sql = """
                           select account_id, command_name
                           from command_history
                           where account_id = @id;
                           """;

        NpgsqlConnection connection = Task
            .Run(async () => await _connectionProvider.GetConnectionAsync(default)
                .ConfigureAwait(false)).GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("id", id);

        using NpgsqlDataReader reader = command.ExecuteReader();
        string history = string.Empty;

        while (reader.Read())
        {
            history += reader.GetString(1) + '\n';
        }

        return history;
    }

    public void UpdateBalance(int id, decimal amount)
    {
        AddCommandInHistory(id, CommandName.Withdrawal);
        const string sql = """
                           update account
                           set balance = @amount
                           where account_id = @id;
                           """;

        NpgsqlConnection connection = Task
            .Run(async () => await _connectionProvider.GetConnectionAsync(default)
                .ConfigureAwait(false)).GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("id", id);
        command.AddParameter("amount", amount);

        command.ExecuteNonQuery();
    }

    public void AddCommandInHistory(long id, CommandName commandName)
    {
        const string sql = """
                           insert into command_history (command_name, account_id)
                           values (@command_type, @account_id);
                           """;

        NpgsqlConnection connection = Task
            .Run(async () => await _connectionProvider.GetConnectionAsync(default)
                .ConfigureAwait(false)).GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("command_type", commandName);
        command.Parameters.AddWithValue("account_id", id);

        command.ExecuteNonQuery();
    }
}