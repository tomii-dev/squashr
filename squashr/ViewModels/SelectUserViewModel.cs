using System.Collections.Generic;
using squashr.Controls;
using squashr.Models;
using squashr.Services;

namespace squashr.ViewModels
{
    public class SelectUserViewModel : ViewModelBase
    {
        public List<UserBox> Users
        {
            get{
                List<UserBox> users = new List<UserBox>();
                foreach (LocalUser user in Data.LocalUsers)
                {
                    UserBox box = new UserBox();
                    box.User = user;
                    users.Add(box);
                }
                return users;
            }
        }
    }
}
