using CounterStrikeSharp.API.Core;

namespace TTT.Public.Mod.Logs;

public interface ILogService {
  void Append(string key, params object[] args);
  IEnumerable<string> GetMessages();
  void Clear();
  void PrintLogs(CCSPlayerController? player);
  void Append(Dictionary<string, object[]> objects);
  string Player(CCSPlayerController playerController);
}