using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimusTest.Domain.Interfaces.Services
{
    public interface IFoodOrderService
    {
        string Execute(string orderCSV);
    }
}
