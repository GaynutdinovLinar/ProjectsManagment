using ProjectsManagment.VVM.MainWindow;
using System.Windows;

namespace ProjectsManagment
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            IoC.Init();

            new MainWindow().Show();
        }
    }
}
