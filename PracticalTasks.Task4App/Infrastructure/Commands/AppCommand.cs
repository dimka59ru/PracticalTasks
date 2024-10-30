namespace PracticalTasks.Task4App.Infrastructure.Commands
{
  /// <summary>
  /// Базовый класс команды.
  /// </summary>
  internal abstract class AppCommand
  {
    #region Поля и свойства

    /// <summary>
    /// Является ли команда завершающей.
    /// </summary>
    private readonly bool isTerminatingCommand;

    /// <summary>
    /// Пользовательский интерфейс.
    /// </summary>
    protected IUserInterface UserInterface { get; }

    #endregion

    #region Методы

    /// <summary>
    /// Запускает команду.
    /// </summary>
    /// <returns>wasSuccessful - успешно ли выполнена команда, souldQuit - должны ли завершить работу.</returns>
    public virtual (bool wasSuccessful, bool souldQuit) Run()
    {
      return (this.InternalCommand(), this.isTerminatingCommand);
    }

    /// <summary>
    /// Считывает параметры.
    /// </summary>
    /// <param name="parameterName">Имя праметра.</param>
    /// <returns>Значение параметра.</returns>
    internal string? GetParameter(string parameterName)
    {
      return this.UserInterface.ReadValue($"Введите {parameterName}: ");
    }

    /// <summary>
    /// Внутренняя реализация команды.
    /// </summary>
    /// <returns>Успешно ли выполнена команда.</returns>
    protected abstract bool InternalCommand();

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="commandIsTerminating">Является ли команда завершающей.</param>
    /// <param name="userInterface">Пользовательский интерфейс.</param>
    /// <exception cref="ArgumentNullException">Если UserInterface null, то будет выброшено исключение.</exception>
    protected AppCommand(bool commandIsTerminating, IUserInterface userInterface)
    {
      this.isTerminatingCommand = commandIsTerminating;
      this.UserInterface = userInterface ?? throw new ArgumentNullException(nameof(userInterface));
    }

    #endregion
  }
}
