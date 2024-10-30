namespace PracticalTasks.Task4App.Encryptors
{
  /// <summary>
  /// Простой шифровальщик файлов.
  /// </summary>
  internal class SimpleFilesEncryptor : IFilesEncryptor
  {
    /// <summary>
    /// Зашифровать файлы.
    /// </summary>
    /// <param name="filesPath">Путь до файлов.</param>
    /// <exception cref="ArgumentException">Если путь до файлов не задан, то будет выброшено исключение.</exception>
    public void Encrypt(string filesPath)
    {
      if (string.IsNullOrEmpty(filesPath))
      {
        throw new ArgumentException($"'{nameof(filesPath)}' cannot be null or empty.", nameof(filesPath));
      }

      // Перебираем файлы и шифруем их.
      Console.WriteLine($"Документы в папке {filesPath} зашифрованы.");
    }
  }
}
