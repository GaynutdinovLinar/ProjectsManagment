using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace MVVM.Navigation.Service
{
    public class FrameService : INotifyPropertyChanged
    {

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
}
