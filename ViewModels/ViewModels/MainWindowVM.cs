using MVVM.Navigation.Service;

namespace ViewModels.ViewModels
{
    public class MainWindowVM : ViewModel
    {
        #region Fields

        private readonly NavigationService _navigationService;

        #endregion

        public MainWindowVM(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        #region Properties

        #endregion

        #region Methods

        #endregion

        #region Commands

        private Command _openProjectsPage;
        public Command OpenProjectsPage => GetOrCreateCommand(ref _openProjectsPage, obj =>
        {
            _navigationService.CreateViewAndGetViewModel<ProjectPageVM>();
        });

        #endregion
    }
}
