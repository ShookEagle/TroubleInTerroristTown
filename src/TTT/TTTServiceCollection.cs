using CounterStrikeSharp.API.Core;
using Microsoft.Extensions.DependencyInjection;
using TTT.English.Generic;
using TTT.English.Logs;
using TTT.English.Roles;
using TTT.Formatting.Views;
using TTT.Formatting.Views.Logs;
using TTT.Formatting.Views.Roles;
using TTT.Logs;
using TTT.Roles;

namespace TTT;

/// <summary>
///   Class that auto-registers all TTT services and classes.
/// </summary>
public class TTTServiceCollection : IPluginServiceCollection<TTT>
{
    /// <inheritdoc />
    public void ConfigureServices(IServiceCollection serviceCollection) {
        serviceCollection.AddSingleton<IGenericCmdLocale, GenericCmdLocale>();
        serviceCollection.AddSingleton<ILogLocale, LogLocale>();
        serviceCollection.AddSingleton<IRoleLocale, RoleLocale>();

        serviceCollection.AddTTTLogs();
        serviceCollection.AddTTTRoles();
    }
}