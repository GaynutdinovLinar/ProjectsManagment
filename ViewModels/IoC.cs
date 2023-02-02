using Microsoft.Extensions.DependencyInjection;

namespace ViewModels
{
    public class IoC
    {
        private static ServiceProvider? _provider;

        public static void SetProvider(ServiceProvider? provider) => _provider = provider;

        public static void Init(ServiceCollection services)
        {
            #region Services

            //services.AddSingleton<MainWindow>();

            #endregion
        }
    }
}
