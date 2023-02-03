using Microsoft.Extensions.DependencyInjection;
using MVVM.Navigation.Service;
using IoCViewModels = ViewModels.IoC;
using IoCViews = Views.IoC;

namespace ProjectsManagment
{
    public class IoC
    {
        private static ServiceProvider? _provider;

        public static void Init()
        {
            var services = new ServiceCollection();

            IoCViews.Init(services);
            IoCViewModels.Init(services);

            #region Services

            services.AddSingleton<VVMService>();
            services.AddSingleton<LocalSettingApp>();

            #endregion

            _provider = services.BuildServiceProvider();

            IoCViews.SetProvider(_provider);
            IoCViewModels.SetProvider(_provider);
        }
    }
}
