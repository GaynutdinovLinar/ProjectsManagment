using Microsoft.Extensions.DependencyInjection;
using System.Windows.Navigation;
using ViewModels.ViewModels;

namespace ViewModels
{
    public class IoC
    {
        private static ServiceProvider? _provider;

        public static void SetProvider(ServiceProvider? provider) => _provider = provider;

        public static void Init(ServiceCollection services)
        {
            #region ViewModels

            services.AddSingleton<MainWindowVM>();

            services.AddSingleton<ProjectPageVM>();

            #endregion

            #region Services

            services.AddSingleton<NavigationService>();

            #endregion
        }

        #region ViewModels

        public static MainWindowVM MainWindowVM => _provider.GetRequiredService<MainWindowVM>();

        public static ProjectPageVM ProjectPageVM => _provider.GetRequiredService<ProjectPageVM>();

        #endregion
    }
}
