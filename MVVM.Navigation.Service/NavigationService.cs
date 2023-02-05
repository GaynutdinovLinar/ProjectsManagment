using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MVVM.Navigation.Service
{
    /// <summary>
    /// Класс содержащий базовую логику взаимодействия с View и ViewModel
    /// </summary>
    public class NavigationService
    {

        /// <summary>
        /// Коллекция действий для ViewModel
        /// </summary>
        public static Dictionary<Type, ViewActions> VMDictionary { get; set; }

        /// <summary>
        /// Создать представление
        /// </summary>
        /// <typeparam name="D"></typeparam>
        /// <returns></returns>
        public FrameworkElement CreateView<D>()
        {
            return VMDictionary[typeof(D)].CreateView.Invoke();
        }

        /// <summary>
        /// Открыть представление
        /// </summary>
        /// <typeparam name="D"></typeparam>
        /// <param name="view"></param>
        public void OpenView<D>(FrameworkElement view)
        {
            VMDictionary[typeof(D)].OpenView.Invoke(view);
        }

        /// <summary>
        /// Создать и открыть представление
        /// </summary>
        /// <typeparam name="D"></typeparam>
        /// <returns></returns>
        public FrameworkElement CreateAndOpenView<D>()
        {
            var view = CreateView<D>();
            OpenView<D>(view);
            return view;
        }

        /// <summary>
        /// Создать и открыть представление, получив привязанный ViewModel
        /// </summary>
        /// <typeparam name="D"></typeparam>
        /// <returns></returns>
        public D CreateViewAndGetViewModel<D>()
        {
            return GetViewModel<D>(CreateAndOpenView<D>());
        }

        /// <summary>
        /// Получить привязанный ViewModel
        /// </summary>
        /// <typeparam name="D"></typeparam>
        /// <param name="view"></param>
        /// <returns></returns>
        public D GetViewModel<D>(FrameworkElement view)
        {
            return (D)view.DataContext;
        }

        public void CloseView<T>(FrameworkElement view)
        {
            VMDictionary[typeof(T)].CloseView?.Invoke(view);
        }

        public FrameworkElement GetView<T>()
        {
            return VMDictionary[typeof(T)].GetView?.Invoke();
        }

        public static ViewActions StandartPage<T>(Func<Page> GetPage, Func<PagesContainer<T>> GetFrame)
        {
            return new ViewActions(
                  () => GetPage?.Invoke(),
                  view => GetFrame?.Invoke().AddPage(typeof(T), view as Page),
                  view => GetFrame?.Invoke().ClosePage(view as Page),
                  () => GetFrame?.Invoke().GetPage(typeof(T)));
        }
    }


    /// <summary>
    /// Содежит действия необходимые для работы с представлением
    /// </summary>
    /// <param name="CreateView"></param>
    /// <param name="OpenView"></param>
    public record class ViewActions(Func<FrameworkElement> CreateView,
        Action<FrameworkElement> OpenView,
        Action<FrameworkElement> CloseView,
        Func<FrameworkElement> GetView);
}
