using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace TaskManagerApp
{
    public class ConsoleUI
    {
        private readonly ITaskService _taskService;

        public ConsoleUI(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Task Manager");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. List Tasks");
                Console.WriteLine("3. Mark Task as Completed");
                Console.WriteLine("4. Delete Task");
                Console.WriteLine("5. Exit");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        ListTasks();
                        break;
                    case "3":
                        MarkTaskAsCompleted();
                        break;
                    case "4":
                        DeleteTask();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        private void AddTask()
        {
            Console.Write("Enter task description: ");
            var description = Console.ReadLine();
            _taskService.CreateTask(description);
            Console.WriteLine("Task added.");
        }

        private void ListTasks()
        {
            var tasks = _taskService.GetTasks();
            foreach (var task in tasks)
            {
                Console.WriteLine($"Id: {task.Id}, Description: {task.Description}, Completed: {task.IsCompleted}");
            }
        }

        private void MarkTaskAsCompleted()
        {
            Console.Write("Enter task ID to mark as completed: ");
            if (int.TryParse(Console.ReadLine(), out var id))
            {
                _taskService.MarkTaskAsCompleted(id);
                Console.WriteLine("Task marked as completed.");
            }
            else
            {
                Console.WriteLine("Invalid ID. Try again.");
            }
        }

        private void DeleteTask()
        {
            Console.Write("Enter task ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out var id))
            {
                _taskService.DeleteTask(id);
                Console.WriteLine("Task deleted.");
            }
            else
            {
                Console.WriteLine("Invalid ID. Try again.");
            }
        }
    }
}

