using System;

namespace Номер_7и_Мещеряков
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double koef1 = 0.8, G = 0, z, x;
            int koef2 = 5, koef3 = 25, n, i, ost, stepx = 2, stepz1 = 0, stepz2 = 1;
            Console.Write("Введите количество элементов ряда n: ");
            int.TryParse(Console.ReadLine(), out n);// TryParse чтение из консои и перевод в указанный тип в начале строки 
            Console.Write("Введите переменную z: ");
            double.TryParse(Console.ReadLine(), out z);
            Console.Write("Введите переменную ряда x: ");
            double.TryParse(Console.ReadLine(), out x);
            for (i = 0; i < n; i++) // итерационный цикл. мы задем значение индекса условие действие
            {
                Math.DivRem(i + 1, 2, out ost);// остаток от деления на 2 
                if (ost == 1)
                    G += (koef1 * Math.Pow(z, stepz1) -//Math.Pow степень
                        Math.Sin(Math.Pow(z, stepz2))) /
                        Math.Sqrt(Math.Pow(x, stepx) + koef2 * x + koef3);
                else
                    G += (koef1 * Math.Pow(z, stepz1) +
                        Math.Cos(Math.Pow(z, stepz2))) /
                        Math.Sqrt(Math.Pow(x, stepx) + koef2 * x + koef3);
                koef1 += 0.8;
                koef2 += 5;
                koef3 += 5;
                stepx += 2;
                stepz1--;
                stepz2++;
            }
            Console.Write("Полученная G: ");
            Console.WriteLine(Math.Round(G, 3));// округление до кокогото количесто знаков после запятой 
            Console.ReadKey(true);
        }
    }
}
