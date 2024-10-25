using PracticalTasks.Task3App.Models;
using PracticalTasks.Task3App.Repos.Interfaces;

namespace PracticalTasks.Task3App.Repos
{
  /// <summary>
  /// Хранилище продуктов в экселе.
  /// </summary>
  internal class ExcelProductRepo : IProductRepo
  {
    #region IProductRepo

    public IEnumerable<Product> GetAll()
    {
      return new List<Product>()
      {
        new("Ручка", 20),
        new("Принтер", 10000),
        new("Монитор", 12000)
      };
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="dataFilePath">Путь до файлов с данными.</param>
    /// <exception cref="ArgumentException">Если передан пустой путь, то будет выброшено исключение.</exception>
    public ExcelProductRepo(string dataFilePath)
    {
      if (string.IsNullOrEmpty(dataFilePath))
      {
        throw new ArgumentException($"'{nameof(dataFilePath)}' cannot be null or empty.", nameof(dataFilePath));
      }
    }

    #endregion
  }
}
