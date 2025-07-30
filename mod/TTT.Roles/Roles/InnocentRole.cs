using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Cvars;
using TTT.Public.Extensions;
using TTT.Public.Generic;
using TTT.Public.Mod.Roles;
using TTT.Public.Mod.Roles.Enum;
using TTT.Validator;

namespace TTT.Roles.Roles;

public class InnocentRole(ILocalizationHandler localizer)
  : BaseRole(localizer) {
  public static readonly FakeConVar<int> CV_INNOCENT_RATIO = new(
    "ttt_role_innocent_ratio", "How many players per 1 traitor", -1,
    ConVarFlags.FCVAR_NONE, new NonZeroRangeValidator<int>(-1, 64));

  public static readonly FakeConVar<int> CV_INNOCENT_MAX = new(
    "ttt_role_innocent_max",
    "How many total innocents are allowed (-1 for uncapped)", -1,
    ConVarFlags.FCVAR_NONE, new NonZeroRangeValidator<int>(-1, 64));
  

  public override RoleType Type => RoleType.INNOCENT;

  public override void OnAssigned(CCSPlayerController player) {
    var role = Localizer.Get("role.innocent_name");
    player.PrintLocalizedPrefixed(Localizer, "role.declare",
      role[0].IsVowel() ? "n" : "", role);
    player.PrintLocalizedPrefixed(Localizer, "role.innocent_objective");
  }

  public override string OnScreenGraphic => "path/to/innocent/";

  public override int PlayerRatio => CV_INNOCENT_RATIO.Value;
  public override int MaxCount => CV_INNOCENT_MAX.Value;

  public override bool WinCondition(int totalAlive,
    Dictionary<RoleType, int> roleCounts) {
    roleCounts.TryGetValue(RoleType.TRAITOR, out var traitors);
    return traitors == 0;
  }
}