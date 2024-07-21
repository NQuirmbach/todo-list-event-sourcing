using Marten;
using Marten.Events.Daemon.Resiliency;
using TodoList.TodoGroups;
using Weasel.Core;

namespace TodoList.Configurations;

public static class MartenConfiguration
{
    public static void AddAppMartenConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddMarten(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("Database")!;
            
            options.Connection(connectionString);
            options.UseSystemTextJsonForSerialization();
            
            RegisterProjections(options);

            options.AutoCreateSchemaObjects = AutoCreate.All;
            options.Events.DatabaseSchemaName = "events";
        })
        .UseLightweightSessions()
        .AddAsyncDaemon(builder.Environment.IsDevelopment() ? DaemonMode.Solo : DaemonMode.HotCold);
    }

    private static void RegisterProjections(StoreOptions options) =>
        options.RegisterTodoGroupProjections();
}