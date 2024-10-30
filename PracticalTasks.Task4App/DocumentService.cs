using PracticalTasks.Task4App.Infrastructure;
using PracticalTasks.Task4App.Infrastructure.Commands;

namespace PracticalTasks.Task4App
{
  /// <summary>
  /// Сервис работы с документами.
  /// </summary>
  internal class DocumentService : IDocumentService
  {
    #region Поля и свойства

    /// <summary>
    /// Пользовательский интерфейс.
    /// </summary>
    private readonly IUserInterface userInterface;

    /// <summary>
    /// Файрика команд.
    /// </summary>
    private readonly IAppCommandFactory commandFactory;

    #endregion

    #region IDocumentService

    public void Run()
    {
      var response = this.commandFactory.GetCommand("?").Run();

      while (!response.souldQuit)
      {
        var input = this.userInterface.ReadValue("\r\n> ");
        var command = this.commandFactory.GetCommand(input);
        response = command.Run();

        if (!response.wasSuccessful)
        {
          this.userInterface.WriteMessage("Введите ? для получения справки по командам.");
        }
      }
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="userInterface">Пользовательский интерфейс.</param>
    /// <param name="commandFactory">Фабрика команд.</param>
    /// <exception cref="ArgumentNullException">Если userInterface и/или commandFactory null, то будет выброшено исключение.</exception>
    public DocumentService(IUserInterface userInterface, IAppCommandFactory commandFactory)
    {
      this.userInterface = userInterface ?? throw new ArgumentNullException(nameof(userInterface));
      this.commandFactory = commandFactory ?? throw new ArgumentNullException(nameof(commandFactory));
    }

    #endregion
  }
}
