using PracticalTasks.Task4App.Documents;

namespace PracticalTasks.Task4App.Exporters
{
  /// <summary>
  /// Декторатор для экспортера документов.
  /// Шифрует документ.
  /// </summary>
  internal class DocumentToFolderExporterEncryptionDecorator : DocumentToFolderExporterDecorator
  {
    #region Методы

    /// <summary>
    /// Шифрует документ.
    /// </summary>
    private void Encrypt()
    {
      Console.WriteLine($"Документы в папке {this.DocumentExporter.PathToFolder} зашифрованы.");
    }

    #endregion

    #region Базовый класс

    public override void Export(IDocument document)
    {
      this.DocumentExporter.Export(document);
      this.Encrypt();
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="documentExporter">Декорируемый экспортер документов.</param>
    public DocumentToFolderExporterEncryptionDecorator(DocumentToFolderExporterBase documentExporter) : base(documentExporter)
    {
    }

    #endregion
  }
}
