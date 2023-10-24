using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Match3Bonus
{
    public static class ListenerHub
    {
        //We can design to have multiple listeners if need
        private static readonly Dictionary<Type, List<IListener>> _dictionary = new();

        public static void RegisterListener(IListener listener)
        {
            Type listenDataType = listener.DataType;
            if (!_dictionary.ContainsKey(listenDataType))
            {
                _dictionary.Add(listenDataType, new List<IListener>());
            }

            _dictionary[listenDataType].Add(listener);
        }

        public static void UnRegisterListener(IListener listener)
        {
            Type listenDataType = listener.DataType;
            _dictionary[listenDataType]?.Remove(listener);
        }

        public static List<IListener> FindListeners<T>() where T : IDataToListen
        {
            Type listenDataType = typeof(T);
            if (_dictionary.TryGetValue(listenDataType, out List<IListener> listeners))
            {
                return listeners;
            }

            LogHelper.Log("No listener for data of type: " + listenDataType);
            List<IListener> emptyListeners = new();
            return emptyListeners;
        }
    }
}
