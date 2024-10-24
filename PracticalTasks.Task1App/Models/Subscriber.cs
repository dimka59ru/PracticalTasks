namespace PracticalTasks.Task1App.Models
{
  /// <summary>
  /// Абонент сотовой связи.
  /// </summary>
  internal class Subscriber
  {
    #region Поля и свойства

    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Отчество.
    /// </summary>
    public string MiddleName { get;}

    /// <summary>
    /// Фамилия.
    /// </summary>
    public string Surname { get; }

    /// <summary>
    /// Телефонный номер.
    /// </summary>
    public string Number { get; }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="surname">Имя абонента.</param>
    /// <param name="name">Фамилия абонента.</param>
    /// <param name="middleName">Отчество абонента.</param>
    /// <param name="number">Телефонный номер абонента.</param>
    /// <exception cref="ArgumentException">Если имя или номер пустые, то будет выброшено исключение.</exception>
    public Subscriber(string surname, string name, string middleName, string number)
    {
      if (string.IsNullOrEmpty(name))
      {
        throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
      }

      if (string.IsNullOrEmpty(number))
      {
        throw new ArgumentException($"'{nameof(number)}' cannot be null or empty.", nameof(number));
      }

      this.Surname = surname;
      this.Name = name;
      this.MiddleName = middleName;
      this.Number = number;
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Фамилия абонента.</param>
    /// <param name="number">Телефонный номер абонента.</param>
    /// <exception cref="ArgumentException"></exception>
    public Subscriber(string name, string number) : this(string.Empty, name, string.Empty, number) { }

    #endregion
  }
}
