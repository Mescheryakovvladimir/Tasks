using System;
using System.Text;


namespace Задание_11и_Мещеряков
{
    internal class Program
    {
        public static string Incrypt(string s)
        {
            StringBuilder str = new StringBuilder(s); // Метод работы со стоками дает возможность изменять изменять элементы строку(представляет строку как массив)
            int j = str.Length - 2;//Количесто символов строки -2 и приравниваем к J 
            for (int i = 1; i <= str.Length / 2; i += 2, j -= 2)//Делает преред циками(i=1 если i <= длинны строки деленное на 2) делаем после каждого цикла
            {
                char temp = str[i];//создаем временныю переменную в вкоторую закидываем текуший заменяемый символ
                str[i] = str[j];// Заменяем четное с начала и четное с конца 
                str[j] = temp;// замена то что в конце на точто было в начале 
            }

            return str.ToString();// изменяемую стоку превращаем в неизменяемую
        }

        static void Main()
        {
            Console.WriteLine("Введите предложение: ");
            string s = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Зашифрованное слово: ");
            Console.Write(Incrypt(s));
            Console.WriteLine();
            Console.Write("Расшифрованное слово: ");
            Console.Write(Incrypt(Incrypt(s)));
            Console.ReadKey();
        }
    }
}
//каждый втрой символ с начала меняется ка каждый второй с конца 
// 