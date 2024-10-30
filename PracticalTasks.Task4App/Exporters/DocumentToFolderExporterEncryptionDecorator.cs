using PracticalTasks.Task4App.Documents;
using PracticalTasks.Task4App.Encryptors;

namespace PracticalTasks.Task4App.Exporters
{
  /// <summary>
  /// Декторатор для экспортера документов.
  /// Шифрует документ.
  /// </summary>
  internal class DocumentToFolderExporterEncryptionDecorator : DocumentToFolderExporterDecorator
  {
    #region Поля и свойства

    /// <summary>
    /// Шифровальщик файлов.
    /// </summary>
    private readonly IFilesEncryptor filesEncryptor;

    #endregion

    #region Базовый класс

    public override void Export(IDocument document)
    {
      this.DocumentExporter.Export(document);
      this.filesEncryptor.Encrypt(this.DocumentExporter.PathToFolder);
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="documentExporter">Декорируемый экспортер документов.</param>
    /// <param name="filesEncryptor">Шифровальщик файлов.</param>
    /// <exception cref="ArgumentNullException">Если шифровальщик файлов null, то будет выброшено исключение.</exception>
    public DocumentToFolderExporterEncryptionDecorator(DocumentToFolderExporterBase documentExporter, IFilesEncryptor filesEncryptor)
      : base(documentExporter)
    {
      this.filesEncryptor = filesEncryptor ?? throw new ArgumentNullException(nameof(filesEncryptor));
    }

    #endregion
  }
}
