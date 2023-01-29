using MVVM.Navigation.Service;
using ProjectsManagment.VVM;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ProjectsManagment.Services
{
    public class DependencyVVMService : VVMService
    {
        public override Dictionary<Type, ViewActions> VMDictionary => new()
        {
             {typeof(PageVM), StandartPage(IoC.MainWindowMainFrame)},
        };

        public void CloseView<T>(FrameworkElement view)
        {
            (VMDictionary[typeof(T)] as ExtViewActions).CloseView?.Invoke(view);
        }

        public FrameworkElement GetView<T>()
        {
            return (VMDictionary[typeof(T)] as ExtViewActions).GetView?.Invoke();
        }

        private ExtViewActions StandartPage<T>(Frame<T> frame)
        {
            return new ExtViewActions(
                  () => IoC.Page1,
                  view => frame.AddPage(typeof(T), view as Page),
                  view => frame.ClosePage(view as Page),
                  () => IoC.MainWindowMainFrame.GetPage(typeof(T)));
        }
    }

    public record class ExtViewActions(Func<FrameworkElement> CreateView, 
        Action<FrameworkElement> OpenView, 
        Action<FrameworkElement> CloseView, 
        Func<FrameworkElement> GetView) 
        : ViewActions(CreateView, OpenView);
}
