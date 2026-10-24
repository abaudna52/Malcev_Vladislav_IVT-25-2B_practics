using System;
public class Lab5
{
    private static Random random = new Random();

    private static void Main()
    {
        int choice = -1;

        while (choice != 0)
        {
            Console.WriteLine("ГЛАВНОЕ МЕНЮ");
            Console.WriteLine("1. Двумерный массив");
            Console.WriteLine("2. Рваный массив");
            Console.WriteLine("3. Обработка строки");
            Console.WriteLine("0. Выход");
            Console.Write("Ваш выбор: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Введите целое число.");
                choice = -1;
                continue;
            }

            if (choice == 1)
            {
                MatrixTask();
            }
            else if (choice == 2)
            {
                JaggedTask();
            }
            else if (choice == 3)
            {
                StringTask();
            }
            else if (choice == 0)
            {
                Console.WriteLine("Программа завершена.");
            }
            else
            {
                Console.WriteLine("Ошибка.");
            }
        }
    }
    private static int ReadInt(string message)
    {
        int number;

        while (true)
        {
            Console.Write(message);

            if (int.TryParse(Console.ReadLine(), out number))
            {
                return number;
            }

            Console.WriteLine("Введите целое число");
        }
    }
    private static int ReadPositiveInt(string message)
    {
        int number;
        do
        {
            number = ReadInt(message);

            if (number <= 0)
            {
                Console.WriteLine("Число должно быть больше нуля.");
            }
        }
        while (number <= 0);
        return number;
    }
    private static int ReadMode()
    {
        int mode;
        do
        {
            Console.WriteLine("1. Заполнить вручную");
            Console.WriteLine("2. Заполнить случайными числами");

            mode = ReadInt("Ваш выбор: ");

            if (mode != 1 && mode != 2)
            {
                Console.WriteLine("Введите 1 или 2.");
            }
        }
        while (mode != 1 && mode != 2);
        return mode;
    }
    //Добавить K столбцов в начало матрицы
    private static void MatrixTask()
    {
        Console.WriteLine("Двумерный массив");
        int rowCount = ReadPositiveInt("Количество строк: ");
        int columnCount = ReadPositiveInt("Количество столбцов: ");
        int[,] matrix = new int[rowCount, columnCount];
        int mode = ReadMode();
        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < columnCount; j++)
            {
                if (mode == 1)
                {
                    matrix[i, j] = ReadInt("Введите элемент: ");
                }
                else
                {
                    matrix[i, j] = random.Next(1, 100);
                }
            }
        }
        PrintArray(matrix, "Исходная матрица");
        int k;
        do
        {
            k = ReadInt("Сколько столбцов добавить? ");

            if (k < 0)
            {
                Console.WriteLine("Введите положительное число.");
            }
        }
        while (k < 0);
        int[,] newMatrix = AddColumns(matrix, k);
        PrintArray(newMatrix);
    }
    private static int[,] AddColumns(int[,] matrix, int k)
    {
        int rowCount = matrix.GetLength(0);
        int columnCount = matrix.GetLength(1);
        int[,] newMatrix = new int[rowCount, columnCount + k];

        for (int i = 0; i < rowCount; i++)
        {
            // Заполняем новые столбцы случайными числами
            for (int j = 0; j < k; j++)
            {
                newMatrix[i, j] = random.Next(1, 100);
            }
            // Переносим старые элементы вправо
            for (int j = 0; j < columnCount; j++)
            {
                newMatrix[i, j + k] = matrix[i, j];
            }
        }
        return newMatrix;
    }
    private static void PrintArray(int[,] matrix, string title = "Массив")
    {
        Console.WriteLine("\n" + title + ":");
        if (matrix.Length == 0)
        {
            Console.WriteLine("Массив пуст.");
            return;
        }
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
    //Удалить строки с чётными номерами
    private static void JaggedTask()
    {
        Console.WriteLine("Рваный массив");
        int rowCount = ReadPositiveInt("Количество строк: ");
        int[][] jaggedArray = new int[rowCount][];
        int mode = ReadMode();
        for (int i = 0; i < rowCount; i++)
        {
            int columnCount = ReadPositiveInt(
                "Количество элементов в строке " + (i + 1) + ": ");
            jaggedArray[i] = new int[columnCount];
            for (int j = 0; j < columnCount; j++)
            {
                if (mode == 1)
                {
                    jaggedArray[i][j] = ReadInt("Введите элемент: ");
                }
                else
                {
                    jaggedArray[i][j] = random.Next(1, 100);
                }
            }
        }
        PrintArray(jaggedArray, "Исходный рваный массив");
        jaggedArray = RemoveEvenRows(jaggedArray);
        PrintArray(jaggedArray, "Массив после удаления чётных строк");
    }
    private static int[][] RemoveEvenRows(int[][] jaggedArray)
    {
        int newRowCount = 0;
        // Считаем строки, которые останутся
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            if ((i + 1) % 2 != 0)
            {
                newRowCount++;
            }
        }
        int[][] newArray = new int[newRowCount][];
        int newIndex = 0;
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            if ((i + 1) % 2 != 0)
            {
                newArray[newIndex] = jaggedArray[i];
                newIndex++;
            }
        }
        return newArray;
    }
    private static void PrintArray(int[][] jaggedArray, string title = "Массив")
    {
        Console.WriteLine("\n" + title + ":");
        if (jaggedArray.Length == 0)
        {
            Console.WriteLine("Массив пуст.");
            return;
        }

        for (int i = 0; i < jaggedArray.Length; i++)
        {
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                Console.Write(jaggedArray[i][j] + "\t");
            }

            Console.WriteLine();
        }
    }
    //Найти самый короткий идентификатор
    private static void StringTask()
    {
        Console.WriteLine("Поиск идентификатора");

        string text = "static void PrintUpper string info12346: WriteLine ToUpper info, 1234info.";

        Console.WriteLine("Исходная строка:");
        Console.WriteLine(text);

        string shortestIdentifier = FindIdentifier(text);

        if (shortestIdentifier == "")
        {
            Console.WriteLine("Идентификаторы не найдены.");
        }
        else
        {
            Console.WriteLine("Самый короткий идентификатор: " + shortestIdentifier);
        }
    }

    private static string FindIdentifier(string text)
    {
        string shortestIdentifier = "";
        int i = 0;

        while (i < text.Length)
        {
            // Пропускаем символы, из которых не начинаются слова
            if (!char.IsLetter(text[i]) && text[i] != '_' &&
                !char.IsDigit(text[i]))
            {
                i++;
                continue;
            }
            int start = i;
            while (i < text.Length &&
                   (char.IsLetterOrDigit(text[i]) || text[i] == '_'))
            {
                i++;
            }

            string word = text.Substring(start, i - start);

            // Идентификатор не может начинаться с цифры
            if (char.IsDigit(word[0]))
            {
                continue;
            }
            if (word == "static" || word == "void" || word == "string" || word == "int" || word == "class")
            {
                continue;
            }
            if (shortestIdentifier == "" ||
                word.Length < shortestIdentifier.Length)
            {
                shortestIdentifier = word;
            }
        }
        return shortestIdentifier;
    }
}