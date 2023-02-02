using System;
using System.Windows;
using IoCViews = Views.IoC;

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

            var window = IoCViews.MainWindow;
            window.Show();

        }
    }
}
