using PracticalTasks.Task4App.Compressors;
using PracticalTasks.Task4App.Documents;

namespace PracticalTasks.Task4App.Exporters
{
  /// <summary>
  /// Декторатор для экспортера документов.
  /// Упаковывает документы в архив.
  /// </summary>
  internal class DocumentToFolderExporterCompressionDecorator : DocumentToFolderExporterDecorator
  {
    #region Поля и свойства

    /// <summary>
    /// Архиватор документов.
    /// </summary>
    private readonly IFilesCompressor filesCompressor;

    #endregion

    #region Базовый класс

    public override void Export(IDocument document)
    {
      this.DocumentExporter.Export(document);
      this.filesCompressor.Compress(this.DocumentExporter.PathToFolder, document.Name);
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструкторы.
    /// </summary>
    /// <param name="documentExporter">Декторируемый экспортер документов.</param>
    public DocumentToFolderExporterCompressionDecorator(DocumentToFolderExporterBase documentExporter, IFilesCompressor filesCompressor)
      : base(documentExporter)
    {
      this.filesCompressor = filesCompressor ?? throw new ArgumentNullException(nameof(filesCompressor));
    }

    #endregion
  }
}
