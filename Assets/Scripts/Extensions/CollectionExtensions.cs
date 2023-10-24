using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Match3Bonus
{
    public static class CollectionExtensions
    {
        public static bool IsNullOrEmpty(this ICollection collection)
        {
            return collection == null || collection.Count == 0;
        }

        /// <param name="elements"> elements must not null/empty </param>
        public static T GetRandomElement<T>(this IList<T> elements)
        {
            int randomIndex = Random.Range(0, elements.Count);
            return elements[randomIndex];
        }
    }
}
