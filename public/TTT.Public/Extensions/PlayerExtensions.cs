using System.Drawing;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using TTT.Public.Generic;

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
  
  public static void SetColor(this CCSPlayerController player, Color color) {
    if (!player.IsValid) return;
    var pawn = player.PlayerPawn.Value;
    if (!player.IsValid || pawn == null || !pawn.IsValid) return;
    if (color.A == 255)
      color = Color.FromArgb(pawn.Render.A, color.R, color.G, color.B);
    player.PlayerPawn.Value.SetColor(color);
  }

  public static void PrintLocalized(this CCSPlayerController player,
    ILocalizationHandler loc, string key, params object[] args) {
    if (!player.IsReal()) return;
    var message = loc.For(player, key, args);
    player.PrintToChat(message);
  }

  public static void PrintLocalizedPrefixed(this CCSPlayerController player,
    ILocalizationHandler loc, string key, params object[] args) {
    if (!player.IsReal()) return;
    var message = loc.ForPrefixed(player, key, args);
    player.PrintToChat(message);
  }
}