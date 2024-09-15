using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Разработать консольное приложение для учета задач и проектов
//в сфере информационной безопасности. Программа позволяет
//хранить информацию о задачах, связанных с анализом угроз,
//мониторингом безопасности и реагированием на инциденты,
//включая название задачи, описание, статус выполнения,
//ответственного аналитика и срок выполнения. Реализовать
//возможность добавления новых задач, назначения
//ответственных, изменения статусов и отображения задач по
//аналитику

class Task
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string Analyst { get; set; }
    public DateTime Deadline { get; set; }
    public Task(string title, string description, string analyst, DateTime deadline)
    {
        Title = title;
        Description = description;
        Analyst = analyst;
        Status = "Не начата";  // Статус по умолчанию
        Deadline = deadline;
    }

    public void DisplayTask()
    {
        Console.WriteLine($"Название задачи: {Title}");
        Console.WriteLine($"Описание: {Description}");
        Console.WriteLine($"Аналитик: {Analyst}");
        Console.WriteLine($"Статус: {Status}");
        Console.WriteLine($"Срок выполнения: {Deadline.ToShortDateString()}\n");
    }

}

class ProjectManager
{
    private List<Task> tasks = new List<Task>();
    public void AddTask(string title, string description, string analyst, DateTime deadline)
    {
        Task newTask = new Task(title, description, analyst, deadline);
        tasks.Add(newTask);
        Console.WriteLine("Задача добавлена успешно.\n");
    }
    public void UpdateTaskStatus(string title, string newStatus)
    {
        Task task = tasks.FirstOrDefault(t => t.Title == title);
        if (task != null)
        {
            task.Status = newStatus;
            Console.WriteLine($"Статус задачи '{title}' обновлен на '{newStatus}'.\n");
        }
        else
        {
            Console.WriteLine($"Задача с названием '{title}' не найдена.\n");
        }
    }

    public void DisplayTasksByAnalyst(string analyst)
    {
        var tasksByAnalyst = tasks.Where(t => t.Analyst == analyst).ToList();
        if (tasksByAnalyst.Count > 0)
        {
            Console.WriteLine($"Задачи аналитика {analyst}:\n");
            foreach (var task in tasksByAnalyst)
            {
                task.DisplayTask();
            }
        }
        else
        {
            Console.WriteLine($"Задачи для аналитика '{analyst}' не найдены.\n");
        }
    }
    public void DisplayAllTasks()
    {
        if (tasks.Count > 0)
        {
            Console.WriteLine("Все задачи:\n");
            foreach (var task in tasks)
            {
                task.DisplayTask();
            }
        }
        else
        {
            Console.WriteLine("Нет задач для отображения.\n");
        }
    }
}

namespace third_lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProjectManager projectManager = new ProjectManager();

            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Добавить задачу");
                Console.WriteLine("2. Обновить статус задачи");
                Console.WriteLine("3. Показать задачи аналитика");
                Console.WriteLine("4. Показать все задачи");
                Console.WriteLine("5. Выйти");
                Console.Write("\nВыберите действие: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите название задачи: ");
                        string title = Console.ReadLine();
                        Console.Write("Введите описание задачи: ");
                        string description = Console.ReadLine();
                        Console.Write("Введите имя аналитика: ");
                        string analyst = Console.ReadLine();
                        Console.Write("Введите срок выполнения задачи (yyyy-mm-dd): ");
                        DateTime deadline;
                        while (!DateTime.TryParse(Console.ReadLine(), out deadline))
                        {
                            Console.Write("Неверный формат даты. Попробуйте снова: ");
                        }
                        projectManager.AddTask(title, description, analyst, deadline);
                        break;

                    case "2":
                        Console.Write("Введите название задачи для обновления: ");
                        string taskTitle = Console.ReadLine();
                        Console.Write("Введите новый статус задачи: ");
                        string newStatus = Console.ReadLine();
                        projectManager.UpdateTaskStatus(taskTitle, newStatus);
                        break;

                    case "3":
                        Console.Write("Введите имя аналитика: ");
                        string taskAnalyst = Console.ReadLine();
                        projectManager.DisplayTasksByAnalyst(taskAnalyst);
                        break;

                    case "4":
                        projectManager.DisplayAllTasks();
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}
