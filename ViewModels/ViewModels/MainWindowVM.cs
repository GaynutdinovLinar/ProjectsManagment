using MVVM.Navigation.Service;

namespace ViewModels.ViewModels
{
    public class MainWindowVM : ViewModel
    {
        public MainWindowVM(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        #region Fields

        private readonly NavigationService _navigationService;

        #endregion

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
