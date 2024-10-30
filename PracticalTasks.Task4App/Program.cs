using PracticalTasks.Task4App.Compressors;
using PracticalTasks.Task4App.DocumentProcessors;
using PracticalTasks.Task4App.Encryptors;
using PracticalTasks.Task4App.Exporters;
using PracticalTasks.Task4App.Importers;

namespace PracticalTasks.Task4App
{
  internal class Program
  {
    static void Main(string[] args)
    {

      IDocumentImporter documentImporter = new DocumentImporterFromMemory();
      IFilesCompressor filesCompressor = new SimpleFilesCompressor();
      IFilesEncryptor filesEncryptor = new SimpleFilesEncryptor();

      // #1
      int documentId = 5;
      DocumentToFolderExporterBase documentExporter = new DocumentToFolderExporter("C:\\TEMP\\");
      documentExporter = new DocumentToFolderExporterEncryptionDecorator(documentExporter, filesEncryptor);
      documentExporter = new DocumentToFolderExporterCompressionDecorator(documentExporter, filesCompressor);

      var documentProcessor = new DocumentTransferProcessor(documentImporter, documentExporter);
      documentProcessor.Process(documentId);

      Console.WriteLine();
      Console.WriteLine("---------------");

      // #2
      documentId = 4;
      documentExporter = new DocumentToFolderExporter("C:\\TEMP2\\");
      documentExporter = new DocumentToFolderExporterCompressionDecorator(documentExporter, filesCompressor);
      documentProcessor = new DocumentTransferProcessor(documentImporter, documentExporter);
      documentProcessor.Process(documentId);

      Console.WriteLine();
      Console.WriteLine("---------------");

      // #3
      documentId = 3;
      documentExporter = new DocumentToFolderExporter("C:\\TEMP3\\");
      documentExporter = new DocumentToFolderExporterEncryptionDecorator(documentExporter, filesEncryptor);
      documentProcessor = new DocumentTransferProcessor(documentImporter, documentExporter);
      documentProcessor.Process(documentId);
    }
  }
}
