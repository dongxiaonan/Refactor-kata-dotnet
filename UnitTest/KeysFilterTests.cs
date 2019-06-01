using System.Collections.Generic;
using Kata.Refactor.Before;
using Xunit;

namespace UnitTest
{
    public class KeysFilterTests
    {
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void ShouldReturnEmptyKeysWhenMasksHasNoValue(bool isGoldenKey)
        {
            var keysFilter = new KeysFilter();
            Assert.Empty(keysFilter.Filter(new List<string>(){}, isGoldenKey));
        }
        
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void ShouldReturnEmptyKeysWhenMasksIsNull(bool isGoldenKey)
        {
            var keysFilter = new KeysFilter();
            Assert.Empty(keysFilter.Filter(new List<string>(){}, isGoldenKey));
        }
    }
}