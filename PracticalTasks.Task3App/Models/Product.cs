namespace PracticalTasks.Task3App.Models
{
  /// <summary>
  /// Продукт.
  /// </summary>
  internal class Product
  {
    #region Поля и свойства
    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Цена.
    /// </summary>
    public decimal Price { get; }

    #endregion

    #region Констркторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Наименование продукта.</param>
    /// <param name="price">Цена продукта.</param>
    /// <exception cref="ArgumentException">Если имя не задано или цена 0 или отрицательная, то будет выброшено исключение.</exception>
    public Product(string name, decimal price)
    {
      if (string.IsNullOrEmpty(name))
      {
        throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
      }

      if (price <= 0)
      {
        throw new ArgumentException($"'{nameof(price)}' must be greater than zero.", nameof(price));
      }

      this.Name = name;
      this.Price = price;
    }

    #endregion
  }
}
