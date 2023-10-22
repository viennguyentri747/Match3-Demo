using System;
using System.Collections.Generic;
using UnityEngine;

namespace Match3Bonus
{
    public static class Logger
    {
        public static void LogErrorLoop<T>(IEnumerable<T> collection, Func<T, string> getLogStr)
        {
#if UNITY_EDITOR
            foreach (T element in collection)
            {
                string logStr = getLogStr.Invoke(element);
                LogError(logStr);
            }
#endif
        }

        public static void LogErrorIf(bool isHappen, string str)
        {
#if UNITY_EDITOR
            if (isHappen)
            {
                LogError(str);
            }
#endif
        }

        public static void LogError(string str)
        {
#if UNITY_EDITOR
            Debug.LogError(str);
#endif
        }
        
        public static void Log(string str)
        {
#if UNITY_EDITOR
            Debug.Log(str);
#endif
        }
    }
}