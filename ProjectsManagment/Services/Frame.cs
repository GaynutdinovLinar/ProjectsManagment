using MVVM.Navigation.Service;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace ProjectsManagment.Services
{
    public class Frame<T> : FrameService
    {
        public Frame()
        {
            OpennedPages = new ObservableCollection<VVM>();
        }

        public ObservableCollection<VVM> OpennedPages { get; init; }

        public void ClosePage(Page? page)
        {
            if (page == null)
                return;

            OpennedPages.Remove(OpennedPages.FirstOrDefault(vvm => vvm.View.Equals(page)));
            ChangePage(OpennedPages.Count > 0 ? OpennedPages.Last().View : null);
            UpdateCurrentPage();
        }

        public void AddPage(Type type, Page? page)
        {
            if (page == null)
                return;

            OpennedPages.Add(new VVM(type, page));
            ChangePage(page);
        }

        public Page? GetPage(Type type)
        {
            return OpennedPages.FirstOrDefault(vvm => vvm.ViewModel == type)?.View;
        }

        public void UpdateCurrentPage()
        {
            OnPropertyChanged(nameof(CurrentPage));
        }
    }

    public record class VVM(Type ViewModel, Page View);
}
