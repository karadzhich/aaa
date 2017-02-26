using System;

namespace Matrixxx
{
    class Program
    {
        static void Multiplicate()
        {
            try
            {
                string[] m1s = System.IO.File.ReadAllLines("m1.txt");
                string[] m2s = System.IO.File.ReadAllLines("m2.txt");

                int xm = m1s.Length, ym = m2s[0].Split(' ').Length;

                if (m1s[0].Split(' ').Length == m2s.Length)
                {
                    double[,] mm = new double[xm, ym];

                    for (int i = 0; i < xm; i++)
                    {
                        for (int j = 0; j < ym; j++)
                        {
                            for (int ix = 0; ix < m2s.Length; ix++)
                            {
                                mm[i, j] += Double.Parse(m1s[i].Split(' ')[ix]) * Double.Parse(m2s[ix].Split(' ')[j]);
                            }

                            Console.Write(mm[i, j] + " ");
                        }

                        Console.WriteLine();
                    }
                }
                else
                {
                    throw new Exception("Размерности матриц не удовлетворяют условиям умножения");
                }
            }
            catch
            {
                throw new Exception("Ошибка при считывании данных");
            }
        }

        public static double[,] GetMinor(double[,] matrix, int row, int column)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1)) throw new Exception("Число строк в матрице не совпадает с числом столбцов");
            
            double[,] buf = new double[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i != row) || (j != column))
                    {
                        if (i > row && j < column) buf[i - 1, j] = matrix[i, j];
                        if (i < row && j > column) buf[i, j - 1] = matrix[i, j];
                        if (i > row && j > column) buf[i - 1, j - 1] = matrix[i, j];
                        if (i < row && j < column) buf[i, j] = matrix[i, j];
                    }
                }
            }

            return buf;
        }

        public static double Determ(double[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1)) throw new Exception("Число строк в матрице не совпадает с числом столбцов");
            
            double det = 0;

            int Rank = matrix.GetLength(0);
            if (Rank == 1) det = matrix[0, 0];
            if (Rank == 2) det = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            if (Rank > 2)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    det += Math.Pow(-1, 0 + j) * matrix[0, j] * Determ(GetMinor(matrix, 0, j));
                }
            }
            return det;
        }

        static void Main(string[] args)
        {
            Multiplicate();
            Console.ReadKey();
        }
    }
}