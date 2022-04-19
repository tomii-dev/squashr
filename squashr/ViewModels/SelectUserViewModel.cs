using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
