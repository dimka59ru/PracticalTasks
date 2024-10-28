using PracticalTasks.Task4App.Documents;

namespace PracticalTasks.Task4App
{
  internal class Program
  {
    static void Main(string[] args)
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

      Console.WriteLine(root.GetDescription(0));

    }
  }
}
