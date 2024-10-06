using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Нужно реализовать библиотечный делегат, который вычисляет среднее арифметическое матрицы.
//Принимает два аргумента: размеры матрицы

namespace sixth_lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            Func<int, int, double> calculateMatrixAverage = CalculateAverage;

            Console.WriteLine("Введите количество строк матрицы:");
            int rows = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество столбцов матрицы:");
            int columns = int.Parse(Console.ReadLine());

            double average = calculateMatrixAverage(rows, columns);

            Console.WriteLine($"Среднее арифметическое элементов матрицы: {average:F2}");
        }

        static double CalculateAverage(int rows, int columns)
        {
            Random random = new Random();
            int[,] matrix = new int[rows, columns];
            double sum = 0;
            int totalElements = rows * columns;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = random.Next(1, 1001);
                    sum += matrix[i, j];
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            return sum / totalElements;
        }
    }
}
