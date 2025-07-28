using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using TTT.Public.Behaviors;
using TTT.Public.Mod.Roles;
using TTT.Public.Utils;

namespace TTT.Roles.Listeners;

public class RoundEndListener(IRoleProvider roleProvider)
  : IPluginBehavior {
  [GameEventHandler]
  public HookResult OnRoundEnd(EventRoundEnd e, GameEventInfo i) {
    foreach (var player in Utilities.GetPlayers()) {
      var roleType = roleProvider.GetRole(player);
      roleProvider.Get(roleType).OnRoundEnd(player);
    }
    return HookResult.Continue;
  }
}