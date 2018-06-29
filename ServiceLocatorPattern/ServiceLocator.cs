using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLocatorPattern
{
    public class ServiceLocator
    {
        private readonly IDictionary<Type, object> registeredServices;
        private static readonly object TheLock = new Object();

        private static ServiceLocator instance;
        private ServiceLocator()
        {
            registeredServices = new Dictionary<Type, object>();
        }

        public static ServiceLocator Instance
        {
            get
            {
                lock (TheLock)
                {
                    if (instance == null)
                    {
                        instance = new ServiceLocator();
                    }
                    return instance;
                }
            }
        }

        public T GetService<T>()
        {
            try
            {
                return (T)registeredServices[typeof(T)];
            }
            catch (KeyNotFoundException ex)
            {
                throw new ApplicationException("The requested service is not registered.", ex);
            }
        }

        public void RegisterService<T>(T service)
        {
            registeredServices[typeof(T)] = service;
        }

        public Int32 Count
        {
            get { return registeredServices.Count; }
        }
    }
}
