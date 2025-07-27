using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using TTT.Formatting.Base;
using TTT.Formatting.Core;
using TTT.Formatting.Extensions;
using TTT.Formatting.Objects;
using TTT.Formatting.Views.Logs;
using TTT.Public.Behaviors;
using TTT.Public.Extensions;

namespace TTT.Logs;

public class LogsManager(ILogLocale locale, IRichPlayerTag richPlayerTag)
  : IPluginBehavior, IRichLogService {
  private readonly List<IView> logMessages = [];
  
  public void Append(string message) {
    logMessages.Add(locale.CreateLog(message));
  }

  public IEnumerable<string> GetMessages() {
    return logMessages.SelectMany(view => view.ToWriter().Plain);
  }

  public void Clear() { logMessages.Clear(); }

  public void PrintLogs(CCSPlayerController? player) {
    if (player == null || !player.IsReal()) {
      locale.BeginTTTLogs.ToServerConsole();
      foreach (var log in logMessages) log.ToServerConsole();
      locale.EndTTTLogs.ToServerConsole();
      return;
    }


    locale.BeginTTTLogs.ToConsole(player);
    foreach (var log in logMessages) log.ToConsole(player);
    locale.EndTTTLogs.ToConsole(player);
  }

  public void Append(params FormatObject[] objects) {
    logMessages.Add(locale.CreateLog(objects));
  }

  public FormatObject Player(CCSPlayerController playerController) {
    return new TreeFormatObject {
      playerController,
      $"[{playerController.UserId}]",
      richPlayerTag.Rich(playerController)
    };
  }

  [GameEventHandler]
  public HookResult OnRoundEnd(EventRoundEnd @event, GameEventInfo info) {
    locale.BeginTTTLogs.ToServerConsole().ToAllConsole();

    //  By default, print all logs to player consoles at the end of the round.
    foreach (var log in logMessages) log.ToServerConsole().ToAllConsole();

    locale.EndTTTLogs.ToServerConsole().ToAllConsole();
    return HookResult.Continue;
  }

  [GameEventHandler]
  public HookResult OnRoundStart(EventRoundStart @event, GameEventInfo info) {
    Clear();
    return HookResult.Continue;
  }
}