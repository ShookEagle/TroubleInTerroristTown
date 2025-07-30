using CounterStrikeSharp.API.Core;
using TTT.Public.Mod.Roles;
using Microsoft.Extensions.DependencyInjection;
using TTT.Public.Mod.Logs;
using TTT.Public.Mod.Roles.Enum;

namespace TTT.Logs.Tags;

public class PlayerTagHelper(IServiceProvider provider) : IPlayerTag {
  private readonly Lazy<IRoleProvider?> roleProvider =
    new(provider.GetService<IRoleProvider>);
  //  Lazy-load dependencies to avoid loops, since we are a lower-level class.

  public string Tag(CCSPlayerController player) {
    if (roleProvider.Value == null) return "()";
    var roleType = roleProvider.Value.GetRole(player);
    return $"({roleType.ToShortHand()})";
  }
}