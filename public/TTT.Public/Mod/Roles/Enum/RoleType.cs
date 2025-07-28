namespace TTT.Public.Mod.Roles.Enum;

public enum RoleType {
  INNOCENT,
  DETECTIVE,
  TRAITOR
}

public static class RoleTypeExtensions {
  public static string ToShortHand(this RoleType type) {
    return type switch {
      RoleType.INNOCENT  => "I",
      RoleType.DETECTIVE => "D",
      RoleType.TRAITOR   => "T",
      _                  => string.Empty
    };
  }
}