using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Linq;

namespace TaskManagerApp
{
    public class TaskRepository : ITaskRepository
    {
        private readonly List<Task> _tasks = new List<Task>();

        public void AddTask(Task task)
        {
            _tasks.Add(task);
        }

        public void RemoveTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                _tasks.Remove(task);
            }
        }

        public Task GetTask(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return _tasks;
        }

        public void UpdateTask(Task task)
        {
            var existingTask = _tasks.FirstOrDefault(t => t.Id == task.Id);
            if (existingTask != null)
            {
                existingTask.Description = task.Description;
                existingTask.IsCompleted = task.IsCompleted;
            }
        }
    }
}
