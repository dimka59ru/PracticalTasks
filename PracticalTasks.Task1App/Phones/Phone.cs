using PracticalTasks.Task1App.Models;

namespace PracticalTasks.Task1App.Phones
{
  /// <summary>
  /// Простой сотовый телефон.
  /// </summary>
  internal class Phone
  {
    #region Поля и свойства

    /// <summary>
    /// Справочник номеров абонентов.
    /// </summary>
    private readonly List<Subscriber> phoneBook = new();

    /// <summary>
    /// IMEI.
    /// </summary>
    public string Imei { get; }

    /// <summary>
    /// Номер SIM.
    /// </summary>
    public int SimNumber { get; set; }

    #endregion

    #region Методы

    /// <summary>
    /// Заполняет справочник номеров абонентов базовыми контактами (Например, экстренными службами).
    /// </summary>
    private void PopulatePhoneBook()
    {
      phoneBook.Add(new Subscriber("Пожарные", "101"));
      phoneBook.Add(new Subscriber("Полиция", "102"));
      phoneBook.Add(new Subscriber("Скорая помощь", "103"));
    }

    /// <summary>
    /// Осуществляет соедиение с базовой станцией.
    /// </summary>
    protected virtual void ConnectToBaseStation()
    {
      Console.WriteLine($"Соединились с базовой станцией по 2G.");
    }

    /// <summary>
    /// Выполнят звонок по номеру телефона.
    /// </summary>
    /// <param name="number">Номер телефона.</param>
    public void Call(string number)
    {
      Console.WriteLine($"Позвонили на номер {number}.");
    }

    /// <summary>
    /// Выполняет звонок, выбирая запись из телефонной книги по индексу.
    /// </summary>
    /// <param name="phoneBookIndex">Индекс в телефонной книге. Начинается с 1.</param>  
    /// <exception cref="ArgumentException">Если передать индекс 0, то будет выброшено исключение.</exception>
    public void Call(uint phoneBookIndex)
    {
      if (phoneBookIndex == 0)
      {
        throw new ArgumentException($"'{nameof(phoneBookIndex)}' cannot be zero.", nameof(phoneBookIndex));
      }

      var internalPhoneBookIndex = phoneBookIndex - 1;
      if (internalPhoneBookIndex < phoneBook.Count)
      {
        Subscriber subscriber = phoneBook[(int)internalPhoneBookIndex];
        this.Call(subscriber.Number);
      }
      else
      {
        Console.WriteLine($"Запись #{phoneBookIndex} не найдена в справочнике.");
      }
    }

    /// <summary>
    /// Добавляет абонента в справочник
    /// </summary>
    /// <param name="subscriber">Абонент</param>
    /// <exception cref="ArgumentNullException">Если передать null, то будет выброшено исключение.</exception>
    public void AddSubscriber(Subscriber subscriber)
    {
      ArgumentNullException.ThrowIfNull(subscriber);

      this.phoneBook.Add(subscriber);
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="imei">imei телефона.</param>
    /// <param name="simNumber">Номер симкарты.</param> 
    /// <exception cref="ArgumentException">Если imei пустой, то будет выброшено исключение.</exception>
    public Phone(string imei, int simNumber)
    {
      if (string.IsNullOrEmpty(imei))
      {
        throw new ArgumentException($"'{nameof(imei)}' cannot be null or empty.", nameof(imei));
      }

      this.Imei = imei;
      this.SimNumber = simNumber;      

      this.ConnectToBaseStation();
      this.PopulatePhoneBook();
    }

    #endregion
  }
}
