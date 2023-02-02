using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace MVVM.Navigation.Service
{
    public class FrameService<T> : INotifyPropertyChanged
    {
        public FrameService()
        {
            OpennedPages = new ObservableCollection<VVM>();
        }

        private Page? _currentPage;

        /// <summary>
        /// Текущая страница
        /// </summary>
        public Page? CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
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

        /// <summary>
        /// Сменить текущую страницу
        /// </summary>
        /// <param name="page"></param>
        public void ChangePage(Page? page)
        {
            CurrentPage = page;

            OnChangePage?.Invoke(page);
        }

        protected void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public event Action<Page?>? OnChangePage;
        public event PropertyChangedEventHandler? PropertyChanged;
    }

    public record VVM (Type ViewModel, Page View);
}
