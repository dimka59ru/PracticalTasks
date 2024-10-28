using System.Text;

namespace PracticalTasks.Task4App.Documents
{
  /// <summary>
  /// Простой документ.
  /// </summary>
  internal class Document : DocumentBase
  {
    #region IDocument

    public override string GetDescription(int depth)
    {
      StringBuilder discription = new();
      discription.Append(' ', depth);
      discription.Append(this.Name);
      discription.Append(Environment.NewLine);
      return discription.ToString();
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
