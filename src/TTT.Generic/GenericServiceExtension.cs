using Microsoft.Extensions.DependencyInjection;
using TTT.Generic.Coroutines;
using TTT.Generic.PlayerState;
using TTT.Generic.PlayerState.Behaviors;
using TTT.Public.Extensions;
using TTT.Public.Generic;
using TTT.Roles;

namespace TTT.Generic;

public static class GenericServiceExtension {
  public static void AddTTTGeneric(
  this IServiceCollection serviceCollection) {
    serviceCollection.AddPluginBehavior<AliveStateTracker>();
    serviceCollection.AddPluginBehavior<GlobalStateTracker>();
    serviceCollection.AddPluginBehavior<RoundStateTracker>();

    serviceCollection.AddTransient<IPlayerStateFactory, PlayerStateFactory>();
    
    serviceCollection.AddSingleton<IPlayerState<RoleState>>(provider =>
      provider.GetRequiredService<IPlayerStateFactory>().Round<RoleState>());

    serviceCollection.AddPluginBehavior<ICoroutines, CoroutineManager>();
  }
}