using UltimusTest.Domain.Enumerators;
using UltimusTest.Domain.Helper;

namespace UltimusTest.Tests
{
    public class EnumHelperTest
    {
        [Fact]
        public void TestGetDescription()
        {
            var expected = "coffee";

            Assert.Equal(expected, MorningMenuEnum.Coffee.GetDescription());
        }
    }
}
