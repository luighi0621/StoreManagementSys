using ServiceLocatorPattern.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLocatorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarDelivery carDelivery = new CarDelivery();
            IMotoDelivery motoDelivery = new MotoDelivery();
            IWalkDelivery walkDelivery = new WalkDelivery();
            ServiceLocator.Instance.RegisterService(carDelivery);
            ServiceLocator.Instance.RegisterService(motoDelivery);
            ServiceLocator.Instance.RegisterService(walkDelivery);

            IDelivery testService = ServiceLocator.Instance.GetService<IMotoDelivery>();

            string msg = testService.DeliveryPackage();
            Console.WriteLine(msg);

            Console.ReadKey();
        }
    }

    public abstract class Person
    {
        protected string Some;

        public Person(string name)
        {
            Some = name;
        }

        public abstract string OtherMethod();

        public virtual string SomeMethod()
        {
            return "HI";
        }
    }

    public class Profesor : Person
    {
        public Profesor(string name) : base(name)
        {
        }

        public override string OtherMethod()
        {
            throw new NotImplementedException();
        }
    }
}
