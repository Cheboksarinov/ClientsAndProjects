using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Presentation.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void ForwardPropertyChangedNotification(INotifyPropertyChanged sourceViewModel, string sourcePropertyName, string targetPropertyName = null)
        {
            targetPropertyName = targetPropertyName ?? sourcePropertyName;
            sourceViewModel.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == sourcePropertyName)
                {
                    OnPropertyChanged(targetPropertyName);
                }
            };
        }
    }
}
