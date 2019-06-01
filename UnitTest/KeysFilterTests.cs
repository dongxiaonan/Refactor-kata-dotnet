using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using Kata.Refactor.Before;
using Moq;
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
        
        [Fact]
        public void ShouldKeysWhenMasksIsNotEmptyAndIsGoldenKey()
        {
            var mockSessionService = new Mock<ISessionService>();
            var keysFilter = new KeysFilter()
            {
                SessionService = mockSessionService.Object
            };

            var savedGoldenKey = new List<string>(){"GD01aaaaaa", "GD02aaaaaa", "GD01bbbbbb", "GD02dddddd", "GD03aaaaaa"};
            mockSessionService.Setup(x => x.Get<List<string>>("GoldenKey")).Returns(savedGoldenKey);

            var marks = new List<string>(){"GD01aaaaaa", "GD02aaaaaa","GD02cccccc","GD02dddddd", "GD03aaaaaa", "SL01xxxxxx", "FAKEoooooo", "ooooooFAKE"};
            Assert.Equal(4, keysFilter.Filter(marks, true).Count);
        }
        
        [Fact]
        public void ShouldKeysWhenMasksIsNotEmptyAndIsNotGoldenKey()
        {
            var mockSessionService = new Mock<ISessionService>();
            var keysFilter = new KeysFilter()
            {
                SessionService = mockSessionService.Object
            };

            mockSessionService.Setup(x => x.Get<List<string>>("SilverKey")).Returns(new List<string>(){"SL01aaaaaa"});
            mockSessionService.Setup(x => x.Get<List<string>>("CopperKey")).Returns(new List<string>(){"CO01aaaaaa"});

            var marks = new List<string>(){"SL01aaaaaa", "CO01aaaaaa", "SL01xxxxxx","CO02xxxxxx", "FAKEoooooo", "ooooooFAKE"};
            Assert.Equal(3, keysFilter.Filter(marks, false).Count);
        }
    }
}