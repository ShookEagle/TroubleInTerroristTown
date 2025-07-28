using System.Drawing;
using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Cvars;
using CounterStrikeSharp.API.Modules.Utils;
using TTT.English.Roles;
using TTT.Formatting.Extensions;
using TTT.Formatting.Views.Roles;
using TTT.Public.Extensions;
using TTT.Public.Mod.Roles;
using TTT.Validator;

namespace TTT.Roles.Roles;

public class DetectiveRole : BaseRole {
  public static readonly FakeConVar<int> CV_DETECTIVE_RATIO = new(
    "ttt_role_detective_ratio", "How many players per 1 traitor", 8,
    ConVarFlags.FCVAR_NONE, new NonZeroRangeValidator<int>(-1, 64));
  
  public static readonly FakeConVar<int> CV_DETECTIVE_MAX = new(
    "ttt_role_detective_max",
    "How many total detectives are allowed (-1 for uncapped)", 3,
    ConVarFlags.FCVAR_NONE, new NonZeroRangeValidator<int>(-1, 64));
  
  public override RoleType Type => RoleType.DETECTIVE;
  
  public virtual IRoleLocale Locale
    => new RoleLocale("Detective", ChatColors.Blue,
      "Find the traitors and protect the innocents.");
  
  public override string OnScreenGraphic => "path/to/detective/";
  public override string OverheadIcon => "path/to/detective/";
  
  public override int PlayerRatio => CV_DETECTIVE_RATIO.Value;
  public override int MaxCount => CV_DETECTIVE_MAX.Value;

  public override void OnAssigned(CCSPlayerController player) {
    player.SetColor(Color.Blue);
    player.SwitchTeam(CsTeam.CounterTerrorist);
    Locale.TellRole().ToChat(player);
    base.OnAssigned(player);
  }
}