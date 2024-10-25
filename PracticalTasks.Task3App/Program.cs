using PracticalTasks.Task3App.Models;
using PracticalTasks.Task3App.Repos;

namespace PracticalTasks.Task3App
{
  /// <summary>
  /// Основной класс приложения.
  /// </summary>
  internal class Program
  {
    #region Константы

    /// <summary>
    /// Минимальная цена продукта.
    /// </summary>
    private const int minProductPrice = 2000;

    /// <summary>
    /// Имя файла для сохранения данных.
    /// </summary>
    private const string dataRecipientFileName = "SortedProductsMoreExpensiveMinPrice.txt";

    /// <summary>
    /// Путь до файла источника данных.
    /// </summary>
    private const string dataSourceFilePath = "./ProductsDb.xlsx";

    #endregion

    #region Поля и свойства

    /// <summary>
    /// Хранилище продуктов.
    /// </summary>
    private static IReadOnlyList<Product>? products;

    #endregion

    #region Методы

    /// <summary>
    /// Стандартная точка входа в программу.
    /// </summary>
    /// <param name="args">Параметры командной строки.</param>
    static void Main(string[] args)
    {
      string dataRecipientFilePath = Path.Combine(Path.GetTempPath(), dataRecipientFileName);

      try
      {
        using (var excelProductRepo = new ExcelProductRepo(dataSourceFilePath))
        {
          products = excelProductRepo.GetAll().ToList();
        }

        var sortedProductsMoreExpensiveMinPrice = products
          .Where(product => product.Price > minProductPrice)
          .OrderBy(product => product.Name)
          .ToList();

        var productsAsStrings = sortedProductsMoreExpensiveMinPrice
          .Select(product => $"{product.Name}; {product.Price}")
          .ToList();

        File.WriteAllText(dataRecipientFilePath, string.Empty);
        File.AppendAllLines(dataRecipientFilePath, productsAsStrings);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
    }

    #endregion
  }
}
