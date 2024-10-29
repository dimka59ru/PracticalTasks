namespace PracticalTasks.Task4App.Exporters
{
  /// <summary>
  /// Экспортер.
  /// </summary>
  /// <typeparam name="T">Элемент, который будет экспортирован.</typeparam>
  internal interface IExporter<T> where T : class
  {
    /// <summary>
    /// Экспорт элемента.
    /// </summary>
    /// <param name="item">Элемент, который будет экспортирован.</param>
    void Export(T item);
  }
}
