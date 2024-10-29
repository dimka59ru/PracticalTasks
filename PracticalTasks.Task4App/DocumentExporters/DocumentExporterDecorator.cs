using PracticalTasks.Task4App.Documents;

namespace PracticalTasks.Task4App.DocumentExporters
{
  /// <summary>
  /// Базовый декоратор для экспортера документов.
  /// </summary>
  internal abstract class DocumentExporterDecorator : IDocumentExporter
  {
    #region Поля и свойства

    /// <summary>
    /// Декорируемый экспортер документов.
    /// </summary>
    protected IDocumentExporter DocumentExporter { get; }

    #endregion

    #region IDocumentExporter

    public virtual IDocument Document => this.DocumentExporter.Document;

    public virtual string PathToExport => this.DocumentExporter.PathToExport;

    public virtual void Export()
    {
      this.DocumentExporter.Export();
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="documentExporter">Декторируемый экспортер.</param>
    public DocumentExporterDecorator(IDocumentExporter documentExporter)
    {
      this.DocumentExporter = documentExporter;
    }

    #endregion
  }
}
