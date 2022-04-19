using Avalonia.Interactivity;
using System;

namespace squashr.ViewModels
{
    public class CreateAccountViewModel : ViewModelBase
    {
        public CreateAccountViewModel() { }
        public void OnLocalUserButtonClicked(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel.InvokeViewChanged(new CreateLocalUserViewModel());
        }

        public void OnWebUserButtonClicked(object sender, RoutedEventArgs e)
        {
            //MainWindowViewModel.InvokeViewChanged();
        }
    }
}
