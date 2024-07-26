using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TaskManagerApp
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private int _nextId = 1;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void CreateTask(string description)
        {
            var task = new Task
            {
                Id = _nextId++,
                Description = description,
                IsCompleted = false
            };
            _taskRepository.AddTask(task);
        }

        public void DeleteTask(int id)
        {
            _taskRepository.RemoveTask(id);
        }

        public Task GetTask(int id)
        {
            return _taskRepository.GetTask(id);
        }

        public IEnumerable<Task> GetTasks()
        {
            return _taskRepository.GetAllTasks();
        }

        public void MarkTaskAsCompleted(int id)
        {
            var task = _taskRepository.GetTask(id);
            if (task != null)
            {
                task.IsCompleted = true;
                _taskRepository.UpdateTask(task);
            }
        }
    }
}

