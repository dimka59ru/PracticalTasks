namespace PracticalTasks.Task4App.Infrastructure.Commands
{
  /// <summary>
  /// Неизвестная комманда.
  /// </summary>
  internal class UnknownCommand : NonTerminatingCommand
  {
    #region Базовый класс

    protected override bool InternalCommand()
    {
      this.UserInterface.WriteWarning("Не удалось распознать команду.");
      return false;
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="userInterface">Пользовательский интерфейс.</param>
    public UnknownCommand(IUserInterface userInterface) : base(userInterface) { }

    #endregion
  }
}
