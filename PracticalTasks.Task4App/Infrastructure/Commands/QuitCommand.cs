namespace PracticalTasks.Task4App.Infrastructure.Commands
{
  /// <summary>
  /// Команда завершения работы программы.
  /// </summary>
  internal class QuitCommand : AppCommand
  {
    #region Базовый класс

    protected override bool InternalCommand()
    {
      this.UserInterface.WriteMessage("Спасибо, до свидания!");
      return true;
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="userInterface">Пользовательский интерфейс.</param>
    public QuitCommand(IUserInterface userInterface) : base(true, userInterface) { }

    #endregion
  }
}
