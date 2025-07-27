using CounterStrikeSharp.API.Core;

namespace TTT.Public.Mod.Logs;

public interface ILogService {
  void Append(string message);
  IEnumerable<string> GetMessages();
  void Clear();
  void PrintLogs(CCSPlayerController? player);
}