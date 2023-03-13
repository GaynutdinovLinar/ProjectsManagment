using Projects.Service.Objects;

namespace ViewModels.ViewModels
{
    public class ProjectPageVM : ViewModel
    {
        #region Fields

        #endregion

        public ProjectPageVM()
        {
            Projects = new ObservableCollection<Project>();
        }

        #region Properties

        public ObservableCollection<Project> Projects { get; set; }

        #endregion

        #region Methods

        #endregion

        #region Commands

        private Command _openProjectsPage;
        public Command OpenProjectsPage => GetOrCreateCommand(ref _openProjectsPage, obj =>
        {
            
        });

        #endregion
    }
}
