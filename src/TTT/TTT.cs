using System.Collections.Immutable;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Capabilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TTT.Public;
using TTT.Public.Behaviors;

namespace TTT;

public class TTT : BasePlugin {
  private readonly IServiceProvider _provider;
  private IReadOnlyList<IPluginBehavior>? _extensions;
  private IServiceScope? _scope;

  /// <summary>
  ///   The TTT plugin.
  /// </summary>
  /// <param name="provider"></param>
  public TTT(IServiceProvider provider) { this._provider = provider; }

  public override string ModuleName => "TTT";

  public override string ModuleVersion => "1.0.0";

  public override string ModuleAuthor => "ShookEagle";

  /// <inheritdoc />
  public override void Load(bool hotReload) {
    RegisterListener<Listeners.OnServerPrecacheResources>(manifest => {
      //Later Impl
    });

    //  Load Managers
    Logger.LogInformation("[TTT] Loading...");

    _scope = _provider.CreateScope();
    _extensions = _scope.ServiceProvider.GetServices<IPluginBehavior>()
     .ToImmutableList();

    Logger.LogInformation("[TTT] Found {@BehaviorCount} behaviors.",
      _extensions.Count);

    foreach (var extension in _extensions) {
      //	Register all event handlers on the extension object
      RegisterAllAttributes(extension);

      //	Tell the extension to start it's magic
      extension.Start(this, hotReload);

      Logger.LogInformation("[TTT] Loaded behavior {@Behavior}",
        extension.GetType().FullName);
    }

    //	Expose the scope to other plugins
    Capabilities.RegisterPluginCapability(API.Provider, () => {
      if (_scope == null)
        throw new InvalidOperationException(
          "TTT does not have a running scope! Is the TTT plugin loaded?");

      return _scope.ServiceProvider;
    });

    base.Load(hotReload);
  }

  /// <inheritdoc />
  public override void Unload(bool hotReload) {
    Logger.LogInformation("[TTT] Shutting down...");

    if (_extensions != null)
      foreach (var extension in _extensions)
        extension.Dispose();

    //	Dispose of original extensions scope
    //	When loading again we will get a new scope to avoid leaking state.
    _scope?.Dispose();
    _scope = null;

    base.Unload(hotReload);
  }
}