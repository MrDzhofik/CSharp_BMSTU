using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

//Требуется разработать программу, ведущую учёт заказов в магазине.
//Классы:
//-(Покупатель)с тремя атрибутами: имя(string), адрес(string), скидка(double)
//- (Товар).Поля, соответствующие названию(string) и цене(decimal)
//-(База данных товаров), хранящий ассоциативный массив («словарь») с информацией о
//товарах
//- OrderLine с полями количество (int) и продукт (Product)
//- Order с полями номер заказа (int), клиент (Customer), скидка (decimal), общая стоимость
//(decimal) и строки заказа (List<OrderLIne>).
//Реализовать следующую логику основной программы:
//1.Создаётся и заполняется база данных товаров (ассоциативный массив).
//2. В консоли вводятся данные по конкретному покупателю, создаётся
//соответствующий объект.
//3. Создаётся заказ для введённого ранее покупателя. Устанавливается
//скидка на заказ в соответствии со скидкой покупателя.
//4. В цикле формируются необходимое количество строк заказа: вводятся
//коды товаров и количества их единиц.
//5. Полная информация о заказе сохраняется в файле с заданным именем.
//Создать методы, которые осуществляют сериализацию/десериализацию
//объекта типа База данных товаров. Формат выбрать самостоятельно.

namespace lab9
{

    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Discount { get; set; }
    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class ProductDatabase
    {
        public Dictionary<string, Product> Products { get; set; } = new Dictionary<string, Product>();

        public void AddProduct(string code, Product product)
        {
            Products[code] = product;
        }

        public Product GetProduct(string code)
        {
            return Products.ContainsKey(code) ? Products[code] : null;
        }

        public void DisplayAll()
        {
            foreach (var product in Products)
            {
                Console.Write(product.Key);
                Console.Write(" ");
                Console.Write(product.Value.Name);
                Console.Write(" ");
                Console.WriteLine(product.Value.Price);
            }
        }

        // Сериализация базы данных товаров
        public void SaveToFile(string fileName)
        {
            var json = JsonConvert.SerializeObject(this);
            File.WriteAllText(fileName, json);
        }

        // Десериализация базы данных товаров
        public static ProductDatabase LoadFromFile(string fileName)
        {
            var json = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<ProductDatabase>(json);
        }
    }

    public class OrderLine
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public decimal TotalPrice => Product.Price * Quantity;
    }

    public class Order
    {
        public int OrderNumber { get; set; }
        public Customer Customer { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalCost { get; set; }
        public List<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

        public void AddOrderLine(OrderLine orderLine)
        {
            OrderLines.Add(orderLine);
            TotalCost += orderLine.TotalPrice;
        }

        public void ApplyDiscount()
        {
            TotalCost -= TotalCost * (decimal)(Customer.Discount / 100);
        }

        public void SaveOrderToFile(string fileName)
        {
            var json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var productDb = new ProductDatabase();
            productDb.AddProduct("001", new Product { Name = "Мандарины", Price = 50.00m });
            productDb.AddProduct("002", new Product { Name = "Фейхоа", Price = 80.00m });
            productDb.AddProduct("003", new Product { Name = "Хурма", Price = 75.00m });

            string rootDirectory = "C:\\Users\\MrDzhofik\\semester_7\\С_sharp\\lab9\\";

            productDb.SaveToFile(rootDirectory + "products.json");

            Console.Write("Введите имя покупателя: ");
            string customerName = Console.ReadLine();
            Console.Write("Введите адрес покупателя: ");
            string customerAddress = Console.ReadLine();
            Console.Write("Введите скидку покупателя (в процентах): ");
            double discount = double.Parse(Console.ReadLine());

            var customer = new Customer { Name = customerName, Address = customerAddress, Discount = discount };

            var order = new Order { OrderNumber = 1, Customer = customer, Discount = (decimal)discount };

            string input;
            do
            {
                productDb.DisplayAll();

                Console.Write("\nВведите код товара (или Enter для завершения): ");
                input = Console.ReadLine();
                if (input.ToLower() == "") break;

                var product = productDb.GetProduct(input);
                if (product == null)
                {
                    Console.WriteLine("Товар не найден.");
                    continue;
                }

                Console.Write("Введите количество: ");
                int quantity = int.Parse(Console.ReadLine());

                var orderLine = new OrderLine { Product = product, Quantity = quantity };
                order.AddOrderLine(orderLine);

            } while (true);

            order.ApplyDiscount();

            order.SaveOrderToFile(rootDirectory + "order.json");

            Console.WriteLine("Заказ сохранён.");
        }
    }
}
