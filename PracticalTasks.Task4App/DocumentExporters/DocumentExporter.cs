using PracticalTasks.Task4App.Documents;

namespace PracticalTasks.Task4App.DocumentExporters
{
  /// <summary>
  /// Экспортер документа.
  /// </summary>
  internal class DocumentExporter : IDocumentExporter
  {
    #region Методы

    /// <summary>
    /// Обходит дочерние документы и экспортирует их.
    /// </summary>
    /// <param name="rootDocument">Корневой документ.</param>
    private void InternalExport(IDocument rootDocument)
    {
      if (rootDocument is ICompoundDocument compoundDocument)
      {
        foreach (var doc in compoundDocument.Children)
        {
          this.InternalExport(doc);
        }
      }
      else
      {
        Console.WriteLine($"Документ \"{rootDocument.Name}\" экспортирован в {this.PathToExport}");
      }
    }

    #endregion

    #region IDocumentExporter

    public IDocument Document { get; }

    public string PathToExport { get; }

    public void Export()
    {
      this.InternalExport(this.Document);

      Console.WriteLine();
      Console.WriteLine("Описание экспортированного документа:");
      Console.WriteLine(this.Document.GetDescription());
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="document">Документ, который надо экспортировать.</param>
    /// <param name="pathToExport">Путь до папки, в которую нужно сделать экспорт.</param>
    /// <exception cref="ArgumentException">Если путь до папки не задан, то будет выброшено исключение.</exception>
    /// <exception cref="ArgumentNullException">Если документ null, то будет выброшено исключение.</exception>
    public DocumentExporter(IDocument document, string pathToExport)
    {
      if (string.IsNullOrEmpty(pathToExport))
      {
        throw new ArgumentException($"'{nameof(pathToExport)}' cannot be null or empty.", nameof(pathToExport));
      }

      this.Document = document ?? throw new ArgumentNullException(nameof(document));
      this.PathToExport = pathToExport;
    }

    #endregion
  }
}
