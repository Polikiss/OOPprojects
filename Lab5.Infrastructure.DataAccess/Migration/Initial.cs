using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Lab5.Infrastructure.DataAccess.Migration;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
    """
    create type command_name as enum
    (
        'create',
        'show_balance',
        'withdrawal',
        'replenishment'
    );
    
    create table account
    (
        account_id bigint primary key generated always as identity,
        balance decimal not null,
        account_pin int not null 
    );
    
    create table command_history
    (
        command_id bigint primary key generated always as identity,
        command_name text not null,
        account_id int not null 
    );
    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
    """
    drop table account;
    drop table command_history;

    drop type command_name;
    """;
}