namespace PracticalTasks.Task2App
{
  internal class Program
  {
    static void Main(string[] args)
    {
      try
      {
        string assemblyName = "System.Windows.Forms";
        string typeName = "System.Windows.Forms.MessageBox";

        IEnumerable<string> nonStaticMethodsNames = ReflectionHelper.GetAllPublicNonStaticMethodsNames(assemblyName, typeName);
        foreach (var name in nonStaticMethodsNames)
        {
          Console.WriteLine(name);
        }

        var showMethod = ReflectionHelper.GetPublicStaticOneParametricMethod(assemblyName, typeName, "Show");
        showMethod?.Invoke(null, new object[] { "Привет, Медвед!" });
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }

      Console.ReadKey();
    }
  }
}
