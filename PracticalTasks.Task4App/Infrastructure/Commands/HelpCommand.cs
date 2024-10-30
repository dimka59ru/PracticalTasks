namespace PracticalTasks.Task4App.Infrastructure.Commands
{
  /// <summary>
  /// Команда вывода справки по остальным командам.
  /// </summary>
  internal class HelpCommand : NonTerminatingCommand
  {
    protected override bool InternalCommand()
    {
      this.UserInterface.WriteMessage("Команды:");
      this.UserInterface.WriteMessage("\tЭкспортировать документ (t)");
      this.UserInterface.WriteMessage("\tВыход (q)");
      this.UserInterface.WriteMessage("\tСправка (?)");
      return true;
    }

    public HelpCommand(IUserInterface userInterface) : base(userInterface) { }
  }
}
