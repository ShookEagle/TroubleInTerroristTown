using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using TTT.Public.Behaviors;

namespace TTT.Generic.PlayerState.Behaviors;

public class AliveStateTracker : BaseStateTracker, IPluginBehavior {
  public void Start(BasePlugin basePlugin) { }

  [GameEventHandler]
  public HookResult OnDeath(EventPlayerDeath ev, GameEventInfo info) {
    if (ev.Userid != null) Reset(ev.Userid);
    return HookResult.Continue;
  }
}