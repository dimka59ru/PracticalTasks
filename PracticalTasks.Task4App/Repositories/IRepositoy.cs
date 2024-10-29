namespace PracticalTasks.Task4App.Repositories
{
  /// <summary>
  /// Хранилище данных.
  /// </summary>
  /// <typeparam name="T">Тип сущности.</typeparam>
  internal interface IRepositoy<T> where T : class
  {
    /// <summary>
    /// Получить объект из репозиория.
    /// </summary>
    /// <param name="id">Идентификатор объекта.</param>
    /// <returns>Объект типа Т.</returns>
    T? Get(int id);
  }
}
