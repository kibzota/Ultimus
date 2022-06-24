using UltimusTest.Domain.Interfaces.Services;
using UltimusTest.Domain.Services;

namespace UltimusTest.Settings
{
    public class IocContainerConfiguration
    {
        public static void ConfigureService(IServiceCollection services)
        {
            services.AddTransient<IFoodOrderService, FoodOrderService>();

        }
    }
}
