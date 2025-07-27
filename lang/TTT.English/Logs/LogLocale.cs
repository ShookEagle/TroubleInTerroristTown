using TTT.Formatting.Base;
using TTT.Formatting.Views.Logs;

namespace TTT.English.Logs;

public class LogLocale : ILogLocale {
  public IView BeginTTTLogs
    => new SimpleView {
      "********************************",
      SimpleView.NEWLINE,
      "******** BEGIN TTT LOGS ********",
      SimpleView.NEWLINE,
      "********************************"
    };

  public IView EndTTTLogs
    => new SimpleView {
      "********************************",
      SimpleView.NEWLINE,
      "********* END TTT LOGS *********",
      SimpleView.NEWLINE,
      "********************************"
    };
}