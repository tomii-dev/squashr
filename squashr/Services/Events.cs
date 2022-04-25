using System;
using System.Security;
using System.Reflection;
using System.Collections.Generic;

namespace squashr.Services
{
    public static class Events
    {
        private static Dictionary<EventType, Action<object>> _eventDict;

        public delegate void UIEvent(object sender);

        public static event UIEvent LocalUserButtonClicked;
        public static event UIEvent UsernameInputChanged;
        public static event UIEvent PasswordInputChanged;
        public static event UIEvent CreateButtonClicked;

        public static void Setup()
        {

            _eventDict = new Dictionary<EventType, Action<object>>()
            {
                {EventType.LocalUserButtonClicked, (o) => LocalUserButtonClicked.Invoke(o) },
                {EventType.UsernameInputChanged, (o) => UsernameInputChanged.Invoke(o)},
                {EventType.PasswordInputChanged, (o) => PasswordInputChanged.Invoke(o)},
                {EventType.CreateButtonClicked, (o) => CreateButtonClicked.Invoke(o)},
            };
        }

        public enum EventType
        {
            LocalUserButtonClicked,
            UsernameInputChanged,
            PasswordInputChanged,
            CreateButtonClicked,
        }

        public static void Invoke(EventType e, object sender){
            _eventDict[e](sender);
        }
    }
}
