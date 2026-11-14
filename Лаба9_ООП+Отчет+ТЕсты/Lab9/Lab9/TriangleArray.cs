using System;
public class TriangleArray
{
    private Triangle[] triangles;

    private static int objectCount = 0;

    public static int ObjectCount => objectCount;

    
    public TriangleArray() // Конструктор без параметров
    {
        triangles = new Triangle[0];
        objectCount++;
    }
    public TriangleArray(int size) // Конструктор со случайным заполнением
    {
        if (size < 0)
            throw new ArgumentException("Размер массива не может быть отрицательным");
        triangles = new Triangle[size];
        Random random = new Random();
        for (int i = 0; i < size; i++)
        {
            double a = random.Next(2, 11);
            double b = random.Next(2, 11);
            double minC = Math.Abs(a - b) + 1;
            double maxC = a + b;
            double c = random.Next((int)minC, (int)maxC);
            triangles[i] = new Triangle(a, b, c);
        }
        objectCount++;
    }


    public TriangleArray(int size, UserInterface ui)// Конструктор с заполнением с клавиатуры
    {
        if (size < 0)
            throw new ArgumentException("Размер массива не может быть отрицательным");
        triangles = new Triangle[size];
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"Треугольник №{i + 1}");
            triangles[i] = ui.ReadTriangle();
        }
        objectCount++;
    }
    public Triangle this[int index]
    {
        get
        {
            if (index < 0 || index >= triangles.Length)
                throw new ArgumentException("Неверный индекс массива");

            return triangles[index];
        }

        set
        {
            if (index < 0 || index >= triangles.Length)
                throw new ArgumentException("Неверный индекс массива");

            triangles[index] = value;
        }
    }
    public int Length => triangles.Length;// Количество элементов    
    public void Print()// Вывод массива
    {
        for (int i = 0; i < triangles.Length; i++)
        {
            Console.WriteLine($"Треугольник №{i + 1}");
            triangles[i].Print();
            Console.WriteLine();
        }
    }
}