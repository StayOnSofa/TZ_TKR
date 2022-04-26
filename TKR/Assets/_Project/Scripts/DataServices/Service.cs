namespace _Project.DataServices
{
    public abstract class Service
    {
        private DataService _dataService;
        
        public void Init(DataService dataService)
        {
            _dataService = dataService;
        }

        public T GetService<T>() where T : Service
        {
            return _dataService.GetService<T>();
        }
    }
}
