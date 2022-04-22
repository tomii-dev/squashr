using ProtoBuf;
using squashr.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace squashr.Services
{
    public static class Data
    { 
        private static List<LocalUser> _localUsers;
        private static LocalUser _currentUser;
        public static List<LocalUser> LocalUsers { get { return _localUsers; } }
        public static LocalUser CurrentUser { 
            get { return _currentUser; } 
            set { _currentUser = value; }
        }
        static Data()
        {
            _currentUser = new LocalUser();
            try{
                _localUsers =
                    Serializer.Deserialize<List<LocalUser>>(new FileStream("usr.sq", FileMode.Open, FileAccess.Read));
            }catch { 
                _localUsers = new List<LocalUser>();
            }
        }

        private static void PushUsers()
        {
            FileStream fileStream = new FileStream("usr.sq", FileMode.OpenOrCreate, FileAccess.Write);
            Serializer.Serialize(fileStream, _localUsers);
            fileStream.Close();
        }
        public static void AddLocalUser(LocalUser localUser)
        {
            _localUsers.Add(localUser);
            PushUsers();
        }
    }
}
