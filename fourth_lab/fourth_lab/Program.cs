//–азработать консольное приложение дл€ учета задач и проектов
//в сфере информационной безопасности. ѕрограмма позвол€ет
//хранить информацию о задачах, св€занных с анализом угроз,
//мониторингом безопасности и реагированием на инциденты,
//включа€ название задачи, описание, статус выполнени€,
//ответственного аналитика и срок выполнени€. –еализовать
//возможность добавлени€ новых задач, назначени€
//ответственных, изменени€ статусов и отображени€ задач по
//аналитику



namespace fourth_lab
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            ProjectManager projectManager = new ProjectManager();
            Application.Run(new Form1());
        }
    }
}