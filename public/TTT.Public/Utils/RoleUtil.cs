using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using TTT.Public.Extensions;
using TTT.Public.Generic;
using TTT.Public.Mod.Roles;
using TTT.Roles;
using TTT.Roles.Roles;

namespace TTT.Public.Utils;

public static class RoleUtil {
  public static IEnumerable<CCSPlayerController> GetPlayersWithRole(RoleType type, IPlayerState<RoleState> state) {
    return Utilities.GetPlayers()
     .Where(p => p.IsReal() && state.Get(p).Type == type);
  }
}