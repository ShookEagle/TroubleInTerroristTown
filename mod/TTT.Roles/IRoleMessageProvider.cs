using TTT.Formatting.Views.Roles;

namespace TTT.Roles;

public interface IRoleMessageProvider {
  public IRoleLocale Locale { get; }
}