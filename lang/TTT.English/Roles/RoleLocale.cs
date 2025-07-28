using CounterStrikeSharp.API.Modules.Utils;
using TTT.Formatting.Base;
using TTT.Formatting.Core;
using TTT.Formatting.Objects;
using TTT.Formatting.Views.Roles;
using TTT.Public.Extensions;
using TTT.Public.Mod.Roles;

namespace TTT.English.Roles;

public class RoleLocale(string name, params string[] description) : IRoleLocale {
  public string Name => name;
  public string[] Description => description;
  
  private static readonly FormatObject PREFIX =
    new HiddenFormatObject($" {ChatColors.DarkBlue}Role>") {
      Plain = false, Panorama = false, Chat = true
    };
  
  public IView TellRole() {
    var result = new SimpleView {
      PREFIX,
      { "You are a" + (Name[0].IsVowel() ? "n" : ""), Name, "\n" }
    };
    
    if (description.Length == 0) return result;

    result.Add(description[0]);

    for (var i = 1; i < description.Length; i++) {
      result.Add(SimpleView.NEWLINE);
      result.Add(PREFIX);
      result.Add(description[i]);
    }

    return result;
  }
}