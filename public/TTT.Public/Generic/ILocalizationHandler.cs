using CounterStrikeSharp.API.Core;

namespace TTT.Public.Generic;

public interface ILocalizationHandler {
  string Get(string key, params object[] args);
  string GetPrefixed(string key, params object[] args);
  string For(CCSPlayerController player, string key, params object[] args);

  string ForPrefixed(CCSPlayerController player, string key,
    params object[] args);
}