using TTT.Formatting.Base;

namespace TTT.Formatting.Views;

public interface IGenericCmdLocale {
  public IView InvalidParameter(string parameter, string expected);
}