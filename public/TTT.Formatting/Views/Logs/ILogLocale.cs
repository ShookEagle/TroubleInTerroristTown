using CounterStrikeSharp.API.Modules.Utils;
using TTT.Formatting.Base;
using TTT.Formatting.Core;
using TTT.Formatting.Objects;
using TTT.Public.Utils;

namespace TTT.Formatting.Views.Logs;

public interface ILogLocale {
  public IView BeginTTTLogs { get; }

  public IView EndTTTLogs { get; }

  public FormatObject Time() {
    var elapsed = RoundUtil.GetTimeElapsed();

    var minutes = Math.Floor(elapsed / 60f).ToString("00");
    var seconds = (elapsed % 60).ToString("00");

    return new StringFormatObject($"[{minutes}:{seconds}]", ChatColors.Gold);
  }

  public IView CreateLog(params FormatObject[] objects) {
    return new SimpleView { Time(), objects };
  }
}