using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLocatorPattern.Services
{
    public class CarDelivery : ICarDelivery
    {
        public string DeliveryPackage()
        {
            return "Delivery package through car";
        }
    }
}
