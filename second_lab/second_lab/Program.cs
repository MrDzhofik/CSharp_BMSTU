using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Дана целочисленная квадратная матрица размером n*m.
//Написать программу, позволяющую исключать из нее столбец,
//в котором расположен минимальный элемент главной
//диагонали.

namespace second_lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размер матрицы: ");
            int size = Convert.ToInt32(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"Введите элемент [{i}, {j}]: ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            int idxMin = 0;
            int min = 100000;

            for (int i = 0; i < size; ++i)
            {
                if (matrix[i, i] < min)
                {
                    min = matrix[i, i];
                    idxMin = i;
                }
            }

            Console.WriteLine("Исходная матрица:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Матрица без одного стобца:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (j != idxMin)
                    {
                        Console.Write(matrix[i, j] + "\t");
                    }
                }
                Console.WriteLine();
            }
        }

    }
}
