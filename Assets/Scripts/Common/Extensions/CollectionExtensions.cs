using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3Bonus
{
    public static class CollectionExtensions
    {
        public static T GetRandomElementOrDefault<T>(this IList<T> elements)
        {
            if (elements.IsNullOrEmpty())
            {
                return default;
            }

            return elements.GetRandomElement();
        }

        /// <param name="elements"> elements must not null/empty </param>
        private static T GetRandomElement<T>(this IList<T> elements)
        {
            int randomIndex = Random.Range(0, elements.Count);
            return elements[randomIndex];
        }

        public static bool IsNullOrEmpty(this ICollection collection)
        {
            return collection == null || collection.Count == 0;
        }

        private static bool IsNullOrEmpty<T>(this IList<T> collection)
        {
            return collection == null || collection.Count == 0;
        }
    }
}
