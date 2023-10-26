using UnityEngine;

namespace Match3Bonus
{
    public static class StringExtensions
    {
        public static string ToStringWith(this object message, Color color)
        {
            string hexColor = ColorUtility.ToHtmlStringRGB(color);
            return $"<color=#{hexColor}>{message}</color>";
        }
    }
}
