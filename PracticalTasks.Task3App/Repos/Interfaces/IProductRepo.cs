using PracticalTasks.Task3App.Models;
using PracticalTasks.Task3App.Repos.Base;

namespace PracticalTasks.Task3App.Repos.Interfaces
{
  /// <summary>
  /// Хранилище продуктов.
  /// </summary>
  internal interface IProductRepo : IRepo<Product>
  {
  }
}
