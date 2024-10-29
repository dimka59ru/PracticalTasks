using PracticalTasks.Task4App.DocumentExporters;
using PracticalTasks.Task4App.Documents;
using PracticalTasks.Task4App.Repositories;

namespace PracticalTasks.Task4App
{
  internal class Program
  {
    static void Main(string[] args)
    {
      IDocumentRepository documentRepository = new DocumentRepository();

      // #1
      int documentId = 5;
      IDocument? document = documentRepository.Get(documentId);
      if (document == null)
      {
        Console.WriteLine($"Документ с id {documentId} не найден.");
        return;
      }

      IDocumentExporter exporter = new DocumentExporter(document, "C:\\TEMP\\");
      exporter = new DocumentExporterEncryptionDecorator(exporter);
      exporter = new DocumentExporterCompressionDecorator(exporter);
      exporter.Export();

      Console.WriteLine();
      Console.WriteLine("---------------");


      // #2
      documentId = 4;
      document = documentRepository.Get(documentId);
      if (document == null)
      {
        Console.WriteLine($"Документ с id {documentId} не найден.");
        return;
      }

      exporter = new DocumentExporter(document, "C:\\TEMP2\\");
      exporter = new DocumentExporterCompressionDecorator(exporter);
      exporter.Export();

      Console.WriteLine();
      Console.WriteLine("---------------");

      // #3
      documentId = 3;
      document = documentRepository.Get(documentId);
      if (document == null)
      {
        Console.WriteLine($"Документ с id {documentId} не найден.");
        return;
      }

      exporter = new DocumentExporter(document, "C:\\TEMP3\\");
      exporter = new DocumentExporterEncryptionDecorator(exporter);
      exporter.Export();
    }
  }
}
