using PracticalTasks.Task4App.Documents;

namespace PracticalTasks.Task4App.DocumentProcessors
{
  /// <summary>
  /// Базовый класс сервиса импорта документа.
  /// </summary>
  internal abstract class DocumentTransferProcessorBase : IDocumentProcessor
  {
    #region Методы

    /// <summary>
    /// Получить документ.
    /// </summary>
    /// <param name="id">Id документа.</param>
    /// <returns>Документ или null, если документ не удалось получить.</returns>
    protected abstract IDocument? GetDocument(int id);

    /// <summary>
    /// Отправить документ.
    /// </summary>
    /// <param name="document">Отправляемый документ.</param>
    protected abstract void SendDocument(IDocument document);

    #endregion

    #region IDocumentProcessor

    public bool Process(int id)
    {
      IDocument? document = this.GetDocument(id);
      if (document != null)
      {
        this.SendDocument(document);
        return true;
      }
      else
      {
        return false;
      }
    }

    #endregion
  }
}
