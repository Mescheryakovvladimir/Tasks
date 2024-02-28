using System;

namespace _2023._11._25_Задание_9И_Мещеряков
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int n = 3;
            int[,] matrix1 = new int[n, n];
            int[,] matrix2 = new int[n, n];
            Random rand = new Random();

            
            for (int i = 0; i < n; i++)//случайно задаем матрицу
            {
                for (int j = 0; j < n; j++)
                {
                    matrix1[i, j] = rand.Next(50);//создаем случайное число 
                    matrix2[i, j] = rand.Next(50);
                }
            }
            
            Console.WriteLine("Матрицы до изменения");
            PrintMatrix(matrix1);
            Console.WriteLine();
            PrintMatrix(matrix2);
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((i == j) || (j == n - i - 1))// вырезаим обе диоганали
                    {
                        matrix2[i, j] = matrix1[i, j];// определение главной и побочной диоганали
                        matrix1[i, j] = 0;
                    }
                }
            }
            
            Console.WriteLine("Матрицы после изменения");
            PrintMatrix(matrix1);
            Console.WriteLine();
            PrintMatrix(matrix2);
            Console.ReadKey(true);
        }
        public static void PrintMatrix(int[,] matrix)// метод выведени метрицы 
        {
            for (int i = 0; i < matrix.GetLength(0); i++)// ширина и длинна матрици 
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}

