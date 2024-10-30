namespace PracticalTasks.Task4App.Infrastructure
{
  /// <summary>
  /// Пользовательский интерфейс.
  /// </summary>
  internal interface IUserInterface
  {
    /// <summary>
    /// Считать сообщение.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    /// <returns></returns>
    string ReadValue(string message);

    /// <summary>
    /// Вывести сообщение.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    void WriteMessage(string message);

    /// <summary>
    /// Вывести предупреждение.
    /// </summary>
    /// <param name="message">Текст предупреждения.</param>
    void WriteWarning(string message);
  }
}
