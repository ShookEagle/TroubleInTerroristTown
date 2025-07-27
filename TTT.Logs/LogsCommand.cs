using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Admin;
using CounterStrikeSharp.API.Modules.Commands;
using TTT.Public.Behaviors;
using TTT.Public.Mod.Logs;

namespace TTT.Logs;

public class LogsCommand(ILogService logs) : IPluginBehavior {
  [ConsoleCommand("css_logs")]
  [RequiresPermissionsOr("@css/ban", "@css/generic", "@css/kick")]
  public void Command_Logs(CCSPlayerController? executor, CommandInfo info) {
    logs.PrintLogs(executor);
  }
}