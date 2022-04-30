using System;
using System.Security;
using System.Reflection;
using System.Collections.Generic;

namespace squashr.Services
{
    public static class Events
    {
        private static Dictionary<UIEventType, Action<object>> _uiEventDict;
        private static Dictionary<RedirectEventType, Action<object>> _redirectEventDict;

        public delegate void UIEvent(object sender);
        public delegate void RedirectEvent(object data);

        public static event UIEvent LocalUserButtonClicked;
        public static event UIEvent UsernameInputChanged;
        public static event UIEvent PasswordInputChanged;
        public static event UIEvent CreateButtonClicked;
        public static event UIEvent CreateProjectButtonClicked;
        public static event UIEvent ProjectNameInputChange;

        public static event RedirectEvent ProjectOpened;
        public static void Setup()
        {
            ProjectOpened += (o) =>{};
            _uiEventDict = new Dictionary<UIEventType, Action<object>>()
            {
                {UIEventType.LocalUserButtonClicked, (o) => LocalUserButtonClicked.Invoke(o) },
                {UIEventType.UsernameInputChanged, (o) => UsernameInputChanged.Invoke(o)},
                {UIEventType.PasswordInputChanged, (o) => PasswordInputChanged.Invoke(o)},
                {UIEventType.CreateButtonClicked, (o) => CreateButtonClicked.Invoke(o)},
                {UIEventType.CreateProjectButtonClicked, (o) => CreateProjectButtonClicked.Invoke(o)},
                {UIEventType.ProjectNameInputChange, (o) => ProjectNameInputChange.Invoke(o)}
            };

            _redirectEventDict = new Dictionary<RedirectEventType, Action<object>>()
            {
                {RedirectEventType.ProjectOpened, (o) => ProjectOpened.Invoke(o)}
            };
        }

        public enum UIEventType
        {
            LocalUserButtonClicked,
            UsernameInputChanged,
            PasswordInputChanged,
            CreateButtonClicked,
            CreateProjectButtonClicked,
            ProjectNameInputChange
        }

        public enum RedirectEventType
        {
            ProjectOpened
        }

        public static void Invoke(UIEventType e, object sender) 
            => _uiEventDict[e](sender);

        public static void Invoke(RedirectEventType e, object data) 
            => _redirectEventDict[e](data);
    }
}
