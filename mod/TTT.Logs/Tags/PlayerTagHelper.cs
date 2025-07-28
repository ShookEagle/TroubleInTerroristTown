using CounterStrikeSharp.API.Core;
using TTT.Formatting.Core;
using TTT.Formatting.Objects;
using TTT.Formatting.Views.Logs;
using TTT.Public.Generic;
using TTT.Public.Mod.Roles.Enum;
using TTT.Roles;

namespace TTT.Logs.Tags;

public class PlayerTagHelper(IPlayerStateFactory playerStateFactory) 
  : IRichPlayerTag {

  private readonly IPlayerState<RoleState> roleState =
    playerStateFactory.Round<RoleState>();
  //  Lazy-load dependencies to avoid loops, since we are a lower-level class.

  public FormatObject Rich(CCSPlayerController player) {
    var roleType = roleState.Get(player).Type;

    return new StringFormatObject($"({roleType.ToShortHand()})");
  }

  public string Plain(CCSPlayerController playerController) {
    return Rich(playerController).ToPlain();
  }
}