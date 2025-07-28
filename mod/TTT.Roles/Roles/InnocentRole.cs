using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Cvars;
using CounterStrikeSharp.API.Modules.Utils;
using TTT.English.Roles;
using TTT.Formatting.Extensions;
using TTT.Formatting.Views.Roles;
using TTT.Public.Mod.Roles;
using TTT.Public.Mod.Roles.Enum;
using TTT.Validator;

namespace TTT.Roles.Roles;

public class InnocentRole : BaseRole {
  public static readonly FakeConVar<int> CV_INNOCENT_RATIO = new(
    "ttt_role_innocent_ratio", "How many players per 1 traitor", -1,
    ConVarFlags.FCVAR_NONE, new NonZeroRangeValidator<int>(-1, 64));
  
  public static readonly FakeConVar<int> CV_INNOCENT_MAX = new(
    "ttt_role_innocnet_max",
    "How many total innocents are allowed (-1 for uncapped)", -1,
    ConVarFlags.FCVAR_NONE, new NonZeroRangeValidator<int>(-1, 64));
  
  public override RoleType Type => RoleType.INNOCENT;

  public virtual IRoleLocale Locale
    => new RoleLocale("Innocent", ChatColors.Green,
      "Survive and find the traitors before they kill all the players.");
  
  public override void OnAssigned(CCSPlayerController player) {
    Locale.TellRole().ToChat(player);
  }
  
  public override string OnScreenGraphic => "path/to/innocent/";
  
  public override int PlayerRatio => CV_INNOCENT_RATIO.Value;
  public override int MaxCount => CV_INNOCENT_MAX.Value;
}