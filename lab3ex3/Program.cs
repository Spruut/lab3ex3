using System;

namespace lab3ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.Write("Enter size of the matrix\na = ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("b = ");
            int b = Convert.ToInt32(Console.ReadLine());
            int[,] array = new int[a, b];
            Console.Write("Enter K = ");
            int k = Convert.ToInt32(Console.ReadLine());

            Random rand = new Random();
            RandomMatrize(array, rand);

            WriteMatrix(array);

            int[] column = new int[a];
            ShiftMatrix(array, column, k);

            WriteMatrix(array);
            Console.ReadKey();
        }
        static void RandomMatrize(int[,] array, Random random)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(0, 9);
                }
            }
        }
        static void WriteMatrix(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]}  ");
                }
                Console.WriteLine();
            }
        }
        static void ShiftMatrix(int[,] array, int[] column, int k)
        {
            while (k > array.GetLength(1))
            {
                k -= array.GetLength(1);
            }
            if (k < array.GetLength(1))
            {
                for (int h = 0; h < k; h++)
                {
                    for (int j = 0; j < array.GetLength(0); j++)
                    {
                        column[j] = array[j, 0];
                    }
                    for (int i = 0; i < array.GetLength(1) - 1; i++)
                    {
                        for (int j = 0; j < array.GetLength(0); j++)
                        {
                            array[j, i] = array[j, i + 1];
                        }
                    }
                    for (int j = 0; j < array.GetLength(0); j++)
                    {
                        array[j, array.GetLength(1) - 1] = column[j];
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
