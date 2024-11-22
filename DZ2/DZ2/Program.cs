using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Collections.Generic;

class SimpleHttpServer
{
    private TcpListener _listener;
    private readonly string _htmlFilePath;
    private bool _isRunning;

    public SimpleHttpServer(string ip, int port, string htmlFilePath)
    {
        _listener = new TcpListener(IPAddress.Parse(ip), port);
        _htmlFilePath = htmlFilePath;
    }

    public void Start()
    {
        _listener.Start();
        _isRunning = true;
        Console.WriteLine("HTTP сервер запущен. Ожидание подключений...");

        while (_isRunning)
        {
            try
            {
                TcpClient client = _listener.AcceptTcpClient();
                ThreadPool.QueueUserWorkItem(HandleClient, client);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }

    private void HandleClient(object clientObj)
    {
        var client = (TcpClient)clientObj;

        try
        {
            using (var stream = client.GetStream())
            {
                byte[] buffer = new byte[4096];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Получен запрос:\n" + request);

                string[] requestLines = request.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                string requestLine = requestLines[0];
                string[] requestParts = requestLine.Split(' ');
                string method = requestParts[0];
                string url = requestParts[1];

                if (method == "GET")
                {
                    if (File.Exists(_htmlFilePath))
                    {
                        string htmlContent = File.ReadAllText(_htmlFilePath);
                        SendResponse(stream, htmlContent, "text/html");
                    }
                    else
                    {
                        SendErrorResponse(stream, HttpStatusCode.NotFound, "HTML-файл не найден");
                    }
                }
                else if (method == "POST")
                {
                    string body = request.Split(new[] { "\r\n\r\n" }, StringSplitOptions.None)[1];
                    var jsonData = JsonSerializer.Deserialize<RequestData>(body);

                    
                    double result;
                    try
                    {
                        result = EvaluateExpression(jsonData.Expression);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка вычисления: {ex.Message}");
                        SendErrorResponse(stream, HttpStatusCode.BadRequest, "Ошибка в выражении");
                        return;
                    }

                    var responseData = new { result };
                    string jsonResponse = JsonSerializer.Serialize(responseData);
                    SendResponse(stream, jsonResponse, "application/json");
                }
                else
                {
                    SendErrorResponse(stream, HttpStatusCode.NotFound, "Ресурс не найден");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка обработки клиента: {ex.Message}");
        }
        finally
        {
            client.Close();
        }
    }

    private double EvaluateExpression(string expression)
    {
        return EvaluateRPN(expression); ;
    }


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


    private void SendResponse(NetworkStream stream, string content, string contentType)
    {
        string response = $"HTTP/1.1 200 OK\r\n" +
                          $"Content-Type: {contentType}; charset=utf-8\r\n" +
                          $"Content-Length: {content.Length}\r\n" +
                          "\r\n" +
                          content;

        byte[] responseBytes = Encoding.UTF8.GetBytes(response);
        stream.Write(responseBytes, 0, responseBytes.Length);
    }

    private void SendErrorResponse(NetworkStream stream, HttpStatusCode statusCode, string message)
    {
        string response = $"HTTP/1.1 {(int)statusCode} {statusCode}\r\n" +
                          "Content-Type: text/plain; charset=utf-8\r\n" +
                          "Content-Length: " + message.Length + "\r\n" +
                          "\r\n" +
                          message;

        byte[] responseBytes = Encoding.UTF8.GetBytes(response);
        stream.Write(responseBytes, 0, responseBytes.Length);
    }

    public void Stop()
    {
        _isRunning = false;
        _listener.Stop();
        Console.WriteLine("Сервер остановлен.");
    }

    ~SimpleHttpServer()
    {
        Stop();
    }
}

class RequestData
{
    [JsonPropertyName("expression")]
    public string Expression { get; set; }
}

class Program
{
    static void Main()
    {
        string ip = "127.0.0.1";
        int port = 49208;
        string htmlFilePath = @"C:\Users\MrDzhofik\semester_7\С_sharp\DZ2\DZ2\index.html";

        var server = new SimpleHttpServer(ip, port, htmlFilePath);

        try
        {
            server.Start();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при запуске сервера: {ex.Message}");
        }
    }
}
