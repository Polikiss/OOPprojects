using Itmo.Dev.Platform.Postgres.Connection;
using Lab5.Application.Abstractions.Repositories;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class AdminCommandRepository : IAdminCommandRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminCommandRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public void CreateAccount(short pin)
    {
        const string sql = """
                          insert into account (balance, account_pin)
                          values (@balance, @account_pin);
                          """;

        NpgsqlConnection connection = Task
            .Run(async () => await _connectionProvider.GetConnectionAsync(default)
                .ConfigureAwait(false)).GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("balance", 0);
        command.Parameters.AddWithValue("account_pin", pin);

        command.ExecuteNonQuery();
    }
}