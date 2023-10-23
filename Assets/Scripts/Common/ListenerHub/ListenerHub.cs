using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Match3Bonus
{
    public static class ListenerHub
    {
        //We can design to have multiple listeners if need
        private static readonly Dictionary<Type, IListener> _dictionary = new();

        public static void RegisterListener(IListener listener)
        {
            Type listenDataType = listener.DataType;
            _dictionary[listenDataType] = listener;
        }

        public static void UnRegisterListener(IListener listener)
        {
            Type listenDataType = listener.DataType;
            if (_dictionary[listenDataType] == listener)
            {
                _dictionary.Remove(listenDataType);
            }
        }

        public static IListener FindListener<T>() where T : IDataToListen
        {
            Type listenDataType = typeof(T);
            if (_dictionary.TryGetValue(listenDataType, out IListener listener))
            {
                return listener;
            }

            LogHelper.Log("No listener for data of type: " + listenDataType);
            return null;
        }
    }
}
