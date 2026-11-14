using System;
public class UserInterface
{
    public Triangle ReadTriangle()
    {
        Console.Write("Введите сторону A: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите сторону B: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите сторону C: ");
        double c = Convert.ToDouble(Console.ReadLine());

        return new Triangle(a, b, c);
    }
    public int ReadSize()
    {
        Console.Write("Введите количество треугольников: ");
        return Convert.ToInt32(Console.ReadLine());
    }
    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }
}
