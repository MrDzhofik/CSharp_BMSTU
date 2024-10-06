using System;
using System.Reflection;
[AttributeUsage(AttributeTargets.Property)]
public class ImportantAttribute : Attribute
{
    public string Description { get; }
    public ImportantAttribute(string description)
    {
        Description = description;
    }
}
public class FootballPlayer
{

    [ImportantAttribute("Имя футболиста")]
    public string Name { get; set; }

    [ImportantAttribute("Возраст футболиста")]
    public int Age { get; set; }

    public string Position { get; set; } 

    public string Team { get; set; } 

    public int GoalsScored { get; set; } 
    public FootballPlayer() { }

    public FootballPlayer(string name, int age, string position, string team, int goalsScored)
    {
        Name = name;
        Age = age;
        Position = position;
        Team = team;
        GoalsScored = goalsScored;
    }

    public void PrintStats()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}, Position: {Position}, Team: {Team}, Goals Scored: {GoalsScored}");
    }

    public void ScoreGoal()
    {
        GoalsScored++;
        Console.WriteLine($"{Name} забил гол! Теперь у него {GoalsScored} голов.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Type type = typeof(FootballPlayer);

        Console.WriteLine("Конструкторы:");
        foreach (var ctor in type.GetConstructors())
        {
            Console.WriteLine(ctor);
        }

        Console.WriteLine("\nСвойства:");
        foreach (var prop in type.GetProperties())
        {
            Console.WriteLine($"{prop.Name} ({prop.PropertyType})");
        }

        Console.WriteLine("\nМетоды:");
        foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
        {
            Console.WriteLine($"{method.Name}");
        }

        Console.WriteLine("\nСвойства с атрибутом:");
        foreach (var prop in type.GetProperties())
        {
            if (Attribute.IsDefined(prop, typeof(ImportantAttribute)))
            {
                var attribute = (ImportantAttribute)Attribute.GetCustomAttribute(prop, typeof(ImportantAttribute));
                Console.WriteLine($"{prop.Name}: {attribute.Description}");
            }
        }

        var player = Activator.CreateInstance(type, "Lionel Messi", 36, "Forward", "Inter Miami", 800);

        MethodInfo methodInfo = type.GetMethod("PrintStats");
        methodInfo.Invoke(player, null);

        MethodInfo scoreMethod = type.GetMethod("ScoreGoal");
        scoreMethod.Invoke(player, null);
    }
}
