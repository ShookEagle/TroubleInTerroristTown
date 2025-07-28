using TTT.Public.Behaviors;
using TTT.Public.Mod.Roles;
using TTT.Public.Mod.Roles.Enum;
using TTT.Roles.Roles;

namespace TTT.Roles;

public class RoleFactory : IPluginBehavior, IRoleFactory {
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
}