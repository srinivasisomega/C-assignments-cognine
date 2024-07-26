using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace TaskManagerApp
{
    public interface ITaskService
    {
        void CreateTask(string description);
        void DeleteTask(int id);
        Task GetTask(int id);
        IEnumerable<Task> GetTasks();
        void MarkTaskAsCompleted(int id);
    }
}
