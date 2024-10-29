using System.Text;

namespace PracticalTasks.Task4App.Documents
{
  /// <summary>
  /// Составной документ.
  /// </summary>
  internal class CompoundDocument : DocumentBase, ICompoundDocument
  {
    #region Методы

    /// <summary>
    /// Получить рекурсивно описание документа.
    /// </summary>
    /// <param name="document">Документ, описание которого нудно получить.</param>
    /// <param name="depth">Уровень вложенности документа, задает ширину отступа при форматирвоании вывода.</param>
    /// <returns>Форматированный вывод (с отступами) описания документа.</returns>
    private static string GetDescriptionInternal(IDocument document, int depth)
    {
      StringBuilder discription = new();
      discription.Append(' ', depth);
      discription.Append(document.Name);
      discription.Append(Environment.NewLine);

      if (document is ICompoundDocument compoundDocument)
      {
        foreach (var doc in compoundDocument.Children)
        {
          discription.Append(GetDescriptionInternal(doc, depth + 2));
        }
      }
      return discription.ToString();
    }

    #endregion

    #region ICompoundDocument

    private readonly List<IDocument> children;
    public IEnumerable<IDocument> Children => this.children;

    public override string GetDescription()
    {
      return GetDescriptionInternal(this, 1);
    }

    public void AddDocument(IDocument document)
    {
      this.children.Add(document);
    }

    #endregion

    #region Конструктры

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Название документа.</param>
    /// <exception cref="ArgumentException">Если будет передано пустое название документа, то будт выброшено исключение.</exception>
    public CompoundDocument(string name, int id) : base(name, id)
    {
      this.children = new List<IDocument>();
    }

    #endregion
  }
}
