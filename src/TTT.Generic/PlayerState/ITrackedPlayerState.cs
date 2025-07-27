using CounterStrikeSharp.API.Core;
using TTT.Public.Generic;

namespace TTT.Generic.PlayerState;

public interface ITrackedPlayerState {
  /// <summary>
  ///   Reset a state for a specific player
  /// </summary>
  /// <param name="controller"></param>
  void Reset(CCSPlayerController controller);

  /// <summary>
  ///   Reset states for all players
  /// </summary>
  void Drop();
}