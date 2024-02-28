using System; //используем тоько консоль баз

namespace _2021._10._18.Задание_6И.Мещеряков
{
    class Program
    {
        static void Main(string[] args)//Void этот метод не равен каомуто значению, он не должен ничего возвшать
        {
            //bool логической  boolean = true or false
            double x = 0, dx = 10d * (Math.PI / 180d);//doube это дробное с двойной точностью :10d = 10.0
            do // do посто условный цикл. сначала делаем потом проверяем while пред условный цикл
            {
                Console.Write("X = ");
                Console.Write(x.ToString("0.00")); // .ToString перевод в строк. тип
                Console.Write('\t'); // особый знак раздела строки
                Console.Write("Значение sin: ");
                Console.Write(Math.Sin(x).ToString("0.00"));//Rond огругление до указанного значения
                Console.Write('\t'); // особый знак раздела строки
                Console.Write("Значение cos: ");
                Console.Write(Math.Cos(x).ToString("0.00"));
                Console.WriteLine(" "); //перенос на след строку
                x += dx;
            }
            while (x <= (90d * (Math.PI / 180d)));
            Console.ReadKey(true);// ожидание нажатия клавиши 
        }
    }   
}
