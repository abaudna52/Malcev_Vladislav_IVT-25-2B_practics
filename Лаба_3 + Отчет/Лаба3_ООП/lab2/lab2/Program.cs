
using System;

public class Laba3
{

    public static double GetValue(double x) //Значение Y
    {
        return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
    }

    public static double GetSumN(double x, int n) //Значение суммы для заданого n
    {
        var sum = 1.0;
        var factorial = 1.0;

        for (var i = 1; i <= n; i++)
        {
            factorial *= i;
            sum += Math.Cos(i * x) / factorial;
        }

        return sum;
    }

    public static double GetSumEps(double x, double e) //Значение суммы с точностью
    {
        var sum = 1.0;
        var factorial = 1.0;
        var i = 0;

        while (true)
        {
            i++;
            factorial *= i;

            var term = Math.Cos(i * x) / factorial;

            if (Math.Abs(term) < e)
            {
                break;
            }

            sum += term;
        }

        return sum;
    }
    public static void Main()
    {
        var X1 = 0.1; 
        var X2 = 1.0;
        var points = 10;
        var n = 20;
        var e = 0.0001; //Точность

        var step = (X2 - X1) / (points - 1); //шаг изменения х

        Console.WriteLine("Вычисление функции");

        for (var i = 0; i < points; i++)
        {
            var x = X1 + i * step;

            var sumN = GetSumN(x, n);
            var sumE = GetSumEps(x, e);
            var y = GetValue(x);

            Console.WriteLine("X = " + x);
            Console.WriteLine("SN = " + sumN);
            Console.WriteLine("SE = " + sumE);
            Console.WriteLine("Y = " + y);
        }
    }
}