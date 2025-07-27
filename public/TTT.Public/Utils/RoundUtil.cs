using CounterStrikeSharp.API;
using TTT.Public.Extensions;

namespace TTT.Public.Utils;

public class RoundUtil {
  public static int GetTimeElapsed() {
    var gamerules = ServerExtensions.GetGameRules();
    if (gamerules == null) return 0;
    var freezeTime = gamerules.FreezeTime;
    return (int)(Server.CurrentTime - gamerules.RoundStartTime - freezeTime);
  }

  public static int GetTimeRemaining() {
    var gamerules = ServerExtensions.GetGameRules();
    if (gamerules == null) return 0;
    return gamerules.RoundTime - GetTimeElapsed();
  }
}