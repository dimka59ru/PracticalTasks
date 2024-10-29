using PracticalTasks.Task4App.Documents;
using PracticalTasks.Task4App.Exporters;
using PracticalTasks.Task4App.Importers;

namespace PracticalTasks.Task4App
{
  /// <summary>
  /// Процессор документа.
  /// </summary>
  internal interface IDocumentProcessor
  {
    /// <summary>
    /// Обработать документ.
    /// </summary>
    /// <param name="id">Id документа.</param>
    /// <returns>Успешен ли процесс.</returns>
    bool Process(int id);
  }

  /// <summary>
  /// Импортирует документ из одного места и сохраняет в другое.
  /// </summary>
  internal class DocumentTransferProcessor : IDocumentProcessor
  {
    private readonly IDocumentImporter documentImporter;
    private readonly IDocumentExporter documentExporter;

    public bool Process(int id)
    {
      IDocument? document = this.documentImporter.Load(id);
      if (document != null)
      {
        this.documentExporter.Export(document);
        return true;
      }
      else
      {
        return false;
      }
    }

    public DocumentTransferProcessor(IDocumentImporter documentImporter, IDocumentExporter documentExporter)
    {
      this.documentImporter = documentImporter;
      this.documentExporter = documentExporter;
    }
  }
}
