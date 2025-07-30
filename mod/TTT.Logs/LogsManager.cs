using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using TTT.Public.Behaviors;
using TTT.Public.Extensions;
using TTT.Public.Generic;
using TTT.Public.Mod.Logs;
using TTT.Public.Utils;

namespace TTT.Logs;

public class LogsManager(ILocalizationHandler localizer, IPlayerTag playerTag)
  : IPluginBehavior, ILogService {
  private readonly List<string> logMessages = [];
  
  public void Append(string key, params object[] args) {
    logMessages.Add($"{time()} {localizer.Get(key, args)}");
  }

  public IEnumerable<string> GetMessages() {
    return logMessages;
  }

  public void Clear() { logMessages.Clear(); }

  public void PrintLogs(CCSPlayerController? player) {
    if (player == null || !player.IsReal()) {
      Server.PrintToConsole(localizer.Get("logs.begin"));
      foreach (var log in logMessages) Server.PrintToConsole(log);
      Server.PrintToConsole(localizer.Get("logs.end"));
      return;
    }


    player.PrintLocalized(localizer, "logs.begin");
    foreach (var log in logMessages) player.PrintToChat(log);
    player.PrintLocalized(localizer, "logs.end");
  }

  public void Append(Dictionary<string, object[]> objects) {
    foreach (var (key, args) in objects)
      logMessages.Add($"{time()} {localizer.Get(key, args)}");
  }

  public string Player(CCSPlayerController playerController) {
    return $"[{playerController.UserId}] {playerTag.Tag(playerController)}";
  }
  
  private string time() {
    var elapsed = RoundUtil.GetTimeElapsed();

    var minutes = Math.Floor(elapsed / 60f).ToString("00");
    var seconds = (elapsed % 60).ToString("00");

    return $"[{minutes}:{seconds}]";
  }

  [GameEventHandler]
  public HookResult OnRoundEnd(EventRoundEnd @event, GameEventInfo info) {
    foreach (var player in Utilities.GetPlayers()) {
      player.PrintLocalized(localizer, "logs.begin");
      foreach (var log in logMessages) player.PrintToChat(log);
      player.PrintLocalized(localizer, "logs.end");
    }

    Server.PrintToConsole(localizer.Get("logs.begin"));
    foreach (var log in logMessages) Server.PrintToConsole(log);
    Server.PrintToConsole(localizer.Get("logs.end"));
    return HookResult.Continue;
  }

  [GameEventHandler]
  public HookResult OnRoundStart(EventRoundStart @event, GameEventInfo info) {
    Clear();
    return HookResult.Continue;
  }
}