namespace PracticalTasks.Task4App.Documents
{
  /// <summary>
  /// Простой документ.
  /// </summary>
  internal class Document : DocumentBase
  {
    #region IDocument

    public override string GetDescription()
    {
      return this.Name;
    }

    #endregion

    #region Конструктры

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Название документа.</param>
    /// <exception cref="ArgumentException">Если будет передано пустое название документа, то будт выброшено исключение.</exception>
    public Document(string name, int id) : base(name, id) { }

    #endregion
  }
}
