using System.Drawing;
using CounterStrikeSharp.API.Core;
using TTT.Public.Extensions;
using TTT.Public.Mod.Roles.Enum;

namespace TTT.Public.Mod.Roles;

public abstract class BaseRole {
  public abstract RoleType Type { get; }
  public abstract string OnScreenGraphic { get; }
  public virtual string OverheadIcon => string.Empty;
  
  

  /// <summary>
  /// How many players per 1 of this role (e.g. 4 means 1 per 4 players).
  /// Use -1 for unlimited/overflow roles (like Innocent).
  /// </summary>
  public abstract int PlayerRatio { get; }

  /// <summary>
  /// Maximum number of players that can be assigned this role.
  /// Use -1 for no cap.
  /// </summary>
  public abstract int MaxCount { get; }

  /// <summary>
  ///   Fired when the Role is assigned into the start of the round.
  /// </summary>
  public virtual void OnAssigned(CCSPlayerController player) { }

  /// <summary>
  ///   Called when a round ends to allow cleanup
  /// </summary>
  public virtual void OnRoundEnd(CCSPlayerController player) {
    player.SetColor(Color.FromArgb(255, 255, 255, 255));
  }

  /// <summary>
  ///   Called to determine if this role's team has won
  /// </summary>
  public virtual bool WinCondition(int totalAlive,
    Dictionary<RoleType, int> roleCounts)
    => false;
}