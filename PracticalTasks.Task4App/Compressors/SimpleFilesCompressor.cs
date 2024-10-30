namespace PracticalTasks.Task4App.Compressors
{
  /// <summary>
  /// Простой архиватор файлов.
  /// </summary>
  internal class SimpleFilesCompressor : IFilesCompressor
  {
    #region IFilesCompressor

    public void Compress(string filesPath, string archiveName)
    {
      if (string.IsNullOrEmpty(filesPath))
      {
        throw new ArgumentException($"'{nameof(filesPath)}' cannot be null or empty.", nameof(filesPath));
      }

      if (string.IsNullOrEmpty(archiveName))
      {
        throw new ArgumentException($"'{nameof(archiveName)}' cannot be null or empty.", nameof(archiveName));
      }

      // Перебираем  файлы в папке и архивируем их.
      Console.WriteLine($"Документы в папке {filesPath} упакованы в архив с именем \"{archiveName}\".");
    }

    #endregion
  }
}
