using CounterStrikeSharp.API.Core;
using TTT.Formatting.Core;
using TTT.Public.Mod.Logs;

namespace TTT.Formatting.Views.Logs;

public interface IRichLogService : ILogService {
  void Append(params FormatObject[] objects);

  FormatObject Player(CCSPlayerController playerController);
}