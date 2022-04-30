using Avalonia.Controls;
using squashr.ViewModels;
using squashr.Models;
using squashr.Services;
using squashr.Controls;

namespace squashr.Views
{
    public partial class SelectUserView : UserControl
    {
        public SelectUserView()
        {
            InitializeComponent();
            DataContext = new SelectUserViewModel();
            foreach(LocalUser user in Data.LocalUsers)
            {
                UserBox box = new UserBox();
                box.User = user;
                this.Find<StackPanel>("Users").Children.Add(box);
            }
        }
    }
}
