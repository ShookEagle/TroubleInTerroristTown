using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Translations;
using CounterStrikeSharp.API.Modules.Utils;
using Microsoft.Extensions.Localization;
using TTT.Public.Behaviors;
using TTT.Public.Extensions;
using TTT.Public.Generic;

namespace TTT.Generic.Localization;

public class LocalizationHandler()
  : IPluginBehavior, ILocalizationHandler {
  private BasePlugin plugin = null!;
  private IStringLocalizer localizer = null!;

  public void Start(BasePlugin basePlugin) {
    plugin    = basePlugin;
    localizer = plugin.Localizer;
  }

  public string Get(string key, params object[] args) => localizer[key, args];

  public string GetPrefixed(string key, params object[] args) {
    var fullKey = EnsurePrefix(key);
    return localizer[fullKey, args];
  }

  public string For(CCSPlayerController player, string key,
    params object[] args)
    => localizer.ForPlayer(player, key, args);

  public string ForPrefixed(CCSPlayerController player, string key,
    params object[] args) {
    var fullKey = EnsurePrefix(key);
    return localizer.ForPlayer(player, fullKey, args);
  }

  private static string EnsurePrefix(string key) {
    return key.Contains('.') ? key : $"role.{key}";
  }
}