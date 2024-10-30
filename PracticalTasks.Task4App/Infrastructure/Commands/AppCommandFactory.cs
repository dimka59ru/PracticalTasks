namespace PracticalTasks.Task4App.Infrastructure.Commands
{
  /// <summary>
  /// Фабрика команд.
  /// </summary>
  internal class AppCommandFactory : IAppCommandFactory
  {
    #region Поля и свойства

    /// <summary>
    /// Пользовательский интерфейс.
    /// </summary>
    private readonly IUserInterface userInterface;

    #endregion

    #region IAppCommandFactory

    public AppCommand GetCommand(string input)
    {
      return input.ToLower() switch
      {
        "t" or "transfer" => new ExportDocumentCommand(this.userInterface),
        "q" or "quit" => new QuitCommand(this.userInterface),
        "?" => new HelpCommand(this.userInterface),
        _ => new UnknownCommand(this.userInterface),
      };
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="userInterface">Пользовательский интерфейс.</param>
    /// <exception cref="ArgumentNullException">Если userInterface null, то будет выброшено исключение.</exception>
    public AppCommandFactory(IUserInterface userInterface)
    {
      this.userInterface = userInterface ?? throw new ArgumentNullException(nameof(userInterface));
    }

    #endregion
  }
}
