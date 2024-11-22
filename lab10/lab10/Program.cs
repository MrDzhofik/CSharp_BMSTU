using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Дан текстовый файл, содержащий данные о продуктах на складе и их
//описания, например:
//1.Определите класс с тремя закрытыми полями:
//o Количество в кг (вещественное число);
//o Исходное представление количества (строка);
//o Название(строка).
//2.Реализуйте конструктор, принимающий на вход два
//строковых значения: количество и название товара. Конструктор должен
//генерировать исключение, если количество является некорректным (меньше
//нуля). Добавьте свойства для преобразования количества в кг. В основной
//программе загрузите все температурные данные из исходного файла в
//список List< > .
//3. Попытайтесь вызвать метод Sort для загруженного ранее списка
//температур. Возникающее при этом исключение свидетельствует о
//невозможности выполнять сравнение объектов произвольного класса.
//Чтобы это стало возможным, необходимо, например, реализовать в
//классе интерфейс IComparable<T> . Для этого:
//o измените заголовок класса на следующий
//class ‘Название’: IComparable <’Название’>
//o Необходимости реализовать метод сравнения. Метод сравнения
//должен возвращать отрицательное число, если объект, для
//которого вызывается метод, меньше объекта, переданного в
//качестве параметра, — если оба объекта равны, и
//положительное число — если исходный объект больше —
//реализуйте этот метод;
//4.Убедитесь, что метод Sort работает и сортирует список

namespace lab10
{
    class Product : IComparable<Product>
    {
        private double quantityKg;
        private string quantityString;
        private string name;

        public Product(string quantity, string name)
        {
            this.name = name;
            this.quantityString = quantity;

            ParseQuantity(quantity);
        }

        public double QuantityKg => quantityKg;
        public string QuantityString => quantityString;
        public string Name => name;

        private void ParseQuantity(string quantity)
        {
            if (string.IsNullOrWhiteSpace(quantity))
                throw new ArgumentException("Количество не может быть пустым.");

            string unit = string.Empty;
            string valuePart = string.Empty;

            if (quantity.EndsWith("кг"))
            {
                unit = "кг";
                valuePart = quantity.Substring(0, quantity.Length - 2);
            }
            else
            {
                unit = quantity.Substring(quantity.Length - 1);
                valuePart = quantity.Substring(0, quantity.Length - 1);
            }
            

            if (double.TryParse(valuePart, out double value))
            {
                if (value < 0)
                    throw new ArgumentException("Количество не может быть меньше нуля.");

                switch (unit)
                {
                    case "кг":  // килограмм
                    case "л":  // литр
                        quantityKg = value;
                        break;
                    case "г":  // грамм
                        quantityKg = value * 0.001;
                        break;
                    case "т":  // тонна
                        quantityKg = value * 1000;
                        break;
                    default:
                        throw new ArgumentException($"Неизвестная единица измерения: {unit}");
                }
            }
            else
            {
                throw new ArgumentException("Некорректное значение для количества.");
            }
        }

        public int CompareTo(Product other)
        {
            if (other == null) return 1;
            return this.quantityKg.CompareTo(other.quantityKg);
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                string filePath = @"C:\Users\MrDzhofik\semester_7\С_sharp\lab10\products.txt";
                List<Product> products = new List<Product>();

                Console.WriteLine("Данные из файла: ");
                foreach (var line in File.ReadLines(filePath))
                {
                    Console.WriteLine(line);
                    var parts = line.Split(' ');
                    if (parts.Length == 2)
                    {
                        string quantity = parts[0];
                        string name = parts[1];

                        try
                        {
                            var product = new Product(quantity, name);
                            products.Add(product);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Ошибка в данных: {ex.Message}");
                        }
                    }
                }

                products.Sort();

                Console.WriteLine();
                Console.WriteLine("Остортированный список: ");

                foreach (var product in products)
                {
                    Console.WriteLine($"{product.QuantityKg}кг {product.Name}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine("\nПродаю людей, бананы... Шучу, не бананы");
        }
    }
}
