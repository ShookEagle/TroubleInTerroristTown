using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using TTT.Formatting.Core;
using TTT.Formatting.Objects;
using TTT.Formatting.Views.Logs;

namespace TTT.Logs.Tags;

public class PlayerTagHelper(IServiceProvider provider) : IRichPlayerTag {
  //TODO: Lazy Load Player Role Services

  //  Lazy-load dependencies to avoid loops, since we are a lower-level class.

  public FormatObject Rich(CCSPlayerController player) {
    //TODO: Format Player Tags
    
    return new StringFormatObject("(I)", ChatColors.Yellow);
  }

  public string Plain(CCSPlayerController playerController) {
    return Rich(playerController).ToPlain();
  }
}