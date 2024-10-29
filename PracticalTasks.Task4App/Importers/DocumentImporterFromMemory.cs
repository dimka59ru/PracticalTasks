using PracticalTasks.Task4App.Documents;

namespace PracticalTasks.Task4App.Importers
{
  internal class DocumentImporterFromMemory : IDocumentImporter
  {
    private readonly List<IDocument> documents;

    public IDocument? Load(int id)
    {
      return this.documents.FirstOrDefault(document => document.Id == id);
    }

    public DocumentImporterFromMemory()
    {
      IDocument doc1 = new Document("Документ 1", 1);
      IDocument doc2 = new Document("Документ 2", 2);
      IDocument doc3 = new Document("Документ 3", 3);

      ICompoundDocument comp1 = new CompoundDocument("Комплект 1", 4);
      comp1.AddDocument(doc1);
      comp1.AddDocument(doc2);

      ICompoundDocument root = new CompoundDocument("Комплект 2", 5);
      root.AddDocument(comp1);
      root.AddDocument(doc3);

      this.documents = new List<IDocument>
      {
        doc1,
        doc2,
        doc3,
        comp1,
        root
      };
    }
  }
}
