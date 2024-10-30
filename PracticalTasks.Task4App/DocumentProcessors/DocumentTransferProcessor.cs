using PracticalTasks.Task4App.Documents;
using PracticalTasks.Task4App.Exporters;
using PracticalTasks.Task4App.Importers;

namespace PracticalTasks.Task4App.DocumentProcessors
{
  /// <summary>
  /// Импортирует документ из одного места и сохраняет в другое.
  /// </summary>
  internal class DocumentTransferProcessor : DocumentTransferProcessorBase
  {
    #region Поля и свойства

    /// <summary>
    /// Сервис импорта документа.
    /// </summary>
    private readonly IDocumentImporter documentImporter;

    /// <summary>
    /// Сервис экспорта документа.
    /// </summary>
    private readonly IDocumentExporter documentExporter;

    #endregion

    #region Базовый класс

    protected override IDocument? GetDocument(int id)
    {
      return this.documentImporter.Load(id);
    }

    protected override void SendDocument(IDocument document)
    {
      this.documentExporter.Export(document);
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="documentImporter">Сервис импорта документа.</param>
    /// <param name="documentExporter">Сервис экспорта документа.</param>
    public DocumentTransferProcessor(IDocumentImporter documentImporter, IDocumentExporter documentExporter)
    {
      this.documentImporter = documentImporter;
      this.documentExporter = documentExporter;
    }

    #endregion
  }
}
