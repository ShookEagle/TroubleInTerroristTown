using CounterStrikeSharp.API.Core;
using Microsoft.Extensions.DependencyInjection;
using TTT.Generic;
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
        serviceCollection.AddTTTGeneric();
        serviceCollection.AddTTTLogs();
        serviceCollection.AddTTTRoles();
    }
}