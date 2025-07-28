using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using Microsoft.Extensions.DependencyInjection;
using TTT.Formatting.Core;
using TTT.Formatting.Objects;
using TTT.Formatting.Views.Logs;
using TTT.Public.Generic;
using TTT.Public.Mod.Roles;
using TTT.Public.Mod.Roles.Enum;
using TTT.Roles;

namespace TTT.Logs.Tags;

public class PlayerTagHelper(IServiceProvider provider) : IRichPlayerTag {
  private readonly Lazy<IRoleFactory> roleFactory =
    new(provider.GetRequiredService<IRoleFactory>);

  private readonly Lazy<IPlayerState<RoleState>> roleState =
    new(provider.GetRequiredService<IPlayerStateFactory>().Round<RoleState>);

  //  Lazy-load dependencies to avoid loops, since we are a lower-level class.

  public FormatObject Rich(CCSPlayerController player) {
    var roleType = roleState.Value.Get(player).Type;
    var role     = roleFactory.Value.Get(roleType);

    return new StringFormatObject($"({roleType.ToShortHand()})");
  }

  public string Plain(CCSPlayerController playerController) {
    return Rich(playerController).ToPlain();
  }
}