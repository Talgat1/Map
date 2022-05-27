using Map.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Map.Services
{
    public interface IRestService
    {
        Task<Rootobject> GetTodoItemAsync(string item);
    }
}
