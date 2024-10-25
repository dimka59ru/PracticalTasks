using PracticalTasks.Task3App.Models;
using PracticalTasks.Task3App.Repos.Interfaces;

namespace PracticalTasks.Task3App.Repos
{
  internal class InMemoryProductRepo : IProductRepo
  {
    public IEnumerable<Product> GetAll()
    {
      throw new NotImplementedException();
    }
  }
}
