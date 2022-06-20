using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Szeregowanie.Utility
{
    class Bindable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        virtual protected void RaisePropertyChanged([CallerMemberName]string propName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}