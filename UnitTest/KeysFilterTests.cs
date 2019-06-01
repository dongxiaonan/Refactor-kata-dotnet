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
        public void ShouldReturnEmptyKeysWhenMasksHasValue(bool isGoldenKey)
        {
            var keysFilter = new KeysFilter();
            Assert.Empty(keysFilter.Filter(new List<string>(){"GD0201"}, isGoldenKey));
        }
    }
}