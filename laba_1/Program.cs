using System;

namespace Лаба1_ООП
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задача 1
            Console.WriteLine("Задача 1");

            Console.Write("m? ");
            int m = int.Parse(Console.ReadLine());

            Console.Write("n? ");
            int n = int.Parse(Console.ReadLine());
            // 1)
            int n1 = n;
            if (n1 == 1)
            {
                Console.WriteLine("Ошибка, деление на 0");
            }
            else
            {
                int r1 = m / --n1;
                Console.WriteLine("1) m/--n = " + r1);
            }

            // 2)
            int n2 = n;
            if (n2 == 0)
            {
                Console.WriteLine("Ошибка, деление на 0");
            }
            else
            {
                bool r2 = m / n2 < n2--;
                Console.WriteLine("2) m/n<n-- = " + r2);
            }

            // 3)
            int n3 = n;
            bool r3 = m + n3++ > n3 + m;
            Console.WriteLine("3) m+n++>n+m = " + r3);

            // 4)
            Console.Write("Введите x: ");
            double x = double.Parse(Console.ReadLine());
            double r4 = Math.Pow(x, 5) * Math.Sqrt(Math.Abs(x - 1)) + Math.Abs(25 - Math.Pow(x, 5));
            Console.WriteLine("4) ответ = " + r4);

            // ЗАдача 2
            Console.WriteLine("Задача 2");

            Console.Write("Введите X1: ");
            double x1 = double.Parse(Console.ReadLine());

            Console.Write("Введите Y1: ");
            double y1 = double.Parse(Console.ReadLine());

            // область: треугольник (-7,0) (0,0) (0,-1)
            bool inArea = x1 <= 0 && y1 <= 0 && x1 + 7 * y1 + 7 >= 0;
            Console.WriteLine("Точка принадлежит области: " + inArea);

            // Задача 3
            Console.WriteLine("Задача 3");

            double a = 1000, b = 0.0001;

            double resDouble = (Math.Pow(a + b, 3) - (Math.Pow(a, 3) + 3 * Math.Pow(a, 2) * b))
                                / (3 * a * Math.Pow(b, 2) + Math.Pow(b, 3));
            Console.WriteLine("Результат double: " + resDouble);

            float af = 1000f, bf = 0.0001f;
            float resFloat = (float)((Math.Pow(af + bf, 3) - (Math.Pow(af, 3) + 3 * Math.Pow(af, 2) * bf))
                              / (3 * af * Math.Pow(bf, 2) + Math.Pow(bf, 3)));
            Console.WriteLine("Результат float: " + resFloat);
        }
    }
}