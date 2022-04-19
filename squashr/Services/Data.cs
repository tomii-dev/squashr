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
        public static List<LocalUser> LocalUsers { get { return _localUsers; } }

        static Data()
        {
            try
            {
                _localUsers =
                    Serializer.Deserialize<List<LocalUser>>(new FileStream("usr.sq", FileMode.Open, FileAccess.Read));
            }catch (Exception e) { 
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
