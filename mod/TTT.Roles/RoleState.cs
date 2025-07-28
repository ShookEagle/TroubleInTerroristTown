using TTT.Public.Mod.Roles;
using TTT.Public.Mod.Roles.Enum;

namespace TTT.Roles;

public class RoleState {
  /// <summary>
  ///   What this player's current role is
  /// </summary>
  public RoleType Type { get; set; }
}