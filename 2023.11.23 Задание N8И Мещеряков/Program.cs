using System;


namespace _2023._11._23_Задание_N8И_Мещеряков
{
    internal class Program
    {
        static void Main(string[] args)// Void - пустой тип данных, применяющийся, например, для того, чтобы показать то, что функция ничего не возвращает
        {
            int n = 100000, i, min = 1, max = 1;
            double[] mas = new double[n];//есть мавсив mas и мы задали ему обьем
            Console.Write("Введите количество элементов массива: ");
            int.TryParse(Console.ReadLine(), out n);
            for (i = 0; i < n; i++)
            {
                Console.Write($"Введите {i + 1}-й элемент массива: ");
                double.TryParse(Console.ReadLine(), out mas[i]);
            }
            for (i = 0; i < n; i++)//ищем максмальныц и минимальный элемент массива
            {
                if (Math.Max(mas[i], mas[max - 1]) > mas[max - 1])//ишем текуший или предыдуший и сравнием их
                    max = i + 1;
                else
                {
                    if (Math.Min(mas[i], mas[min - 1]) < mas[min - 1])
                        min = i + 1;
                }
            }
            Console.WriteLine($"Максимальный элемент введённого массива" +
                $" находится на {max} позиции, минимальный на {min}");
            Console.ReadKey(true);
        }
    }
}
