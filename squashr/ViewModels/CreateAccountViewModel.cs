using Avalonia.Interactivity;
using System;
using squashr.Views;
using squashr.Services;

namespace squashr.ViewModels
{
    public class CreateAccountViewModel : ViewModelBase
    {
        public CreateAccountViewModel() { 
            Events.LocalUserButtonClicked += OnLocalUserButtonClicked;
        }
        public void OnLocalUserButtonClicked(object sender)
        {
            MainWindowViewModel.InvokeViewChanged(new CreateLocalUserView());
        }

        public void OnWebUserButtonClicked(object sender)
        {
            //MainWindowViewModel.InvokeViewChanged();
        }
    }
}
