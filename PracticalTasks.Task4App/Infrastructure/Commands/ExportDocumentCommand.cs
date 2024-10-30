using PracticalTasks.Task4App.Compressors;
using PracticalTasks.Task4App.DocumentProcessors;
using PracticalTasks.Task4App.Encryptors;
using PracticalTasks.Task4App.Exporters;
using PracticalTasks.Task4App.Importers;

namespace PracticalTasks.Task4App.Infrastructure.Commands
{
  /// <summary>
  /// Команда для экспорта документа.
  /// </summary>
  internal class ExportDocumentCommand : NonTerminatingCommand
  {
    #region Поля и свойства.

    /// <summary>
    /// Id документа.
    /// </summary>
    private int? documentId;

    /// <summary>
    ///  Путь до папки экспорта.
    /// </summary>
    private string? pathToExportFolder;

    /// <summary>
    /// Импортер документа.
    /// </summary>
    private readonly IDocumentImporter documentImporter;

    /// <summary>
    /// Архиватор файлов.
    /// </summary>
    private readonly IFilesCompressor filesCompressor;

    /// <summary>
    /// Шифровальщик файлов.
    /// </summary>
    private readonly IFilesEncryptor filesEncryptor;

    /// <summary>
    /// Экспортер документов.
    /// </summary>
    private DocumentToFolderExporterBase? documentExporter;

    #endregion

    #region Методы

    /// <summary>
    /// Получает параметры.
    /// </summary>
    /// <returns>true, если получили все параметры, иначе false.</returns>
    private bool GetParameters()
    {
      if (this.documentId == null)
      {
        this.documentId = this.GetDocumentId();

        if (this.documentId == null)
        {
          return false;
        }
      }

      if (string.IsNullOrEmpty(this.pathToExportFolder))
      {
        this.pathToExportFolder = this.GetPathToExportFolder();

        if (string.IsNullOrEmpty(this.pathToExportFolder))
        {
          return false;
        }
      }

      // Задаем базовый экспортер.
      this.documentExporter = new DocumentToFolderExporter(this.pathToExportFolder);

      string? input = this.GetParameter("Нужно ли архивировать файлы (д/н)?");
      if (input?.ToLower() == "д")
      {
        this.UserInterface.WriteWarning($"Файлы будут заархивированы.");

        // Задаем экспортер с архивацией.
        this.documentExporter = new DocumentToFolderExporterCompressionDecorator(this.documentExporter, this.filesCompressor);
      }

      input = this.GetParameter("Нужно ли шифровать файлы (д/н)?");
      if (input?.ToLower() == "д")
      {
        this.documentExporter = new DocumentToFolderExporterEncryptionDecorator(this.documentExporter, this.filesEncryptor);

        // Задаем экспортер с шифрованием.
        this.UserInterface.WriteWarning($"Файлы будут зашифрованы.");
      }

      return true;
    }

    /// <summary>
    /// Получает id документа.
    /// </summary>
    /// <returns>Id документа.</returns>
    private int? GetDocumentId()
    {
      string? input = this.GetParameter(nameof(this.documentId));
      if (int.TryParse(input, out int id))
      {
        return id;
      }
      else
      {
        this.UserInterface.WriteWarning($"Не удалось распознать число!");
        return null;
      }
    }

    /// <summary>
    /// Получает путь до папки экпорта.
    /// </summary>
    /// <returns>Путь до папки экпорта.</returns>
    private string? GetPathToExportFolder()
    {
      string? path = this.GetParameter("Путь до папки экспорта");
      if (!string.IsNullOrEmpty(path))
      {
        return path;
      }
      else
      {
        this.UserInterface.WriteWarning($"Вы не ввели путь до папки экспорта!");
        return null;
      }
    }

    #endregion

    #region Базовый класс

    protected override bool InternalCommand()
    {
      if (this.documentId == null)
      {
        this.UserInterface.WriteMessage($"Не задан {nameof(this.documentId)}");
        return false;
      }

      this.UserInterface.WriteMessage($"-------");

      // Экспортируем документ.
      var documentProcessor = new DocumentTransferProcessor(this.documentImporter, this.documentExporter!);
      var result = documentProcessor.Process(this.documentId.Value);
      if (!result)
      {
        this.UserInterface.WriteMessage($"Не удалось экспортировать документ. (Функционал вывода причин не разработан :D )");
      }
      return true;
    }

    public override (bool wasSuccessful, bool souldQuit) Run()
    {
      var allParametersCompleted = false;

      while (!allParametersCompleted)
      {
        allParametersCompleted = this.GetParameters();
      }

      return base.Run();
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="userInterface">Пользовательский интерфейс.</param>
    public ExportDocumentCommand(IUserInterface userInterface) : base(userInterface)
    {
      this.documentImporter = new DocumentImporterFromMemory();
      this.filesCompressor = new SimpleFilesCompressor();
      this.filesEncryptor = new SimpleFilesEncryptor();
    }

    #endregion
  }
}
