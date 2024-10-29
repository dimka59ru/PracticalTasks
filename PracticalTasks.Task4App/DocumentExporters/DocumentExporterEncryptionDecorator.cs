namespace PracticalTasks.Task4App.DocumentExporters
{
  /// <summary>
  /// Декторатор для экспортера документов.
  /// Шифрует документ.
  /// </summary>
  internal class DocumentExporterEncryptionDecorator : DocumentExporterDecorator
  {
    public override void Export()
    {
      this.DocumentExporter.Export();
      this.Encrypt();
    }

    /// <summary>
    /// Шифрует документ.
    /// </summary>
    private void Encrypt()
    {
      Console.WriteLine($"Документы в папке {this.PathToExport} зашифрованы.");
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="documentExporter">Декорируемый экспортер документов.</param>
    public DocumentExporterEncryptionDecorator(IDocumentExporter documentExporter) : base(documentExporter)
    {
    }
  }
}
