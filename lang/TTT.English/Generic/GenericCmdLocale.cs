using CounterStrikeSharp.API.Modules.Utils;
using TTT.Formatting.Base;
using TTT.Formatting.Core;
using TTT.Formatting.Objects;
using TTT.Formatting.Views;
using TTT.Public.Extensions;

namespace TTT.English.Generic;

public class GenericCmdLocale : IGenericCmdLocale {
  private static readonly FormatObject PREFIX =
    new HiddenFormatObject($" {ChatColors.DarkBlue}Server>") {
      //	Hide in panorama and center text
      Plain = false, Panorama = false, Chat = true
    };
  
  public IView InvalidParameter(string parameter, string expected) {
    return new SimpleView {
      PREFIX,
      $"Invalid parameter '{ChatColors.BlueGrey}{parameter}{ChatColors.Grey}',",
      "expected a" + (expected[0].IsVowel() ? "n" : ""),
      $"{ChatColors.BlueGrey}{expected}{ChatColors.Grey}."
    };
  }
}