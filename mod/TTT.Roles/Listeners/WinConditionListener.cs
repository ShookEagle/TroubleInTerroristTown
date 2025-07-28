using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using TTT.Public.Behaviors;
using TTT.Public.Mod.Roles;
using TTT.Public.Mod.Roles.Enum;
using TTT.Public.Utils;

namespace TTT.Roles.Listeners;

public class WinConditionListener(IRoleProvider roleProvider)
  : IPluginBehavior {
  [GameEventHandler]
  public HookResult OnKill(EventPlayerDeath @event, GameEventInfo info) {
    info.DontBroadcast = true;
    checkRoundWin();

    return HookResult.Continue;
  }
  
      
  private void checkRoundWin() {
    var alivePlayers = PlayerUtil.GetAlive().ToList();
    var totalAlive   = alivePlayers.Count;

    var roleCounts = new Dictionary<RoleType, int>();
    foreach (var role in
      alivePlayers.Select(roleProvider.GetRole)) {
      roleCounts[role] = roleCounts.GetValueOrDefault(role) + 1;
    }

    foreach (var role in Enum.GetValues<RoleType>()) {
      var roleImpl = roleProvider.Get(role);
      if (!roleImpl.WinCondition(totalAlive, roleCounts)) continue;
      endRoundWithWinner(role);
      return;
    }
  }

  private void endRoundWithWinner(RoleType role) {  }
}