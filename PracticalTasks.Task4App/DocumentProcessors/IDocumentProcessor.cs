namespace PracticalTasks.Task4App.DocumentProcessors
{
  /// <summary>
  /// Процессор документа.
  /// </summary>
  internal interface IDocumentProcessor
  {
    /// <summary>
    /// Обработать документ.
    /// </summary>
    /// <param name="id">Id документа.</param>
    /// <returns>Успешен ли процесс.</returns>
    bool Process(int id);
  }
}
