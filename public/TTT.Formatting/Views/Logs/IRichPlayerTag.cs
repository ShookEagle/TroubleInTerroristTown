using CounterStrikeSharp.API.Core;
using TTT.Formatting.Core;
using TTT.Public.Mod.Logs;

namespace TTT.Formatting.Views.Logs;

public interface IRichPlayerTag : IPlayerTag {
  /// <summary>
  ///   Get a tag for this player, which contains context about the player's current actions
  /// </summary>
  /// <param name="player"></param>
  /// <returns></returns>
  FormatObject Rich(CCSPlayerController player);
}