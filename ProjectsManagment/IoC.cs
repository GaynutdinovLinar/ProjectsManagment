using Microsoft.Extensions.DependencyInjection;
using MVVM.Navigation.Service;
using ProjectsManagment.Services;
using ProjectsManagment.VVM;
using ProjectsManagment.VVM.MainWindow;

namespace ProjectsManagment
{
    public class IoC
    {
        private static ServiceProvider? _provider;

        public static void Init()
        {
            var services = new ServiceCollection();

            #region Frames

            services.AddSingleton<Frame<MainWindowVM>>();

            #endregion

            #region Views

            services.AddSingleton<MainWindow>();
            services.AddSingleton<Page1>();

            #endregion

            #region ViewModels

            services.AddSingleton<MainWindowVM>();
            services.AddSingleton<PageVM>();

            #endregion

            #region Services

            services.AddSingleton<DependencyVVMService>();

            #endregion

            _provider = services.BuildServiceProvider();
        }

        #region Frames

        public static Frame<MainWindowVM> MainWindowMainFrame => _provider.GetRequiredService<Frame<MainWindowVM>>();

        #endregion

        #region Views

        public static MainWindow MainWindow => _provider.GetRequiredService<MainWindow>();

        public static Page1 Page1 => _provider.GetRequiredService<Page1>();

        #endregion

        #region ViewModels

        public static MainWindowVM MainWindowVM => _provider.GetRequiredService<MainWindowVM>();

        public static PageVM PageVM => _provider.GetRequiredService<PageVM>();

        #endregion
    }
}
