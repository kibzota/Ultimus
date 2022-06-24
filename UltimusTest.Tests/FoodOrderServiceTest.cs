using UltimusTest.Domain.Services;

namespace UltimusTest.Tests
{
    public class FoodOrderServiceTest
    {
        [Theory]
        [InlineData("morning, 1, 2, 3", "eggs, toast, coffee")]
        [InlineData("morning, 2, 1, 3", "eggs, toast, coffee")]
        [InlineData("morning, 1, 2, 3, 4", "eggs, toast, coffee, error")]
        [InlineData("morning, 1, 2, 3, 3, 3", "eggs, toast, coffee(x3)")]
        [InlineData("MoRninG, 1, 2, 3, 3, 3", "eggs, toast, coffee(x3)")]
        [InlineData("night, 1, 2, 3, 4", "steak, potato, wine, cake")]
        [InlineData("night, 1, 2, 2, 4", "steak, potato(x2), cake")]
        [InlineData("night, 1, 2, 3, 5", "steak, potato, wine, error")]
        [InlineData("night, 1, 1, 2, 3, 5", "steak, error")]

        public void ExecuteTheoryMustBeTrue(string input, string expected)
        {
            var service = new FoodOrderService();

            var result = service.Execute(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("morn, 1, 2, 3")]
        [InlineData("morning, g, 1, 2, 3")]
        public void ExecuteShouldRiseException(string input)
        {
            var service = new FoodOrderService();

            var ex = Assert.ThrowsAny<Exception>(() => service.Execute(input));


            Assert.NotNull(ex);
        }
    }
}