using System.Drawing;
using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Cvars;
using CounterStrikeSharp.API.Modules.Utils;
using TTT.Public.Extensions;
using TTT.Public.Generic;
using TTT.Public.Mod.Roles;
using TTT.Public.Mod.Roles.Enum;
using TTT.Validator;

namespace TTT.Roles.Roles;

public class DetectiveRole(ILocalizationHandler localizer)
  : BaseRole(localizer) {
  public static readonly FakeConVar<int> CV_DETECTIVE_RATIO = new(
    "ttt_role_detective_ratio", "How many players per 1 traitor", 8,
    ConVarFlags.FCVAR_NONE, new NonZeroRangeValidator<int>(-1, 64));
  
  public static readonly FakeConVar<int> CV_DETECTIVE_MAX = new(
    "ttt_role_detective_max",
    "How many total detectives are allowed (-1 for uncapped)", 3,
    ConVarFlags.FCVAR_NONE, new NonZeroRangeValidator<int>(-1, 64));
  
  public override RoleType Type => RoleType.DETECTIVE;
  
  public override string OnScreenGraphic => "path/to/detective/";
  public override string OverheadIcon => "path/to/detective/";
  
  public override int PlayerRatio => CV_DETECTIVE_RATIO.Value;
  public override int MaxCount => CV_DETECTIVE_MAX.Value;

  public override void OnAssigned(CCSPlayerController player) {
    player.SetColor(Color.Blue);
    player.SwitchTeam(CsTeam.CounterTerrorist);
    var role = Localizer.Get("role.detective_name");
    player.PrintLocalizedPrefixed(Localizer, "role.declare",
      role[0].IsVowel() ? "n" : "", role);
    player.PrintLocalizedPrefixed(Localizer, "role.detective_objective");
    base.OnAssigned(player);
  }
}