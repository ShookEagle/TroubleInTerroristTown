using CounterStrikeSharp.API.Core;
using Microsoft.Extensions.DependencyInjection;
using TTT.English.Generic;
using TTT.Formatting.Views;

namespace TTT;

/// <summary>
///   Class that auto-registers all TTT services and classes.
/// </summary>
public class TTTServiceCollection : IPluginServiceCollection<TTT>
{
    /// <inheritdoc />
    public void ConfigureServices(IServiceCollection serviceCollection) {
        serviceCollection.AddSingleton<IGenericCmdLocale, GenericCmdLocale>();
    }
}