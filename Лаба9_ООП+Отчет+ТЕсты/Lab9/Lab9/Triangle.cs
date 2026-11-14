
using System;

public class Triangle
{
    private double a;
    private double b;
    private double c;
    private static int objectCount = 0;

    public double A
    {
        get { return a; }
        set { a = value; }
    }

    public double B
    {
        get { return b; }
        set { b = value; }
    }

    public double C
    {
        get { return c; }
        set { c = value; }
    }

    // Количество созданных объектов
    public static int ObjectCount => objectCount;

    // Конструктор без параметров
    public Triangle()
    {
        A = 1;
        B = 1;
        C = 1;
        objectCount++;
    }

    // Конструктор с параметрами
    public Triangle(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
        objectCount++;
    }
    public bool IsValid() // Проверка существования треугольника
    {
        return a > 0 && b > 0 && c > 0
            && a + b > c
            && a + c > b
            && b + c > a;
    }
    public static bool IsValid(double a, double b, double c)
    {
        return a > 0 && b > 0 && c > 0
            && a + b > c
            && a + c > b
            && b + c > a;
    }
    public double GetPerimeter()
    {
        return a + b + c;
    }  
    public double GetArea() // Вычисление площади по формуле Герона
    {
        if (!IsValid())
            return -1;

        double p = GetPerimeter() / 2;

        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }
    public void Print()
    {
        Console.WriteLine($"Стороны: {a}, {b}, {c}");
        Console.WriteLine($"Существует: {IsValid()}");
        Console.WriteLine($"Периметр: {GetPerimeter()}");
        Console.WriteLine($"Площадь: {GetArea()}");
    }
    public static double operator -(Triangle triangle)
    {
        return triangle.GetArea();
    }
    public static implicit operator double(Triangle triangle)
    {
        return triangle.GetPerimeter();
    }
    public static explicit operator bool(Triangle triangle)
    {
        return triangle.IsValid();
    }
    public static bool operator <(Triangle first, Triangle second)
    {
        return first.GetArea() < second.GetArea();
    }
    public static bool operator >(Triangle first, Triangle second)
    {
        return first.GetArea() > second.GetArea();
    }

}
