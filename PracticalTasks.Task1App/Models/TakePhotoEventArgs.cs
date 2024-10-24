namespace PracticalTasks.Task1App.Models
{
  /// <summary>
  /// Аргументы события "Сделать фото".
  /// </summary>
  internal class TakePhotoEventArgs
  {
    #region Поля и свойства

    /// <summary>
    /// Готовое фото.
    /// </summary>
    public Photo Photo { get; }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="photo">Готовое фото.</param>
    public TakePhotoEventArgs(Photo photo)
    {
      this.Photo = photo;
    }

    #endregion
  }
}
