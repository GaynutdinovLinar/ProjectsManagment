namespace Projects.Service.Commands.Interfaces
{
    public interface IProjectCommand
    {
        void Execute();

        bool CanExecute();
    }
}
