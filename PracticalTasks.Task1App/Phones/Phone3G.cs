namespace PracticalTasks.Task1App.Phones
{
  /// <summary>
  /// Телефон с 3G
  /// </summary>
  internal class Phone3G : Phone
  {  
    #region Базовый класс

    protected sealed override void ConnectToBaseStation()
    {
      Console.WriteLine($"Соединились с базовой станцией по 3G.");
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="imei">imei телефона.</param>
    /// <param name="simNumber">Номер симкарты.</param>
    public Phone3G(string imei, int simNumber) : base(imei, simNumber) { }

    #endregion
  }
}
