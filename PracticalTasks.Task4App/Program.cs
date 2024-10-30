using PracticalTasks.Task4App.DocumentProcessors;
using PracticalTasks.Task4App.Exporters;
using PracticalTasks.Task4App.Importers;

namespace PracticalTasks.Task4App
{
  internal class Program
  {
    static void Main(string[] args)
    {

      IDocumentImporter documentImporter = new DocumentImporterFromMemory();

      // #1
      int documentId = 5;
      DocumentToFolderExporterBase documentExporter = new DocumentToFolderExporter("C:\\TEMP\\");
      documentExporter = new DocumentToFolderExporterEncryptionDecorator(documentExporter);
      documentExporter = new DocumentToFolderExporterCompressionDecorator(documentExporter);

      var documentProcessor = new DocumentTransferProcessor(documentImporter, documentExporter);
      documentProcessor.Process(documentId);

      Console.WriteLine();
      Console.WriteLine("---------------");

      // #2
      documentId = 4;
      documentExporter = new DocumentToFolderExporter("C:\\TEMP2\\");
      documentExporter = new DocumentToFolderExporterCompressionDecorator(documentExporter);
      documentProcessor = new DocumentTransferProcessor(documentImporter, documentExporter);
      documentProcessor.Process(documentId);

      Console.WriteLine();
      Console.WriteLine("---------------");

      // #3
      documentId = 3;
      documentExporter = new DocumentToFolderExporter("C:\\TEMP3\\");
      documentExporter = new DocumentToFolderExporterEncryptionDecorator(documentExporter);
      documentProcessor = new DocumentTransferProcessor(documentImporter, documentExporter);
      documentProcessor.Process(documentId);
    }
  }
}
