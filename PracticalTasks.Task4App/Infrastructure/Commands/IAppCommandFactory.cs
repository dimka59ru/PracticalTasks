namespace PracticalTasks.Task4App.Infrastructure.Commands
{
  /// <summary>
  /// Фабрика комманд.
  /// </summary>
  internal interface IAppCommandFactory
  {
    /// <summary>
    /// Получить команду.
    /// </summary>
    /// <param name="name">Название команды</param>
    /// <returns>Команда.</returns>
    AppCommand GetCommand(string name);
  }
}
