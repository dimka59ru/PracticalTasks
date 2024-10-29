using PracticalTasks.Task4App.Documents;

namespace PracticalTasks.Task4App.Exporters
{
  /// <summary>
  /// Базовый класс экспортера документа в папку.
  /// </summary>
  internal abstract class DocumentToFolderExporterBase : IDocumentExporter
  {
    #region Поля и свойства

    public string PathToFolder { get; }

    #endregion

    #region Методы

    public abstract void Export(IDocument item);

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="pathToFolder">Путь до папки, в которую нужно сделать экспорт.</param>
    protected DocumentToFolderExporterBase(string pathToFolder)
    {
      this.PathToFolder = pathToFolder;
    }

    #endregion
  }
}
