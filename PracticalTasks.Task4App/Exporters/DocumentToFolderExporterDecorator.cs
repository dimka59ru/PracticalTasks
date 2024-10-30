using PracticalTasks.Task4App.Documents;

namespace PracticalTasks.Task4App.Exporters
{
  /// <summary>
  /// Базовый декоратор для экспортера документов.
  /// </summary>
  internal abstract class DocumentToFolderExporterDecorator : DocumentToFolderExporterBase
  {
    #region Поля и свойства

    /// <summary>
    /// Декорируемый экспортер документов.
    /// </summary>
    protected DocumentToFolderExporterBase DocumentExporter { get; }

    #endregion

    #region Базовый класс

    public override void Export(IDocument document)
    {
      this.DocumentExporter.Export(document);
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="documentExporter">Декторируемый экспортер.</param>
    /// <exception cref="ArgumentNullException">Если documentExporter null, то будет выброшено исключение.</exception>
    public DocumentToFolderExporterDecorator(DocumentToFolderExporterBase documentExporter) : base(documentExporter.PathToFolder)
    {
      this.DocumentExporter = documentExporter ?? throw new ArgumentNullException(nameof(documentExporter));
    }

    #endregion
  }
}
