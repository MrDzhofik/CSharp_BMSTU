using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

// Составить программу деления вещественных чисел. программа должна
//выполнять обработку исключений c использованием конструкции try … catch,
//и выдавать следующие сообщения о характере ошибки:
//1.не введено число(с помощью оператора условия);
//2.введено слишком длинное число (с помощью оператора условия);
//3.деление на ноль;
//4.ошибка преобразования.

namespace eight_lab
{
    internal class Program
    {
            static void Main()
            {
                try
                {
                    Console.Write("Введите первое число: ");
                    string input1 = Console.ReadLine();
                    Console.Write("Введите второе число: ");
                    string input2 = Console.ReadLine();

                    
                    if (string.IsNullOrEmpty(input1) || string.IsNullOrEmpty(input2))
                    {
                        throw new ArgumentException("Не введено число");
                    }

                    if (input1.Length > 16 || input2.Length > 16)
                    {
                        throw new OutOfMemoryException("Введено слишком длинное число");
                    }

                    if (!double.TryParse(input1, out double num1) || !double.TryParse(input2, out double num2))
                    {
                        throw new FormatException("Ошибка преобразования");
                    }

                    if (num2 == 0)
                    {
                        throw new DivideByZeroException("Деление на ноль невозможно");
                    }

                    double result = num1 / num2;
                    Console.WriteLine($"Результат: {num1} / {num2} = {result}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                catch (OutOfMemoryException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла неизвестная ошибка: {ex.Message}");
                }
            }
        }
}
