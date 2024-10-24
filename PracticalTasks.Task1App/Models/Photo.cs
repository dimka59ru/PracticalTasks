namespace PracticalTasks.Task1App.Models
{
  /// <summary>
  /// Фотография.
  /// </summary>
  internal class Photo
  {
    #region Поля и свойства

    /// <summary>
    /// Содержимое фотографии.
    /// </summary>
    public Guid Data { get; }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    public Photo()
    {
      this.Data = Guid.NewGuid();
    }

    #endregion
  }
}
