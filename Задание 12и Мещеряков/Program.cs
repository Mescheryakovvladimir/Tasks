using System;
using System.Text;
using System.Threading;

namespace Задание_12и_Мещеряков
{
    internal class Program
    {
        public static void Incrypt(ref string s)//не типизированный медод в и из котороко мы берем переменную s
        {
            StringBuilder str = new StringBuilder(s);
            int j = str.Length - 2;
            for (int i = 1; i < str.Length / 2; i += 2, j -= 2)
            {
                char temp = str[i];
                str[i] = str[j];
                str[j] = temp;
            }

            s = str.ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите предложение: ");
            string s = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Зашифрованное слово: ");
            Incrypt(ref s);
            Console.Write(s);
            Console.WriteLine();
            Console.Write("Расшифрованное слово: ");
            Incrypt(ref s);
            Console.Write(s);
            Console.ReadKey();
        }
    }
}
