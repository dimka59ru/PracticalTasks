namespace PracticalTasks.Task4App.Documents
{
  internal abstract class DocumentBase : IDocument
  {
    #region IDocument

    public int Id { get; }

    public string Name { get; set; }

    public abstract string GetDescription();

    #endregion

    #region Конструктры

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Название документа.</param>
    /// <exception cref="ArgumentException">Если будет передано пустое название документа, то будт выброшено исключение.</exception>
    protected DocumentBase(string name, int id)
    {
      if (string.IsNullOrEmpty(name))
      {
        throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
      }

      this.Name = name;
      this.Id = id;
    }

    #endregion
  }
}
