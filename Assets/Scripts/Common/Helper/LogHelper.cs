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
            Debug.LogError(message.ToLogString(Color.red));
#endif
        }

        public static void Log(string message, object data)
        {
#if UNITY_EDITOR
            Debug.Log($"{message.ToStringWith(Color.yellow)}: {data.ToLogString(Color.green)}");
#endif
        }

        public static void Log(object message)
        {
#if UNITY_EDITOR
            Debug.Log(message.ToLogString(Color.green));
#endif
        }

        private static string ToLogString(this object message, Color color)
        {
            return $"{LOG_PREFIX}{message.ToStringWith(color)}";
        }
    }
}
