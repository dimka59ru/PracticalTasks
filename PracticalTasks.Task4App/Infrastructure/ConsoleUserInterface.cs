namespace PracticalTasks.Task4App.Infrastructure
{
  /// <summary>
  /// Консольный пользовательский инфрефейс.
  /// </summary>
  internal class ConsoleUserInterface : IUserInterface
  {
    #region IUserInterface

    public string ReadValue(string message)
    {
      Console.ForegroundColor = ConsoleColor.Green;
      Console.Write(message);
      return Console.ReadLine() ?? string.Empty;
    }

    public void WriteMessage(string message)
    {
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine(message);
    }

    public void WriteWarning(string message)
    {
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine(message);
    }

    #endregion
  }
}
