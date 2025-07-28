using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Entities.Constants;
using TTT.Public.Behaviors;
using TTT.Public.Extensions;
using TTT.Public.Mod.Roles;
using TTT.Public.Mod.Roles.Enum;
using TTT.Public.Utils;

namespace TTT.Roles.Listeners;

public class WinConditionListener(IRoleProvider roleProvider)
  : IPluginBehavior {
  [GameEventHandler(HookMode.Pre)]
  public HookResult OnKill(EventPlayerDeath @event, GameEventInfo info) {
    info.DontBroadcast = true;
    var player = @event.Userid;
    if (player == null) return HookResult.Continue;
    Server.NextWorldUpdate(() => checkRoundWin(player));

    return HookResult.Continue;
  }
  
      
  private void checkRoundWin(CCSPlayerController justDied) {
    var alivePlayers = PlayerUtil.GetAlive().ToList();
    var totalAlive   = alivePlayers.Count;

    var roleCounts = new Dictionary<RoleType, int>();
    foreach (var role in
      alivePlayers.Select(roleProvider.GetRole)) {
      roleCounts[role] = roleCounts.GetValueOrDefault(role) + 1;
    }
    
    roleCounts[roleProvider.GetRole(justDied)]--;
    
    Server.PrintToChatAll(
      $"T:{roleCounts.GetValueOrDefault(RoleType.TRAITOR)} | " +
      $"I:{roleCounts.GetValueOrDefault(RoleType.INNOCENT)} | " +
      $"D:{roleCounts.GetValueOrDefault(RoleType.DETECTIVE)}"
    );

    foreach (var role in Enum.GetValues<RoleType>()) {
      var roleImpl = roleProvider.Get(role);
      if (!roleImpl.WinCondition(totalAlive, roleCounts)) continue;
      endRoundWithWinner(role);
      return;
    }
  }

  private void endRoundWithWinner(RoleType role) {
    ServerExtensions.GetGameRules()?.TerminateRound(5f, RoundEndReason.RoundDraw);
    //TODO: WIN GRAPHIC
    //TODO: LOCALIZE
    Server.PrintToChatAll($"{roleProvider.Get(role).Type.ToString()}s Wins");
  }
}