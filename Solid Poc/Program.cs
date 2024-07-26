using System;

namespace TaskManagerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var taskRepository = new TaskRepository();
            var taskService = new TaskService(taskRepository);
            var consoleUI = new ConsoleUI(taskService);

            consoleUI.Run();
        }
    }
}

