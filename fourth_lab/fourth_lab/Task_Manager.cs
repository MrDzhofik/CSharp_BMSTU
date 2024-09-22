using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fourth_lab
{
    class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Analyst { get; set; }
        public string Deadline { get; set; }
        public Task(string title, string description, string analyst, string deadline)
        {
            Title = title;
            Description = description;
            Analyst = analyst;
            Status = "Не начата";  // Статус по умолчанию
            Deadline = deadline;
        }

        public string DisplayTask()
        {
           return $"Название задачи: {Title}\n" +
           $"Описание: {Description}\n" +
           $"Аналитик: {Analyst}\n" +
           $"Статус: {Status}\n" +
           $"Срок выполнения: {Deadline}\n";
        }

    }

    public class ProjectManager
    {
        private List<Task> tasks = new List<Task>();
        public void AddTask(string title, string description, string analyst, string deadline)
        {
            Task newTask = new Task(title, description, analyst, deadline);
            tasks.Add(newTask);
        }
        public void UpdateTaskStatus(string title, string newStatus)
        {
            Task task = tasks.FirstOrDefault(t => t.Title == title);
            if (task != null)
            {
                task.Status = newStatus;
            }
        }

        public string DisplayTasksByAnalyst(string analyst)
        {
            var tasksByAnalyst = tasks.Where(t => t.Analyst == analyst).ToList();
            string result = "";
            if (tasksByAnalyst.Count > 0)
            {
                foreach (var task in tasksByAnalyst)
                {
                    result += task.DisplayTask();
                    result += "--------------------\n";
                }
            }
            return result;
        }
        public string DisplayAllTasks()
        {
            string result = "";
            if (tasks.Count > 0)
            {
                foreach (var task in tasks)
                {
                    result += task.DisplayTask();
                    result += "--------------------\n";
                }
            }
            return result;
        }
    }
}
