using CounterStrikeSharp.API.Core;
using TTT.Public.Behaviors;
using TTT.Public.Generic;
using TTT.Public.Mod.Roles;
using TTT.Public.Mod.Roles.Enum;
using TTT.Roles.Roles;

namespace TTT.Roles;

public class RoleProvider(IPlayerStateFactory factory,
  ILocalizationHandler localizer) : IPluginBehavior, IRoleProvider {
  private readonly IPlayerState<RoleState> rState =
    factory.Round<RoleState>();
  
  private readonly BaseRole innocent = new InnocentRole(localizer);
  private readonly BaseRole detective = new DetectiveRole(localizer);
  private readonly BaseRole traitor = new TraitorRole(localizer);
  
  public BaseRole Get(RoleType type) {
    return type switch {
      RoleType.INNOCENT  => innocent,
      RoleType.DETECTIVE => detective,
      RoleType.TRAITOR   => traitor,
      _                  => innocent,
    };
  }

  public RoleType GetRole(CCSPlayerController player) {
    return rState.Get(player).Type;
  }
  
  public void SetRole(CCSPlayerController player, RoleType role) {
    rState.Get(player).Type = role;
  }
}