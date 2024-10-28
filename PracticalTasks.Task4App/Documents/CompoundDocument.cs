using System.Text;

namespace PracticalTasks.Task4App.Documents
{
  /// <summary>
  /// Составной документ.
  /// </summary>
  internal class CompoundDocument : DocumentBase, ICompoundDocument
  {
    #region Поля и свойства

    /// <summary>
    /// Документы, которые входят в состав текущего.
    /// </summary>
    private readonly List<IDocument> documents = new();

    #endregion

    #region ICompoundDocument

    public override string GetDescription(int depth)
    {
      StringBuilder discription = new();
      discription.Append(' ', depth);
      discription.Append(this.Name);
      discription.Append(Environment.NewLine);

      foreach (var document in this.documents)
      {
        discription.Append(document.GetDescription(depth + 2));
      }
      return discription.ToString();
    }

    public void AddDocument(IDocument document)
    {
      this.documents.Add(document);
    }

    #endregion

    #region Конструктры

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Название документа.</param>
    /// <exception cref="ArgumentException">Если будет передано пустое название документа, то будт выброшено исключение.</exception>
    public CompoundDocument(string name, int id) : base(name, id) { }

    #endregion
  }
}
