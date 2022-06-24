using System.ComponentModel;

namespace UltimusTest.Domain.Enumerators
{
    public enum NightMenuEnum
    {
        [Description("steak")]
        Toast = 1,
        [Description("potato")]
        Potato = 2,
        [Description("wine")]
        Wine = 3,
        [Description("cake")]
        Cake = 4,
    }
}
