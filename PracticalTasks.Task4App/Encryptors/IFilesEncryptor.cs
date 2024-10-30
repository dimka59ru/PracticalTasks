namespace PracticalTasks.Task4App.Encryptors
{
  /// <summary>
  /// Шифровальщик файлов.
  /// </summary>
  internal interface IFilesEncryptor
  {
    /// <summary>
    /// Зашифровать файлы.
    /// </summary>
    /// <param name="filesPath">Путь до папки с файлами.</param>
    void Encrypt(string filesPath);
  }
}
