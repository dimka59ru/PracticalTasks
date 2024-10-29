namespace PracticalTasks.Task4App.Documents
{
  /// <summary>
  /// Составной документ.
  /// </summary>
  internal interface ICompoundDocument : IDocument
  {
    /// <summary>
    /// Документы, которые входят в состав текущего.
    /// </summary>
    public IEnumerable<IDocument> Children { get; }

    /// <summary>
    /// Добавление документа в составной документ.
    /// </summary>
    /// <param name="document">Документ.</param>
    void AddDocument(IDocument document);
  }
}
