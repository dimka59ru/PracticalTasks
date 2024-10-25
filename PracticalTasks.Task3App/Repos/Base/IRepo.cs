namespace PracticalTasks.Task3App.Repos.Base
{
  /// <summary>
  /// Хранилище данных.
  /// </summary>
  /// <typeparam name="T">Тип сущности.</typeparam>
  internal interface IRepo<T>
  {
    IEnumerable<T> GetAll();
  }
}
