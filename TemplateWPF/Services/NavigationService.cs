using TemplateWPF.Base;
using System.Windows.Controls;

namespace TemplateWPF.Services
{
    public static class NavigationService
    {

        private static Dictionary<Type, Func<Page>> _viewDictionary = new();

        public static void AddDependency<T>(Func<Page> createView) where T : ViewModel
        {
            _viewDictionary.Add(typeof(T), createView);
        }

        public static FrameworkElement CreateView<T>()
        {
            return _viewDictionary[typeof(T)].Invoke();
        }

        public static T GetViewModel<T>(this FrameworkElement view) => (T)view.DataContext;

    }
}
