using CounterStrikeSharp.API.Core;
using TTT.Public.Behaviors;
using TTT.Public.Generic;
using TTT.Public.Mod.Roles;
using TTT.Public.Mod.Roles.Enum;
using TTT.Roles.Roles;

namespace TTT.Roles;

public class RoleProvider(IPlayerStateFactory factory)
  : IPluginBehavior, IRoleProvider {
  private readonly IPlayerState<RoleState> rState =
    factory.Round<RoleState>();
  
  private static readonly BaseRole INNOCENT = new InnocentRole();
  private static readonly BaseRole DETECTIVE = new DetectiveRole();
  private static readonly BaseRole TRAITOR = new TraitorRole();
  
  public BaseRole Get(RoleType type) {
    return type switch {
      RoleType.INNOCENT  => INNOCENT,
      RoleType.DETECTIVE => DETECTIVE,
      RoleType.TRAITOR   => TRAITOR,
      _                  => INNOCENT,
    };
  }

  public RoleType GetRole(CCSPlayerController player) {
    return rState.Get(player).Type;
  }
  
  public void SetRole(CCSPlayerController player, RoleType role) {
    rState.Get(player).Type = role;
  }
}