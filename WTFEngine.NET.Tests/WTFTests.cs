using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WTFEngine.NET.Tests
{
    [TestClass]
    public class WTFTests
    {
        private readonly IEnumerable<string> _names = new List<string>
        {
            "Ed",
            "Edd",
            "Eddy",
            "Kevin",
            "Jimmy",
        };

        private readonly IEnumerable<string> _loveableNouns = new List<string>
        {
            "Plank",
            "Jawbreakers",
            "Sarah",
        };

        [TestMethod]
        public void GenerateSets_GivenCustomPatterrn_ReturnsString()
        {
            var wtf = new WTF(@"~([A-Za-z]*)");
            var template = "~Name loves ~LoveableNoun.";
            var sets = new List<IEnumerable<string>>
            {
                _names,
                _loveableNouns,
            };

            var str = wtf.Generate(template, sets);

            Assert.AreNotEqual(template, str);
        }
        
        [TestMethod]
        public void GenerateSets_GivenValidData_ReturnsString()
        {
            var wtf = new WTF();
            var template = "@Name loves @LoveableNoun.";
            var sets = new List<IEnumerable<string>>
            {
                _names,
                _loveableNouns,
            };

            var str = wtf.Generate(template, sets);

            Assert.AreNotEqual(template, str);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GenerateSets_GivenInvalidData_ThrowsException()
        {
            var wtf = new WTF();
            var template = "@Name loves @LoveableNoun.";
            var sets = new List<IEnumerable<string>>
            {
                _names,
            };

            wtf.Generate(template, sets);
        }

        [TestMethod]
        public void GenerateParams_GivenCustomPattern_ReturnsString()
        {
            var wtf = new WTF(@"~([A-Za-z]*)");
            var template = "~Name loves ~LoveableNoun.";

            var str = wtf.Generate(template, _names.First(), _loveableNouns.First());

            Assert.AreEqual("Ed loves Plank.", str);
        }

        [TestMethod]
        public void GenerateParams_GivenValidData_ReturnsString()
        {
            var wtf = new WTF();
            var template = "@Name loves @LoveableNoun.";

            var str = wtf.Generate(template, _names.First(), _loveableNouns.First());

            Assert.AreEqual("Ed loves Plank.", str);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GenerateParams_GivenInvalidData_ThrowsException()
        {
            var wtf = new WTF();
            var template = "@Name loves @LoveableNoun.";

            wtf.Generate(template, _names.First());
        }

        [TestMethod]
        public void GenerateDictionary_GivenValidData_ReturnsString()
        {
            var wtf = new WTF();
            var template = "@Name loves @LoveableNoun.";
            var dict = new Dictionary<string, string>
            {
                { "@Name", _names.First() },
                { "@LoveableNoun", _loveableNouns.First() },
            };

            var str = wtf.Generate(template, dict);

            Assert.AreEqual("Ed loves Plank.", str);
        }
        
        [TestMethod]
        public void GenerateEnumerable_GivenValidData_ReturnsString()
        {
            var wtf = new WTF();
            var template = "@Name loves @LoveableNoun.";
            var kvp = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("@Name", _names.First()),
                new KeyValuePair<string, string>("@LoveableNoun", _loveableNouns.First()),
            };

            var str = wtf.Generate(template, kvp);

            Assert.AreEqual("Ed loves Plank.", str);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GenerateEnumerable_GivenInvalidData_ThrowsException()
        {
            var wtf = new WTF();
            var template = "@Name loves @LoveableNoun.";
            var kvp = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("@Name", _names.First()),
                new KeyValuePair<string, string>("@Name", _loveableNouns.First()),
            };

            wtf.Generate(template, kvp);
        }
    }
}
