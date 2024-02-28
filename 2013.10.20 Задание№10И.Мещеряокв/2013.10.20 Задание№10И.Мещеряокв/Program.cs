using System;
using System.Text;// строку собирать в слова

namespace _2013._10._20_Задание_10И.Мещеряокв
{
    internal class Program
    {
        //задача 1 по сбору слов по пробелу
        //типиз. метод берёт строку должен вернуть строку
        static string TaskOne(string s)
        {
            StringBuilder str = new StringBuilder("");
            bool flag = true;

            // встреча пробела в строке влияет на сбор-или нет слова
            // 1) собираем слова до пробела (если встретили, то переходим к 2)
            // 2) не собираем до пробела (если встретили то переходим к 1)
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ') flag = !flag;
                if (flag) str.Append(s[i]);
            }
            return str.ToString();
        }

        //типиз. метод берёт строку, возвращает ту же строку,
        //НО без пробелов в начале и без двойных пробелов (дублей)
        static string delSpaces(string text)
        {
            StringBuilder str = new StringBuilder(text);
            while (str[0] == ' ')
            {
                str.Remove(0, 1);
            }
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == ' ' && str[i - 1] == ' ')
                {
                    str.Remove(i, 1);
                    i--;
                }
            }

            return str.ToString();
        }
        //типиз. метод берёт строку - возвращает кол-во слов между самым маленьким и самым длинным словом
        static int TaskTwo(string text)
        {
            text = delSpaces(text);
            int max_pos = 0;
            int min_pos = 0;

            int max_length = 0;
            int min_length = int.MaxValue;
            int j = 0;

            int currentWordIndex = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != ' ' && i != text.Length - 1) j++; //если не пробел = собираем слово
                else 
                {
                    // j - количество символов в текущем слове
                    if (j > max_length)
                    {
                        max_pos = currentWordIndex;
                        max_length = j;
                    }
                    if (j < min_length)
                    {
                        min_pos = currentWordIndex;
                        min_length = j;
                    }
                    currentWordIndex++;
                    j = 0; //слово проверили по длинне - обнуляем
                }
            }
            int delta = Math.Abs(max_pos - min_pos) - 1;
            return delta;
        }
        //нетипиз. метод который берёт массив строк (пункты меню) и цифру-позицию курсора в меню
        static void PrintMenu(string[] text, int arrowPos)
        {
            Console.Clear(); //очищаем консоль от выведенного меню
            arrowPos++;
            //мы выводим меню в цикле
            //i - цифра пункта в меню
            for (int i = 1; i < text.Length; i++)
            {
                //если позиция курсора != цифре подпункта
                if (i != arrowPos)
                {
                    //мы рисуем этот пункт обычно без стрелки слева от строки из массива
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("  " + text[i]);
                }
                else
                {
                    //иначе мы рисуем этот пункт с красным задним планом и стрелкой слева от строки из массива
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("->" + text[i]);
                }
                Console.BackgroundColor = ConsoleColor.Black; //заново красим чтобы избежать ошибок
            }
        }

        //нетипиз. метод по выводу меню в цикле
        static void MenuCycle()
        {
            string[] mainMenu = new string[4];
            mainMenu[0] = "Главное меню";//нулевой пункт не выводится в меню,
                                         //нужен для внутренней навигации
            mainMenu[1] = "1. Задача 1";
            mainMenu[2] = "2. Задача 2";
            mainMenu[3] = "3. Выход";

            string[] taskOneMenu = new string[4];
            taskOneMenu[0] = "Задача 1";
            taskOneMenu[1] = "1. Ручной ввод";
            taskOneMenu[2] = "2. Пример работы";
            taskOneMenu[3] = "3. Назад";

            string[] taskTwoMenu = new string[4];
            taskTwoMenu[0] = "Задача 2";
            taskTwoMenu[1] = "1. Ручной ввод";
            taskTwoMenu[2] = "2. Пример работы";
            taskTwoMenu[3] = "3. Назад";

            int arrowIndex = 0; //курсор на 0 пункте меню
            string[] currentMenu = mainMenu; //сначала выводим главн. меню
            while (true)
            {
                //печатаем тек.меню (которое главное) с индексом курсора (метод буквально сверху)
                PrintMenu(currentMenu, arrowIndex);
                //проверяем какая клавиша нажата
                ConsoleKeyInfo key = Console.ReadKey();

                //по клавише делаем что-то
                switch (key.Key)
                {
                    //если стрелка вверх то индекс курсора -1
                    case ConsoleKey.UpArrow:
                        arrowIndex = arrowPosChange(currentMenu.Length - 1,
                            --arrowIndex);
                        break;

                    //если стрелка вниз то индекс курсора +1
                    case ConsoleKey.DownArrow:
                        arrowIndex = arrowPosChange(currentMenu.Length - 1,
                            ++arrowIndex);
                        break;

                    //если нажат enter то мы должны проверить в каком меню находимся, чтобы потом поменять его или нет
                    case ConsoleKey.Enter:
                        //если мы в главном меню и курсор на 0!!! пункте значит переходим в подменю ПЕРВОГО задания
                        if (arrowIndex == 0 && currentMenu[0] == "Главное меню")
                        {
                            currentMenu = taskOneMenu;
                            arrowIndex = 0;
                        }
                        //если мы в главном меню и курсор на 1!!! пункте значит переходим в подменю ВТОРОГО задания
                        else
                            if (arrowIndex == 1 && currentMenu[0] ==
                            "Главное меню")
                        {
                            currentMenu = taskTwoMenu;
                            arrowIndex = 0;
                        }
                        else
                            if (currentMenu[0] != "Главное меню" && arrowIndex == 2)
                        //обработка назад в любом из меню заданий
                        {
                            arrowIndex = currentMenu[0][currentMenu[0].Length - 1]
                                - 49;
                            // сохранение позиции стрелки и выбор главного меню как текущего меню для выхода
                            currentMenu = mainMenu;
                        }
                        //выполняем первую задачу если на ней курсор
                        else if (currentMenu[0] == "Задача 1" && arrowIndex == 0)
                        {
                            Console.Clear();
                            Console.Write("Введите текст: ");
                            string s = Console.ReadLine();
                            //выполняем метод первой задачи и печатаем вывод первой задачи
                            Console.WriteLine("Результат: " + TaskOne(s));
                            Console.WriteLine("Нажмите любую клавишу");
                            Console.ReadKey();
                        }
                        else if (currentMenu[0] == "Задача 1" && arrowIndex == 1)
                        {
                            Console.Clear();
                            string s = "первый второй первый второй первый второй" +
                                " первый второй";
                            Console.WriteLine("Тестовый текст: " + s);
                            //выполняем метод первой задачи и печатаем вывод пример заранее сделанный
                            Console.WriteLine("Результат: " + TaskOne(s));
                            Console.WriteLine("Нажмите любую клавишу");
                            Console.ReadKey();
                        }
                        else if (currentMenu[0] == "Задача 2" && arrowIndex == 0)
                        {
                            Console.Clear();
                            Console.Write("Введите текст: ");
                            string s = Console.ReadLine();
                            Console.WriteLine("Результат: " + TaskTwo(s));
                            Console.WriteLine("Нажмите любую клавишу");
                            Console.ReadKey();
                        }
                        else if (currentMenu[0] == "Задача 2" && arrowIndex == 1)
                        {
                            Console.Clear();
                            string s = "0 11 222 333. 444 555. 666 777. 8888 " +
                                "9999999999. 10000 11000.";//измить эти числа
                            Console.WriteLine("Тестовый текст: " + s);
                            Console.WriteLine("Результат: " + TaskTwo(s));
                            Console.WriteLine("Нажмите любую клавишу");
                            Console.ReadKey();
                        }
                        else
                            if (currentMenu[0] == "Главное меню" &&
                            arrowIndex == 2)
                        {
                            Environment.Exit(0); //закрытие консоли принудительно, когда мы выбрали выход в гл.меню
                        }
                        break;
                }
            }
        }
        //выполнение кода само здесь - вызываем меню
        static void Main(string[] args)
        {
            MenuCycle();

            Console.ReadKey();
        }
        //типиз. метод на ввод которого размер меню, позиция курсора - вывод новая позиция курсора в зависимости от изменения
        static int arrowPosChange(int menuSize, int arrowPos)
        {
            if (arrowPos > menuSize - 1) arrowPos = 0; //если курсор в самом низу и нажата клавиша вниз -> c посл. пункта в первый
            if (arrowPos < 0) arrowPos = menuSize - 1; //наоборот
            return arrowPos;
        }
    }
}
