using System.Collections.Generic;

namespace WTFEngine.NET
{
    /// <summary>
    /// An interface for a WTF engine.
    /// </summary>
    public interface IWTF
    {
        /// <summary>
        /// Generates a string from a set of items.
        /// </summary>
        /// <param name="template">The string template to use.</param>
        /// <param name="sets">A collection of sets of strings for generating the random input.</param>
        /// <returns>A mad-libbed sentence.</returns>
        string Generate(string template, IEnumerable<IEnumerable<string>> sets);
        /// <summary>
        /// Generates a string from a set of items.
        /// </summary>
        /// <param name="template">The string template to use.</param>
        /// <param name="items">The set of items to place in the template.</param>
        /// <returns>A mad-libbed sentence.</returns>
        string Generate(string template, params string[] sets);
        /// <summary>
        /// Generates a string from a set of items.
        /// </summary>
        /// <param name="template">The string template to use.</param>
        /// <param name="items">The set of items to place in the template.</param>
        /// <returns>A mad-libbed sentence.</returns>
        string Generate(string template, IDictionary<string, string> sets);
        /// <summary>
        /// Generates a string from a set of items.
        /// </summary>
        /// <param name="template">The string template to use.</param>
        /// <param name="items">The set of items to place in the template.</param>
        /// <returns>A mad-libbed sentence.</returns>
        string Generate(string template, IEnumerable<KeyValuePair<string, string>> sets);
    }
}
