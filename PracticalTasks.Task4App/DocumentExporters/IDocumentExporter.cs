using PracticalTasks.Task4App.Documents;

namespace PracticalTasks.Task4App.DocumentExporters
{
  /// <summary>
  /// Экспортер документа.
  /// </summary>
  internal interface IDocumentExporter
  {
    /// <summary>
    /// Документ, который будет экспортирован.
    /// </summary>
    IDocument Document { get; }

    /// <summary>
    /// Путь, куда экспортировать документ.
    /// </summary>
    public string PathToExport { get; }

    /// <summary>
    /// Экспортировать документ.
    /// </summary>
    void Export();
  }
}
