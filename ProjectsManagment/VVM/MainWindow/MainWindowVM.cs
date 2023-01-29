using ProjectsManagment.Services;
using ProjectsManagment.VVM.Base;

namespace ProjectsManagment.VVM.MainWindow
{
    public class MainWindowVM
    {
        public MainWindowVM(DependencyVVMService dependencyVVMService)
        {
            _dependencyVVMService = dependencyVVMService;
        }

        private readonly DependencyVVMService _dependencyVVMService;

        public Command OpenPage => new Command(obj =>
        {
            var vm = _dependencyVVMService.CreateViewAndGetViewModel<PageVM>();
        });

        public Command ClosePage => new Command(obj =>
        {
            var view = _dependencyVVMService.GetView<PageVM>();
            _dependencyVVMService.CloseView<PageVM>(view);
        });
    }
}
