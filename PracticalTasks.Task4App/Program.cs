using PracticalTasks.Task4App.Infrastructure;
using PracticalTasks.Task4App.Infrastructure.Commands;

namespace PracticalTasks.Task4App
{
  internal class Program
  {
    static void Main(string[] args)
    {
      IUserInterface ui = new ConsoleUserInterface();
      IAppCommandFactory appCommandFactory = new AppCommandFactory(ui);
      IDocumentService documentService = new DocumentService(ui, appCommandFactory);
      documentService.Run();
    }
  }
}
