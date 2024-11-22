using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

//Разработать на языке C# консольное приложение "калькулятор",
//позволяющее вычислять арифметическое выражение,
//вводимое пользователем в консоль в виде строк(подаваемое на
//стандартный поток ввода STDIN).
//Для этого требуется реализовать: сложение, вычитание, умножение,
//деление и поддержку скобок. Написать тесты, которые покрывают все операции
//Метод Бауера-Замельзона

namespace DZ1
{

    class Calculator
    {
        private const string START = "S";

        // Проверка, является ли строка числом
        static bool IsNumeric(string s)
        {
            return double.TryParse(s, out _);
        }

        // Проверка, содержится ли оператор в списке операторов
        static bool ContainsOperator(string[] operators, string target)
        {
            foreach (var op in operators)
            {
                if (op == target)
                {
                    return true;
                }
            }
            return false;
        }

        // Выполнение арифметической операции
        static double Execute(Stack<double> stack, string token)
        {
            if (stack.Count < 2)
            {
                throw new InvalidOperationException("Недостаточно чисел для совершения операции.");
            }

            var operand2 = stack.Pop();
            var operand1 = stack.Pop();
            double result;
            switch (token)
            {
                case "+":
                    result = operand1 + operand2;
                    break;
                case "-":
                    result = operand1 - operand2;
                    break;
                case "*":
                    result = operand1 * operand2;
                    break;
                case "/":
                    if (operand2 == 0)
                    {
                        throw new DivideByZeroException("Деление на ноль.");
                    }
                    result = operand1 / operand2;
                    break;
                default:
                    throw new InvalidOperationException("Неверный оператор.");
            }

            return result;
        }

        // Добавление символа в стек операций
        static void DoOne(Stack<string> tokens, string token)
        {
            tokens.Push(token);
        }

        // Генерация команды и задание символа в стек операций
        static void DoTwo(Stack<double> stack, Stack<string> tokens, string token)
        {
            var previousToken = tokens.Pop();
            var result = Execute(stack, previousToken);
            stack.Push(result);
            tokens.Push(token);
        }

        // Удаление верхнего символа из стека операций
        static void DoThree(Stack<string> tokens)
        {
            tokens.Pop();
        }

        // Генерация команды и повторение с тем же входным символом
        static void DoFour(Stack<double> stack, Stack<string> tokens, string token)
        {
            var previousToken = tokens.Pop();
            var result = Execute(stack, previousToken);
            stack.Push(result);
        }

        // Основной метод для вычисления выражения в ОПН
        public static double EvaluateRPN(string expression)
        {
            var operators = new[] { "S", "+", "-", "*", "/", "(", ")", "E" };

            var operationsTable = new Dictionary<string, int[]>
        {
            { "S", new[] { 1, 1, 1, 1, 1, 5, 0 } },
            { "+", new[] { 2, 2, 1, 1, 1, 4, 4 } },
            { "-", new[] { 2, 2, 1, 1, 1, 4, 4 } },
            { "*", new[] { 4, 4, 2, 2, 1, 4, 4 } },
            { "/", new[] { 4, 4, 2, 2, 1, 4, 4 } },
            { "(", new[] { 1, 1, 1, 1, 1, 3, 5 } },
        };

            var stack = new Stack<double>();   // Стек для чисел
            var tokens = new Stack<string>();  // Стек для операторов
            tokens.Push(START);

            string numStr = string.Empty;

            foreach (var charToken in expression)
            {
                string token = charToken.ToString();

                // Если это число, считываем его до конца
                if (IsNumeric(token))
                {
                    numStr += token;
                }
                else if (ContainsOperator(operators, token))
                {
                    if (!string.IsNullOrEmpty(numStr))
                    {
                        stack.Push(double.Parse(numStr));
                        numStr = string.Empty;
                    }

                    while (tokens.Count > 0)
                    {
                        var previousToken = tokens.Peek();
                        int action = operationsTable[previousToken][OperationsIndex(token)];

                        if (action == 1)
                        {
                            DoOne(tokens, token);
                            break;
                        }
                        else if (action == 2)
                        {
                            DoTwo(stack, tokens, token);
                            break;
                        }
                        else if (action == 3)
                        {
                            DoThree(tokens);
                            break;
                        }
                        else if (action == 4)
                        {
                            DoFour(stack, tokens, token);
                        }
                        else
                        {
                            throw new InvalidOperationException("Ошибка в выражении.");
                        }
                    }
                }
                else
                {
                    throw new InvalidOperationException($"Неверный символ: {charToken}");
                }
            }

            // Обработка остаточных чисел
            if (!string.IsNullOrEmpty(numStr))
            {
                stack.Push(double.Parse(numStr));
            }

            while (stack.Count > 1 && tokens.Peek() != START)
            {
                DoFour(stack, tokens, tokens.Peek());
            }

            return stack.Pop();
        }

        // Индекс оператора для таблицы приоритетов
        static int OperationsIndex(string token)
        {
            var operators = new[] { "+", "-", "*", "/", "(", ")", "E" };
            for (int i = 0; i < operators.Length; i++)
            {
                if (operators[i] == token)
                {
                    return i;
                }
            }
            return -1;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Ввести выражение");
            Console.WriteLine("2. Запустить тесты");
            int select = int.Parse(Console.ReadLine());
            double result = 0;

            switch (select % 2)
            {
                case 1:
                    Console.WriteLine("Введите выражение:");
                    string expression = Console.ReadLine();

                    try
                    {
                        result = EvaluateRPN(expression);
                        Console.WriteLine($"Результат: {result}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                    break;
                case 0:
                    string[] input = { "1+2", "(4*3)+30/(12-7)", "((2+1)*3-1)/4" };
                    double[] outputs = { 3, 18, 2 };
                    result = 0;

                    for (int i = 0; i < 3; ++i)
                    {
                        result = EvaluateRPN(input[i]);
                        if (result == outputs[i])
                        {
                            Console.WriteLine($"Выражение: {input[i]}\n Результат: {result}\n   Ожидаемый результат: {outputs[i]}\n    Тест {i+1} пройден\n");
                        } else
                        {
                            Console.WriteLine($"Выражение: {input[i]}\n Результат: {result}\n  Тест {i + 1} не пройден\n");
                        }
                    }
                    break;
            }

            
        }
    }
}
