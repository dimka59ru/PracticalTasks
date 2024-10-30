namespace PracticalTasks.Task4App.Compressors
{
  /// <summary>
  /// Архиватор для файлов.
  /// </summary>
  internal interface IFilesCompressor
  {
    /// <summary>
    /// Архивировать файлы в папке.
    /// </summary>
    /// <param name="filesPath">Путь до папки с файлами.</param>
    /// <param name="archiveName">Имя архива, который будет создан.</param>
    void Compress(string filesPath, string archiveName);
  }
}
