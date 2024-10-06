using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Создать консольное приложение, которое принимает от
// пользователя дату в формате "год-месяц-день" и определяет,
// является ли она валидной датой

namespace first_lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите год-месяц-число: ");
            string ymd = Console.ReadLine();
            string[] tmp = ymd.Split('-');
            int year = Convert.ToInt32(tmp[0]);
            int month = Convert.ToInt32(tmp[1]);
            int day = Convert.ToInt32(tmp[2]);
            string ans = "Неправильная";

            if ((month > 0 && month <= 12) && (day > 0))
            {
                // Если високосный год, то в феврале 29 дней, если нет - то 28
                if (month == 2 && (day <= 28 || (year % 4 == 0 && day <= 29))) 
                {
                    ans = "Правильная";
                }
                // Август, октябрь, декабрь имеют по 31 день
                else if ((month < 8 && month % 2 == 1) && (day <= 31)) {
                    ans = "Правильная";
                }
                // Январь, март, май, июль имеют по 31 день
                else if ((month > 7 && month % 2 == 1) && (day <= 31))
                {
                    ans = "Правильная";
                }
                else if (day <= 28)
                {
                    ans = "Правильная";
                }
            }
            Console.WriteLine($"{ans} дата");
            Console.ReadLine();
        }
    }
}
