using Microsoft.Extensions.DependencyInjection;
using MVVM.Navigation.Service;
using System;
using System.Collections.Generic;
using ViewModels.ViewModels;
using Views.Windows;

namespace Views
{
    public class IoC
    {
        private static ServiceProvider? _provider;

        public static void SetProvider(ServiceProvider? provider) => _provider = provider;

        public static void Init(ServiceCollection services)
        {
            VVMService.VMDictionary = new Dictionary<Type, ViewActions>()
            {
                //{ typeof(PageVM), VVMService.StandartPage(() => IoCViews.Page1, () => IoCViews.MainWindowMainFrame) }
            };

            #region Views

            services.AddSingleton<MainWindow>();

            #endregion

            #region ViewModels

            services.AddSingleton<MainWindowVM>();

            #endregion

            #region Frames

            services.AddSingleton<FrameService<MainWindowVM>>();

            #endregion
        }

        #region Views

        public static MainWindow MainWindow => _provider.GetRequiredService<MainWindow>();

        #endregion

        #region ViewModels

        public static MainWindowVM MainWindowVM => _provider.GetRequiredService<MainWindowVM>();

        #endregion

        #region Frames

        public static FrameService<MainWindowVM> MainWindowMainFrame => _provider.GetRequiredService<FrameService<MainWindowVM>>();

        #endregion
    }
}
