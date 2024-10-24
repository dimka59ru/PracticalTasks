using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace PracticalTasks.Task2App
{
  internal class Program
  {
    static void Main(string[] args)
    {
      string assemblyName = "System.Windows.Forms";
      string typeName = "System.Windows.Forms.MessageBox";
      string methodName = "Show";
      string filePath = Path.Combine(Path.GetTempPath(), "NonStaticMethodsNames.txt");

      if (!TryLoadAssembly(assemblyName, out Assembly? assembly))
      {
        Console.WriteLine($"Не удалось загрузить сборку {assemblyName}.");
        return;
      }

      if (!TryGetType(assembly, typeName, out Type? type))
      {
        Console.WriteLine($"Не удалось получить тип {typeName} из сборки {assemblyName}.");
        return;
      }
      
      IEnumerable<string> nonStaticMethodsNames = GetPublicNonStaticMethods(type);

      try
      {
        File.WriteAllText(filePath, string.Empty);
        File.AppendAllLines(filePath, nonStaticMethodsNames);
      }
      catch (IOException ex)
      {
        Console.WriteLine($"Не удалось сохранить данные в файл. Причина: {ex.Message}.");
      }

      // Получение статического публичного метода Show с одним аргументом.
      MethodInfo? method = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Static, [typeof(string)]);
      if (method == null)
      {
        Console.WriteLine($"Не удалось найти метод {methodName} в типе {typeName}.");
        return;
      }
      method?.Invoke(null, ["Привет, Медвед!"]);

      Console.ReadKey();
    }
   
    /// <summary>
    /// Получает публичные нестатические методы.
    /// </summary>
    /// <param name="type">Тип, в котором осуществляется поиск.</param>
    /// <returns>Коллекция имен методов.</returns>
    private static IEnumerable<string> GetPublicNonStaticMethods(Type type)
    {
      MethodInfo[] methodsInfos = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
      var nonStaticMethodsNames = methodsInfos.Select(methodInfo => methodInfo.Name);
      return nonStaticMethodsNames;
    }

    /// <summary>
    /// Пытаемся загрузить сборку.
    /// </summary>
    /// <param name="assemblyName">Имя сборки.</param>
    /// <param name="assembly">Cборка.</param>
    /// <returns>Удалось ли загрузить сборку.</returns>
    private static bool TryLoadAssembly(string assemblyName, [NotNullWhen(true)] out Assembly? assembly)
    {
      assembly = null;
      try
      {
        assembly = Assembly.Load(assemblyName);
        return true;
      }
      catch (IOException ex)
      {
        Console.WriteLine(ex.Message);
      }

      return false;
    }

    /// <summary>
    /// Пытаемся получить тип.
    /// </summary>    
    /// <param name="assembly">Cборка.</param>
    /// <param name="typeName">Имя Типа.</param>
    /// <returns>Удалось ли получить тип.</returns>
    private static bool TryGetType(Assembly assembly, string typeName, [NotNullWhen(true)] out Type? type)
    {
      type = null;
      try
      {
        type = assembly.GetType(typeName, false, true);
        if (type != null)
          return true;
      }
      catch (IOException ex)
      {
        Console.WriteLine(ex.Message);
      }

      return false;
    }
  }
}
