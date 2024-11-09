using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//1. Создать класс Point - точка на плоскости с вещественными
//координатами x, y. Создать конструктор, ToString() и свойства для
//доступа к координатам точки.
//2. Создайте метод, который генерирует набор (LIst<Point>) случайно
//расположенных точек в квадрате [0,1]x[0,1].
//3. Используя интерфейс IComparer, выведите все точки, упорядочивая их
//следующими способами:
//o по удалению от начала координат (сначала выводится ближайшая
//к началу координат, порядок равноудалённых точек не важен);
//o по удалению от оси абсцисс (сначала выводится ближайшая к оси
//абсцисс, порядок равноудалённых точек не важен);
//o по удалению от оси ординат (сначала выводится ближайшая к оси
//ординат, порядок равноудалённых точек не важен);
//o по удалению от диагонали первой и третьей четвертей
//(прямая y=x, порядок равноудалённых точек не важ1. Создать класс Point - точка на плоскости с вещественными
//координатами x, y. Создать конструктор, ToString() и свойства для
//доступа к координатам точки.
//2. Создайте метод, который генерирует набор (LIst<Point>) случайно
//расположенных точек в квадрате [0,1]x[0,1].
//3. Используя интерфейс IComparer, выведите все точки, упорядочивая их
//следующими способами:
//o по удалению от начала координат (сначала выводится ближайшая
//к началу координат, порядок равноудалённых точек не важен);
//o по удалению от оси абсцисс (сначала выводится ближайшая к оси
//абсцисс, порядок равноудалённых точек не важен);
//o по удалению от оси ординат (сначала выводится ближайшая к оси
//ординат, порядок равноудалённых точек не важен);
//o по удалению от диагонали первой и третьей четвертей
//(прямая y=x, порядок равноудалённых точек не важ

namespace lab11
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"Point({X}, {Y})";
        }

        public double DistanceFromStart()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        public double DistanceFromXAxis()
        {
            return Math.Abs(Y);
        }

        public double DistanceFromYAxis()
        {
            return Math.Abs(X);
        }

        public double DistanceFromDiagonal()
        {
            return Math.Abs(Y - X) / Math.Sqrt(2);
        }
    }


    // Компараторы
    public class DistanceFromOriginComparer : IComparer<Point>
    {
        public int Compare(Point p1, Point p2)
        {
            return p1.DistanceFromStart().CompareTo(p2.DistanceFromStart());
        }
    }

    public class DistanceFromXAxisComparer : IComparer<Point>
    {
        public int Compare(Point p1, Point p2)
        {
            return p1.DistanceFromXAxis().CompareTo(p2.DistanceFromXAxis());
        }
    }

    public class DistanceFromYAxisComparer : IComparer<Point>
    {
        public int Compare(Point p1, Point p2)
        {
            return p1.DistanceFromYAxis().CompareTo(p2.DistanceFromYAxis());
        }
    }

    public class DistanceFromDiagonalComparer : IComparer<Point>
    {
        public int Compare(Point p1, Point p2)
        {
            return p1.DistanceFromDiagonal().CompareTo(p2.DistanceFromDiagonal());
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Введите количество точек: ");
            int numberOfPoints = Convert.ToInt32(Console.ReadLine());

            Random random = new Random();
            List<Point> points = new List<Point>();

            for (int i = 0; i < numberOfPoints; i++)
            {
                double x = Math.Round(random.NextDouble() * 1000) / 1000.0;
                double y = Math.Round(random.NextDouble() * 1000) / 1000.0;
                points.Add(new Point(x, y));
            }

            Console.WriteLine("\nОригинальные точки:");
            points.ForEach(point => Console.WriteLine(point));

            Console.WriteLine("\nСортировка по удалению от начала координат:");
            points.Sort(new DistanceFromOriginComparer());
            points.ForEach(point => Console.WriteLine(point));

            Console.WriteLine("\nСортировка по удалению от оси абсцисс (оси X):");
            points.Sort(new DistanceFromXAxisComparer());
            points.ForEach(point => Console.WriteLine(point));

            Console.WriteLine("\nСортировка по удалению от оси ординат (оси Y):");
            points.Sort(new DistanceFromYAxisComparer());
            points.ForEach(point => Console.WriteLine(point));

            Console.WriteLine("\nСортировка по удалению от диагонали y = x:");
            points.Sort(new DistanceFromDiagonalComparer());
            points.ForEach(point => Console.WriteLine(point));
        }
    }
}
