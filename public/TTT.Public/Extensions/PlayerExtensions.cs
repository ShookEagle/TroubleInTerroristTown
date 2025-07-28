using System.Drawing;
using CounterStrikeSharp.API.Core;
using TTT.Public.Generic;
using TTT.Public.Mod.Roles;
using TTT.Roles;
using TTT.Roles.Roles;

namespace TTT.Public.Extensions;

public static class PlayerExtensions {
  public static bool IsReal(this CCSPlayerController? player) {
    //  Do nothing else before this:
    //  Verifies the handle points to an entity within the global entity list.
    if (player == null) return false;
    if (!player.IsValid) return false;

    if (player.Connected != PlayerConnectedState.PlayerConnected) return false;

    if (player.IsHLTV) return false;

    return true;
  }
  
  public static BaseRole GetRole(this CCSPlayerController player, IPlayerState<RoleState> state, IRoleFactory factory) {
    var roleState = state.Get(player);
    return factory.Get(roleState.Type);
  }
  
  public static void SetColor(this CCSPlayerController player, Color color) {
    if (!player.IsValid) return;
    var pawn = player.PlayerPawn.Value;
    if (!player.IsValid || pawn == null || !pawn.IsValid) return;
    if (color.A == 255)
      color = Color.FromArgb(pawn.Render.A, color.R, color.G, color.B);
    player.PlayerPawn.Value.SetColor(color);
  }
}