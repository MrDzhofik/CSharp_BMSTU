using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;


//Напишите функцию, которая определяет, сколько раз заданное
//слово встречается в текстовом файле F.

namespace fiveth_lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите искомое слово: ");
            string word = Console.ReadLine();

            Console.WriteLine();

            string path = @"C:\Users\MrDzhofik\semester_7\С_sharp\fiveth_lab\fiveth_lab\F.txt";
            FileInfo fileInfo = new FileInfo(path);

            if (fileInfo.Exists)
            {
                Console.WriteLine($"Имя файла: {fileInfo.Name}");
                Console.WriteLine($"Время создания: {fileInfo.CreationTime}");
                Console.WriteLine($"Размер: {fileInfo.Length}");
            }
                        
            string fileText = File.ReadAllText(path);
            string[] words = fileText.Split(' ');
            int count = 0;

            Console.WriteLine();

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == word) { count++; }
            }

            Console.WriteLine($"Количество слов {word} в файле F равно {count}");
        }
    }
}
