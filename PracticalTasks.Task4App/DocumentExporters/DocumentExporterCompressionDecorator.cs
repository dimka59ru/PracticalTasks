namespace PracticalTasks.Task4App.DocumentExporters
{
  /// <summary>
  /// Декторатор для экспортера документов.
  /// Упаковывает документы в архив.
  /// </summary>
  internal class DocumentExporterCompressionDecorator : DocumentExporterDecorator
  {
    public override void Export()
    {
      this.DocumentExporter.Export();
      this.Compress();
    }

    /// <summary>
    /// Упаковать в архив.
    /// </summary>
    private void Compress()
    {
      Console.WriteLine($"Документы в папке {this.PathToExport} упакованы в архив с именем \"{this.Document.Name}\".");
    }

    /// <summary>
    /// Конструкторы.
    /// </summary>
    /// <param name="documentExporter">Декторируемый экспортер документов.</param>
    public DocumentExporterCompressionDecorator(IDocumentExporter documentExporter) : base(documentExporter)
    {
    }
  }
}
