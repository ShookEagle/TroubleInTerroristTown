using CounterStrikeSharp.API.Core;
using TTT.Formatting.Core;
using TTT.Formatting.Objects;
using TTT.Formatting.Views.Logs;
using TTT.Public.Mod.Roles;
using Microsoft.Extensions.DependencyInjection;
using TTT.Public.Mod.Roles.Enum;

namespace TTT.Logs.Tags;

public class PlayerTagHelper(IServiceProvider provider) : IRichPlayerTag {
  private readonly Lazy<IRoleProvider?> roleProvider =
    new(provider.GetService<IRoleProvider>);
  //  Lazy-load dependencies to avoid loops, since we are a lower-level class.

  public FormatObject Rich(CCSPlayerController player) {
    if (roleProvider.Value == null) return new StringFormatObject("()");
    var roleType = roleProvider.Value.GetRole(player);
    return new StringFormatObject($"({roleType.ToShortHand()})");
  }

  public string Plain(CCSPlayerController playerController) {
    return Rich(playerController).ToPlain();
  }
}