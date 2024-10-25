namespace PracticalTasks.Task3App.Repos.Base
{
  /// <summary>
  /// Хранилище данных.
  /// </summary>
  /// <typeparam name="T">Тип сущности.</typeparam>
  internal interface IRepo<T> where T : class
  {
    /// <summary>
    /// Получить все записи.
    /// </summary>
    /// <returns></returns>
    IEnumerable<T> GetAll();
  }
}
