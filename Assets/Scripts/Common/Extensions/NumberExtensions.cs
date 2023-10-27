using UnityEngine;

namespace Match3Bonus
{
    public static class NumberExtensions
    {
        public static bool IsIn(this float value, FloatRange range)
        {
            return value >= range.Min && value <= range.Max;
        }

        public static int ToInt(this float value)
        {
            return Mathf.RoundToInt(value);
        }
    }
}
