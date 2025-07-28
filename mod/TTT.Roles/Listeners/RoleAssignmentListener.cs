using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using TTT.Public.Behaviors;
using TTT.Public.Generic;
using TTT.Public.Mod.Roles;
using TTT.Public.Utils;

namespace TTT.Roles.Listeners;

public class RoleAssignmentListener(IRoleFactory roleFactory,
  IPlayerStateFactory playerStateFactory, ICoroutines coroutines)
  : IPluginBehavior {
  private readonly IPlayerState<RoleState> roleState =
    playerStateFactory.Round<RoleState>();

  [GameEventHandler]
  public HookResult OnRoundStart(EventRoundStart @event, GameEventInfo info) {
    coroutines.Round(assignRoles);
    return HookResult.Continue;
  }

  private void assignRoles() {
    var players  = PlayerUtil.GetAlive().ToList();
    var shuffled = players.OrderBy(_ => Guid.NewGuid()).ToList();
    var assigned = new HashSet<CCSPlayerController>();

    var totalPlayers = players.Count;
    var allRoles = Enum.GetValues<RoleType>()
     .Select(rt => roleFactory.Get(rt))
     .Where(r => r.PlayerRatio is not -1)
     .ToList();

    foreach (var role in allRoles) {
      var ratioCount = role.PlayerRatio > 0 ?
        totalPlayers / role.PlayerRatio :
        int.MaxValue;
      var maxCount = role.MaxCount > 0 ? role.MaxCount : int.MaxValue;
      var count    = Math.Min(ratioCount, maxCount);

      foreach (var player in shuffled.Except(assigned).Take(count)) {
        roleState.Get(player).Type = role.Type;
        role.OnAssigned(player);
        assigned.Add(player);
      }
    }
    
    var defaultRole = roleFactory.Get(RoleType.INNOCENT);
    foreach (var player in shuffled.Except(assigned)) {
      roleState.Get(player).Type = defaultRole.Type;
      defaultRole.OnAssigned(player);
      assigned.Add(player);
    }
  }
}