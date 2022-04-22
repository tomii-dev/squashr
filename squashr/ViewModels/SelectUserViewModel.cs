using System.ComponentModel;
using Avalonia.Controls;
using squashr.Models;
using squashr.Services;
using squashr.Controls;

namespace squashr.ViewModels
{
    public class SelectUserViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public SelectUserViewModel()
        {

        }

        public void RenderUsers(StackPanel panel)
        {
            foreach(LocalUser user in Data.LocalUsers)
            {
                UserBox box = new UserBox();
                box.User = user;
                panel.Children.Add(box);
            }
  
        }
    }
}
