using System;
using System.Collections.Generic;
using _Project.Mono;

namespace _Project.DataServices
{
    public class DataService : MonoSingleton<DataService>
    {
        private List<Service> _services = new List<Service>();
        
        public T GetService<T>() where T : Service
        {
            foreach (var service in _services)
            {
                if (service is T)
                {
                    return service as T;
                }
            }

            T newService = (T)Activator.CreateInstance(typeof(T), new object[] {});
            
            newService.Init(this);
            
            _services.Add(newService);
            
            return newService;
        }
    }
}