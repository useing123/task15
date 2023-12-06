using System;
using System.Collections.Generic;
using System.Reflection;

class MyCustomClass
{
    public int Property1 { get; set; }
    public string Property2 { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Список методов класса Console
        Type consoleType = typeof(Console);
        Console.WriteLine("Список методов класса Console:");
        foreach (var method in consoleType.GetMethods())
        {
            Console.WriteLine(method.Name);
        }
        Console.WriteLine();

        // Работа с классом и рефлексией
        MyCustomClass myObj = new MyCustomClass { Property1 = 100, Property2 = "Hello, World!" };
        Type myObjType = myObj.GetType();
        Console.WriteLine("Работа с классом и рефлексией:");
        foreach (PropertyInfo property in myObjType.GetProperties())
        {
            Console.WriteLine($"Property: {property.Name}, Value: {property.GetValue(myObj)}");
        }
        Console.WriteLine();

        // Вызов метода Substring класса String
        string testString = "Hello, World!";
        Type stringType = typeof(string);
        MethodInfo substringMethod = stringType.GetMethod("Substring", new[] { typeof(int), typeof(int) });
        object result = substringMethod.Invoke(testString, new object[] { 7, 5 });
        Console.WriteLine($"Вызов метода Substring класса String: {result}");
        Console.WriteLine();

        // Список конструкторов класса List<T>
        Type listType = typeof(List<>);
        Console.WriteLine("Constructors of List<T>:");
        foreach (var constructor in listType.GetConstructors())
        {
            Console.WriteLine(constructor);
        }
    }
}