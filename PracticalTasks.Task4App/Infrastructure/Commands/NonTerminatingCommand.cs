namespace PracticalTasks.Task4App.Infrastructure.Commands
{
  /// <summary>
  /// Команнда, которая не завершает процесс программу.
  /// </summary>
  internal abstract class NonTerminatingCommand : AppCommand
  {
    protected NonTerminatingCommand(IUserInterface userInterface) : base(false, userInterface) { }
  }
}
