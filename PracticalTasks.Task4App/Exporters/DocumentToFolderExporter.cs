using PracticalTasks.Task4App.Documents;

namespace PracticalTasks.Task4App.Exporters
{
  /// <summary>
  /// Экспортер документа в папку.
  /// </summary>
  internal class DocumentToFolderExporter : DocumentToFolderExporterBase
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
        Console.WriteLine($"Документ \"{rootDocument.Name}\" экспортирован в {this.PathToFolder}");
      }
    }

    #endregion

    #region Базовый класс

    public override void Export(IDocument document)
    {
      this.InternalExport(document);

      Console.WriteLine();
      Console.WriteLine("Описание экспортированного документа:");
      Console.WriteLine(document.GetDescription());
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="pathToFolder">Путь до папки, в которую нужно сделать экспорт.</param>
    public DocumentToFolderExporter(string pathToFolder) : base(pathToFolder) { }

    #endregion
  }
}
