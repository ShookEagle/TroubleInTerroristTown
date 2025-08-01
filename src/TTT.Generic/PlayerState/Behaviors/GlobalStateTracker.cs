﻿using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using TTT.Public.Behaviors;

namespace TTT.Generic.PlayerState.Behaviors;

public class GlobalStateTracker : BaseStateTracker, IPluginBehavior {
  public void Start(BasePlugin basePlugin) { }

  /// <summary>
  ///   Disconnect handler to reset states on user leave
  /// </summary>
  /// <param name="ev"></param>
  /// <param name="info"></param>
  [GameEventHandler]
  public HookResult OnDisconnect(EventPlayerDisconnect ev, GameEventInfo info) {
    if (ev.Userid != null) Reset(ev.Userid);
    return HookResult.Continue;
  }

  /// <summary>
  ///   Reset all global states when a new game starts
  /// </summary>
  /// <param name="ev"></param>
  /// <param name="info"></param>
  /// <returns></returns>
  public HookResult OnGameEnd(EventGameEnd ev, GameEventInfo info) {
    ResetAll();
    return HookResult.Continue;
  }
}