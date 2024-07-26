using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace TaskManagerApp
{
    public interface ITaskRepository
    {
        void AddTask(Task task);
        void RemoveTask(int id);
        Task GetTask(int id);
        IEnumerable<Task> GetAllTasks();
        void UpdateTask(Task task);
    }
}

