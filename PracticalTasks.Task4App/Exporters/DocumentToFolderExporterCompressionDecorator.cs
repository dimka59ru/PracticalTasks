using PracticalTasks.Task4App.Documents;

namespace PracticalTasks.Task4App.Exporters
{
  /// <summary>
  /// Декторатор для экспортера документов.
  /// Упаковывает документы в архив.
  /// </summary>
  internal class DocumentToFolderExporterCompressionDecorator : DocumentToFolderExporterDecorator
  {
    #region Методы

    /// <summary>
    /// Упаковать в архив.
    /// </summary>
    private void Compress(IDocument document)
    {
      Console.WriteLine($"Документы в папке {this.DocumentExporter.PathToFolder} упакованы в архив с именем \"{document.Name}\".");
    }

    #endregion

    #region Базовый класс

    public override void Export(IDocument document)
    {
      this.DocumentExporter.Export(document);
      this.Compress(document);
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструкторы.
    /// </summary>
    /// <param name="documentExporter">Декторируемый экспортер документов.</param>
    public DocumentToFolderExporterCompressionDecorator(DocumentToFolderExporterBase documentExporter) : base(documentExporter)
    {
    }

    #endregion
  }
}
