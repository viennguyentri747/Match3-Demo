using System;
using System.Collections.Generic;
using UnityEngine;

namespace Match3Bonus
{
    public static class LogHelper
    {
        private const string LOG_PREFIX = "VienLog--";

        public static void LogEnumerable<T>(string message, IEnumerable<T> enumerable, Func<T, object> getData)
        {
#if UNITY_EDITOR
            List<object> messages = new();
            foreach (T element in enumerable)
            {
                object data = getData.Invoke(element);
                messages.Add(data);
            }

            Log(message, string.Join(",", messages));
#endif
        }

        public static void LogError(object message)
        {
#if UNITY_EDITOR
            Debug.LogError(message.ToStringWith(Color.red).ApplyPrefix());
#endif
        }

        public static void Log(string message, object data)
        {
#if UNITY_EDITOR
            Debug.Log($"{message.ToStringWith(Color.yellow)}: {data.ToStringWith(Color.green)}".ApplyPrefix());
#endif
        }

        private static string ApplyPrefix(this object message)
        {
            return $"{LOG_PREFIX}{message}";
        }
    }
}
