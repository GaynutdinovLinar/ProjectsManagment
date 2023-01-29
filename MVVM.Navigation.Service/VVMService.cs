using System;
using System.Collections.Generic;
using System.Windows;

namespace MVVM.Navigation.Service
{
    public abstract class VVMService
    {
        public abstract Dictionary<Type, ViewActions> VMDictionary { get; }

        public virtual FrameworkElement CreateView<D>()
        {
            return VMDictionary[typeof(D)].CreateView.Invoke();
        }

        public virtual void OpenView<D>(FrameworkElement view)
        {
            VMDictionary[typeof(D)].OpenView.Invoke(view);
        }

        public FrameworkElement CreateAndOpenView<D>()
        {
            var view = CreateView<D>();
            OpenView<D>(view);
            return view;
        }

        public D CreateViewAndGetViewModel<D>()
        {
            return GetViewModel<D>(CreateAndOpenView<D>());
        }

        public virtual D GetViewModel<D>(FrameworkElement view)
        {
            return (D)view.DataContext;
        }
    }

    public record class ViewActions(Func<FrameworkElement> CreateView, Action<FrameworkElement> OpenView);
}
