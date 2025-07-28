using System.Collections.Immutable;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Capabilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TTT.Public;
using TTT.Public.Behaviors;

namespace TTT;

public class TTT : BasePlugin {
  private readonly IServiceProvider provider;
  private IReadOnlyList<IPluginBehavior>? extensions;
  private IServiceScope? scope;

  /// <summary>
  ///   The TTT plugin.
  /// </summary>
  /// <param name="provider"></param>
  public TTT(IServiceProvider provider) { this.provider = provider; }

  public override string ModuleName => "TTT";

  public override string ModuleVersion 
    => $"{GitVersionInformation.SemVer} ({GitVersionInformation.ShortSha})";

  public override string ModuleAuthor => "EdgeGamers Development";

  /// <inheritdoc />
  public override void Load(bool hotReload) {
    RegisterListener<Listeners.OnServerPrecacheResources>(manifest => {
      //Later Impl
    });

    //  Load Managers
    Logger.LogInformation("[TTT] Loading...");

    scope = provider.CreateScope();
    extensions = scope.ServiceProvider.GetServices<IPluginBehavior>()
     .ToImmutableList();

    Logger.LogInformation("[TTT] Found {@BehaviorCount} behaviors.",
      extensions.Count);

    foreach (var extension in extensions) {
      //	Register all event handlers on the extension object
      RegisterAllAttributes(extension);

      //	Tell the extension to start it's magic
      extension.Start(this, hotReload);

      Logger.LogInformation("[TTT] Loaded behavior {@Behavior}",
        extension.GetType().FullName);
    }

    //	Expose the scope to other plugins
    Capabilities.RegisterPluginCapability(API.Provider, () => {
      if (scope == null)
        throw new InvalidOperationException(
          "TTT does not have a running scope! Is the TTT plugin loaded?");

      return scope.ServiceProvider;
    });

    base.Load(hotReload);
  }

  /// <inheritdoc />
  public override void Unload(bool hotReload) {
    Logger.LogInformation("[TTT] Shutting down...");

    if (extensions != null)
      foreach (var extension in extensions)
        extension.Dispose();

    //	Dispose of original extensions scope
    //	When loading again we will get a new scope to avoid leaking state.
    scope?.Dispose();
    scope = null;

    base.Unload(hotReload);
  }
}