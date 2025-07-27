using TTT.Formatting.Core;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using TTT.Public.Extensions;


namespace TTT.Formatting.Objects;

public class PlayerFormatObject(CCSPlayerController player) : FormatObject {
  private readonly string name = player.PlayerName;
  private readonly CsTeam team = player.Team;

  public override string ToChat() {
    return $"{TeamFormatObject.GetChatColor(team)}{name}";
  }

  public override string ToPanorama() { return name.Sanitize(); }

  public override string ToPlain() { return name; }
}