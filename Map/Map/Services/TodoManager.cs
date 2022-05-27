using System;
using System.Collections.Generic;
using System.Text;
using Map.Model;
using System.Threading.Tasks;

namespace Map.Services
{
    public class TodoManager
    {
        IRestService service;

        public TodoManager(IRestService restService)
        {
            service = restService;
        }
        public Task<Rootobject> GetTodoItemModels(string item)
        {
            return service.GetTodoItemAsync(item);
        }
    }
}
