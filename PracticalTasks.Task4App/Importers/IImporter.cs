namespace PracticalTasks.Task4App.Importers
{
  internal interface IImporter<T> where T : class
  {
    T? Load(int id);
  }
}
