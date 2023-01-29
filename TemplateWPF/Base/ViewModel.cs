using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TemplateWPF.Base
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public bool Set<T>(ref T field, T value, string nameProperty)
        {
            if (field.Equals(value))
                return false;

            field = value;
            OnPropertyChanged(nameProperty);
            return true;
        }
    }
}