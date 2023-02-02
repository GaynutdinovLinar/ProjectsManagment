using MVVM.Navigation.Service;
using ViewModels.Base;

namespace ViewModels
{
    public class MainWindowVM
    {
        public MainWindowVM(VVMService dependencyVVMService)
        {
            _dependencyVVMService = dependencyVVMService;
        }

        private readonly VVMService _dependencyVVMService;

        //public Command OpenPage => new Command(obj =>
        //{
        //    var vm = _dependencyVVMService.CreateViewAndGetViewModel<PageVM>();
        //});

        //public Command ClosePage => new Command(obj =>
        //{
        //    var view = _dependencyVVMService.GetView<PageVM>();
        //    _dependencyVVMService.CloseView<PageVM>(view);
        //});
    }
}
