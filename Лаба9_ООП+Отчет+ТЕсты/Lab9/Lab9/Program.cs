
using System;

public class Program
{
    // Поиск треугольника с минимальной площадью
    public static Triangle FindMinArea(TriangleArray triangles)
    {
        if (triangles.Length == 0)
            throw new ArgumentException("Массив пуст");

        Triangle minTriangle = triangles[0];

        for (int i = 1; i < triangles.Length; i++)
        {
            if (triangles[i].GetArea() < minTriangle.GetArea())
            {
                minTriangle = triangles[i];
            }
        }
        return minTriangle;
    }
    public static void Main()
    {
        UserInterface ui = new UserInterface();

        Console.WriteLine("ЧАСТЬ 1. СОЗДАНИЕ ТРЕУГОЛЬНИКОВ");

        Triangle first = new Triangle(3, 4, 5);
        Triangle second = new Triangle(5, 6, 7);

        first.Print();
        Console.WriteLine();

        second.Print();

        Console.WriteLine();
        Console.WriteLine("Статическая проверка:");

        bool result = Triangle.IsValid(3, 4, 5);
        Console.WriteLine($"Треугольник существует: {result}");

        Console.WriteLine();
        Console.WriteLine("ЧАСТЬ 2. ПЕРЕГРУЗКА ОПЕРАЦИЙ");

        double area = -first;
        double perimeter = first;
        bool isValid = (bool)first;

        Console.WriteLine($"Площадь первого: {area}");
        Console.WriteLine($"Периметр первого: {perimeter}");
        Console.WriteLine($"Существует: {isValid}");

        Console.WriteLine($"Первый меньше второго: {first < second}");
        Console.WriteLine($"Первый больше второго: {first > second}");

        Console.WriteLine();
        Console.WriteLine("ЧАСТЬ 3. МАССИВ ТРЕУГОЛЬНИКОВ");

        TriangleArray emptyArray = new TriangleArray();

        TriangleArray randomArray = new TriangleArray(5);

        Console.WriteLine("Случайный массив:");
        randomArray.Print();

        int size = ui.ReadSize();

        TriangleArray userArray = new TriangleArray(size, ui);

        Console.WriteLine();
        Console.WriteLine("Введённый массив:");
        userArray.Print();
        // Поиск треугольника с минимальной площадью
        if (userArray.Length > 0)
        {
            Triangle minTriangle = FindMinArea(userArray);

            Console.WriteLine("Треугольник с минимальной площадью:");
            minTriangle.Print();
        }
        else
        {
            Console.WriteLine("Массив пуст.");
        }
        // Подсчёт созданных объектов
        Console.WriteLine();
        Console.WriteLine($"Создано объектов Triangle: {Triangle.ObjectCount}");
        Console.WriteLine($"Создано объектов TriangleArray: {TriangleArray.ObjectCount}");
    }
}