using CounterStrikeSharp.API.Core;
using TTT.Public.Mod.Roles.Enum;

namespace TTT.Public.Mod.Roles;

public interface IRoleProvider {
  BaseRole Get(RoleType type);
  RoleType GetRole(CCSPlayerController player);
  void SetRole(CCSPlayerController player, RoleType role);
  
}