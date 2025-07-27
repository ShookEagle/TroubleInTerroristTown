using Microsoft.Extensions.DependencyInjection;
using TTT.Formatting.Views.Logs;
using TTT.Logs.Listeners;
using TTT.Logs.Tags;
using TTT.Public.Extensions;
using TTT.Public.Mod.Logs;

namespace TTT.Logs;

public static class LogsServiceExtension {
  public static void AddTTTLogs(this IServiceCollection serviceCollection) {
    serviceCollection.AddPluginBehavior<IRichLogService, LogsManager>();
    serviceCollection.AddTransient<ILogService>(provider
      => provider.GetRequiredService<IRichLogService>());

    serviceCollection.AddPluginBehavior<LogsCommand>();
    
    serviceCollection.AddPluginBehavior<LogDamageListeners>();

    //	PlayerTagHelper is a lower-level class that avoids dependency loops.
    serviceCollection.AddTransient<IRichPlayerTag, PlayerTagHelper>();
    serviceCollection.AddTransient<IPlayerTag, PlayerTagHelper>();
  }
}