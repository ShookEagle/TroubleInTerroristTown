using Microsoft.Extensions.DependencyInjection;
using TTT.Logs.Listeners;
using TTT.Logs.Tags;
using TTT.Public.Extensions;
using TTT.Public.Mod.Logs;

namespace TTT.Logs;

public static class LogsServiceExtension {
  public static void AddTTTLogs(this IServiceCollection serviceCollection) {
    serviceCollection.AddPluginBehavior<ILogService, LogsManager>();
    serviceCollection.AddPluginBehavior<LogsCommand>();
    serviceCollection.AddPluginBehavior<LogDamageListeners>();
    //	PlayerTagHelper is a lower-level class that avoids dependency loops.
    serviceCollection.AddTransient<IPlayerTag, PlayerTagHelper>();
  }
}