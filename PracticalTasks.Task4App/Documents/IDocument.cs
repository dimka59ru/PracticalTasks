namespace PracticalTasks.Task4App.Documents
{
  /// <summary>
  /// Документ.
  /// </summary>
  internal interface IDocument
  {
    /// <summary>
    /// Идентификатор документа.
    /// </summary>
    int Id { get; }

    /// <summary>
    /// Название докумета.
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// Получить описание документа.
    /// </summary>
    /// <returns>Форматированный в виде дерева текст.</returns>
    string GetDescription();
  }
}
