using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Cvars;
using TTT.Public.Extensions;
using TTT.Public.Generic;
using TTT.Public.Mod.Roles;
using TTT.Public.Mod.Roles.Enum;
using TTT.Validator;

namespace TTT.Roles.Roles;

public class TraitorRole(ILocalizationHandler localizer)
: BaseRole(localizer) {
  public static readonly FakeConVar<int> CV_TRAITOR_RATIO = new(
    "ttt_role_traitor_ratio", "How many players per 1 traitor", 3,
    ConVarFlags.FCVAR_NONE, new NonZeroRangeValidator<int>(-1, 64));

  public static readonly FakeConVar<int> CV_TRAITOR_MAX = new(
    "ttt_role_traitor_max",
    "How many total traitors are allowed (-1 for uncapped)", -1,
    ConVarFlags.FCVAR_NONE, new NonZeroRangeValidator<int>(-1, 64));
  
  public override RoleType Type => RoleType.TRAITOR;
  
  public override void OnAssigned(CCSPlayerController player) {
    var role = Localizer.Get("role.traitor_name");
    player.PrintLocalizedPrefixed(Localizer, "role.declare",
      role[0].IsVowel() ? "n" : "", role);
    player.PrintLocalizedPrefixed(Localizer, "role.traitor_objective");
  }
  
  public override string OnScreenGraphic => "path/to/traitor/";
  public override string OverheadIcon => "path/to/traitor/";
  
  public override int PlayerRatio => CV_TRAITOR_RATIO.Value;
  public override int MaxCount => CV_TRAITOR_MAX.Value;

  public override bool WinCondition(int totalAlive,
    Dictionary<RoleType, int> roleCounts) {
    // Traitors win when all innocents + detectives are dead
    var innocent  = roleCounts.GetValueOrDefault(RoleType.INNOCENT);
    var detective = roleCounts.GetValueOrDefault(RoleType.DETECTIVE);
    return innocent + detective == 0;
  }
}