namespace PracticalTasks.Task4App.Documents
{
  /// <summary>
  /// Составной документ.
  /// </summary>
  internal interface ICompoundDocument : IDocument
  {
    /// <summary>
    /// Добавление документа в составной документ.
    /// </summary>
    /// <param name="document">Документ.</param>
    void AddDocument(IDocument document);
  }
}
