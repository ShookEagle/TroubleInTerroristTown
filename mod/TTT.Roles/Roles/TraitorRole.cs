using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Modules.Cvars;
using CounterStrikeSharp.API.Modules.Cvars.Validators;
using CounterStrikeSharp.API.Modules.Utils;
using TTT.English.Roles;
using TTT.Formatting.Views.Roles;
using TTT.Public.Mod.Roles;
using TTT.Validator;

namespace TTT.Roles.Roles;

public class TraitorRole : BaseRole {
  public static readonly FakeConVar<int> CV_TRAITOR_RATIO = new(
    "ttt_role_traitor_ratio", "How many players per 1 traitor", 3,
    ConVarFlags.FCVAR_NONE, new NonZeroRangeValidator<int>(-1, 64));

  public static readonly FakeConVar<int> CV_TRAITOR_MAX = new(
    "ttt_role_traitor_max",
    "How many total traitors are allowed (-1 for uncapped)", -1,
    ConVarFlags.FCVAR_NONE, new NonZeroRangeValidator<int>(-1, 64));
  
  public override RoleType Type => RoleType.TRAITOR;
  
  public override IRoleLocale Locale
    => new RoleLocale("Innocent", ChatColors.Red,
      "Eliminate the innocents without being caught.");
  
  public override string OnScreenGraphic => "path/to/traitor/";
  public override string OverheadIcon => "path/to/traitor/";
  
  public override int PlayerRatio => CV_TRAITOR_RATIO.Value;
  public override int MaxCount => CV_TRAITOR_MAX.Value;
}