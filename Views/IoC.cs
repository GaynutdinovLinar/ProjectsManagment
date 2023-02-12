using Microsoft.Extensions.DependencyInjection;
using MVVM.Navigation.Service;
using System;
using System.Collections.Generic;
using ViewModels.ViewModels;
using Views.Pages;
using Views.Windows;

namespace Views
{
    public class IoC
    {
        private static ServiceProvider? _provider;

        public static void SetProvider(ServiceProvider? provider) => _provider = provider;

        public static void Init(ServiceCollection services)
        {
            NavigationService.VMDictionary = new Dictionary<Type, ViewActions>()
            {
                { typeof(ProjectPageVM), NavigationService.StandartPage(() => ProjectsPage, () => MainWindowPagesContainer) }
            };

            #region Views

            services.AddSingleton<MainWindow>();

            services.AddSingleton<ProjectsPage>();

            #endregion

            #region Frames

            services.AddSingleton<PagesContainer<MainWindowVM>>();

            #endregion
        }

        #region Views

        public static MainWindow MainWindow => _provider.GetRequiredService<MainWindow>();

        public static ProjectsPage ProjectsPage => _provider.GetRequiredService<ProjectsPage>();

        #endregion

        #region Frames

        public static PagesContainer<MainWindowVM> MainWindowPagesContainer => _provider.GetRequiredService<PagesContainer<MainWindowVM>>();

        #endregion
    }
}
