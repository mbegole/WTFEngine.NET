using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WTFEngine.NET
{
    /// <summary>
    /// The WTF engine.
    /// </summary>
    public sealed class WTF : IWTF
    {
        #region Declarations

        private readonly string _pattern = @"@([A-Za-z]*)";

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="WTF"/>.
        /// </summary>
        public WTF()
        {
        }

        /// <summary>
        /// Creates a new instance of <see cref="WTF"/>.
        /// </summary>
        /// <param name="pattern">A custom Regular Expression pattern for matching.</param>
        public WTF(string pattern)
        {
            _pattern = pattern;
        }

        #endregion

        /// <summary>
        /// Generates a string from a set of items.
        /// </summary>
        /// <param name="template">The string template to use.</param>
        /// <param name="sets">A collection of sets of strings for generating the random input.</param>
        /// <returns>A mad-libbed sentence.</returns>
        public string Generate(string template, IEnumerable<IEnumerable<string>> sets)
        {
            var items = new HashSet<string>();

            foreach (var set in sets)
                items.Add(set.RandomElement());

            return Generate(template, items.ToArray());
        }

        /// <summary>
        /// Generates a string from a set of items.
        /// </summary>
        /// <param name="template">The string template to use.</param>
        /// <param name="items">The set of items to place in the template.</param>
        /// <returns>A mad-libbed sentence.</returns>
        public string Generate(string template, params string[] items)
        {
            if (template.Split(' ').Where(x => Regex.Match(x, _pattern).Success).Count() != items.Count())
                throw new IndexOutOfRangeException("The number of replacements in the string doesn't match the number of items provided.");

            foreach (var item in items)
            {
                var replace = Regex.Match(template, _pattern);

                template = template.Replace(replace.Value, item);
            }

            return template;
        }

        /// <summary>
        /// Generates a string from a set of items.
        /// </summary>
        /// <param name="template">The string template to use.</param>
        /// <param name="items">The set of items to place in the template.</param>
        /// <returns>A mad-libbed sentence.</returns>
        public string Generate(string template, IDictionary<string, string> items)
        {
            foreach (var item in items)
                template = template.Replace(item.Key, item.Value);

            return template;
        }

        /// <summary>
        /// Generates a string from a set of items.
        /// </summary>
        /// <param name="template">The string template to use.</param>
        /// <param name="items">The set of items to place in the template.</param>
        /// <returns>A mad-libbed sentence.</returns>
        public string Generate(string template, IEnumerable<KeyValuePair<string, string>> items)
        {
            // Validate the item list by checking for duplicate names.
            if (items.GroupBy(x => x.Key).Where(x => x.Count() > 1).Count() != 0)
                throw new InvalidOperationException("The set contained duplicate keys.");

            foreach (var item in items)
                template = template.Replace(item.Key, item.Value);

            return template;
        }
    }
}
