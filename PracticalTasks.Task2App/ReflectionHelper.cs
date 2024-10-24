using System.Reflection;

namespace PracticalTasks.Task2App
{
  /// <summary>
  /// Вспомогательный класс для работы с рефлексией.
  /// </summary>
  internal static class ReflectionHelper
  {
    #region Методы

    /// <summary>
    /// Получить имена всех общедоступных нестатических методов.
    /// </summary>
    /// <param name="assemblyName">Имя сборки.</param>
    /// <param name="typeName">Имя типа.</param>
    /// <returns>Перечисление имен методов.</returns>
    /// <exception cref="ArgumentException">Если переданы пустые именя сборки и/или типа, то будет выбошно исключение.</exception>
    /// <exception cref="Exception">Если тип не будет найден в сборке, то будет выброшено исключение.</exception>
    public static IEnumerable<string> GetAllPublicNonStaticMethodsNames(string assemblyName, string typeName)
    {
      IEnumerable<MethodInfo> methodsInfos = GetMethodsInfos(assemblyName, typeName, BindingFlags.Public | BindingFlags.Instance);
      var methodsNames = methodsInfos.Select(methodInfo => methodInfo.Name);
      return methodsNames;
    }

    /// <summary>
    /// Получить публичный статический метод с одним параметром.
    /// </summary>
    /// <param name="assemblyName">Имя сборки.</param>
    /// <param name="typeName">Имя типа.</param>
    /// <param name="methodName">Имя метода.</param>
    /// <returns>MethodInfo.</returns>
    /// <exception cref="ArgumentException">Если переданы пустые именя сборки и/или типа, то будет выбошно исключение.</exception>
    /// <exception cref="Exception">Если тип не будет найден в сборке, то будет выброшено исключение.</exception>
    public static MethodInfo GetPublicStaticOneParametricMethod(string assemblyName, string typeName, string methodName)
    {
      IEnumerable<MethodInfo> methodsInfos = GetMethodsInfos(assemblyName, typeName, BindingFlags.Public | BindingFlags.Static);
      return methodsInfos.First(methodInfo => methodInfo.Name == methodName && methodInfo.GetParameters().Length == 1);
    }

    /// <summary>
    /// Получить публичный статический метод с одним параметром.
    /// </summary>
    /// <param name="assemblyName">Имя сборки.</param>
    /// <param name="typeName">Имя типа.</param>
    /// <param name="bindingFlags">Флаги поиска.</param>
    /// <returns>Перечисление MethodInfo.</returns>
    /// <exception cref="ArgumentException">Если переданы пустые именя сборки и/или типа, то будет выбошно исключение.</exception>
    /// <exception cref="Exception">Если тип не будет найден в сборке, то будет выброшено исключение.</exception>
    public static IEnumerable<MethodInfo> GetMethodsInfos(string assemblyName, string typeName, BindingFlags bindingFlags)
    {
      if (string.IsNullOrEmpty(assemblyName))
      {
        throw new ArgumentException($"'{nameof(assemblyName)}' cannot be null or empty.", nameof(assemblyName));
      }

      if (string.IsNullOrEmpty(typeName))
      {
        throw new ArgumentException($"'{nameof(typeName)}' cannot be null or empty.", nameof(typeName));
      }

      Assembly asm = Assembly.Load(assemblyName);
      Type? type = asm.GetType(typeName, false, true) 
        ?? throw new TypeLoadException($"Type {typeName} not found in assembly {assemblyName}");

      return type.GetMethods(bindingFlags);
    }

    #endregion
  }
}
