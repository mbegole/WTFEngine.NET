using System;
using System.Collections.Generic;
using System.Linq;

namespace WTFEngine.NET
{
    /// <summary>
    /// Provides extension implementations for the WTF Engine.
    /// </summary>
    public static class WTFExtensions
    {
        /// <summary>
        /// Returns a random element from the collection.
        /// </summary>
        /// <param name="enumerable">The collection of elements.</param>
        public static T RandomElement<T>(this IEnumerable<T> enumerable) => enumerable.RandomElementUsing(new Random());

        /// <summary>
        /// Returns a random element from the collection using a provided random number generator.
        /// </summary>
        /// <param name="enumerable">The collection of elements.</param>
        /// <param name="rand">The random number generator.</param>
        public static T RandomElementUsing<T>(this IEnumerable<T> enumerable, Random rand) => enumerable.ElementAt(rand.Next(0, enumerable.Count()));
    }
}
