using ClosedXML.Excel;
using PracticalTasks.Task3App.Models;
using PracticalTasks.Task3App.Repos.Interfaces;

namespace PracticalTasks.Task3App.Repos
{
  /// <summary>
  /// Хранилище продуктов в экселе.
  /// </summary>
  internal class ExcelProductRepo : IProductRepo
  {
    #region Поля и свойства

    private readonly XLWorkbook workbook;

    #endregion

    #region IProductRepo

    /// <summary>
    /// Получить все записи.
    /// Ограничение: данные будут получены только с первого листа.
    /// </summary>
    /// <returns>Список продуктов.</returns>
    public IEnumerable<Product> GetAll()
    {
      var worksheet = this.workbook.Worksheets.First();
      var rows = worksheet.RowsUsed();

      foreach (var row in rows)
      {
        var productName = row.Cell(1).GetValue<string>();
        var productPrice = row.Cell(2).GetValue<decimal>();
        yield return new Product(productName, productPrice);
      }
    }

    #endregion

    #region IDisposable

    public void Dispose()
    {
      this.workbook.Dispose();
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="dataFilePath">Путь до файла с данными.</param>
    /// <exception cref="ArgumentException">Если передан пустой путь, то будет выброшено исключение.</exception>
    public ExcelProductRepo(string dataFilePath)
    {
      if (string.IsNullOrEmpty(dataFilePath))
      {
        throw new ArgumentException($"'{nameof(dataFilePath)}' cannot be null or empty.", nameof(dataFilePath));
      }

      this.workbook = new XLWorkbook(dataFilePath);
    }

    #endregion
  }
}
