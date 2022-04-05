using System;

namespace oper
{
    public class Matrix
    {
        public int n; // Размерность
        public int k; // Кол-во ненулевых

        // Структура для элементов
        public struct Matrix_Elements
        {
            public double value; // Значение эл-та
            public int l; // Позиция эл-та
        }

        public Matrix_Elements[] b; // Массив ненулевых элементов

        public Matrix(int n) // Конструктор 
        {
            this.n = n;
            b = new Matrix_Elements[3*n];
        }

        public void Pos(int el, ref int i, ref int j) // ref - ссылка
        {
            // Высчитывание j по l
            if (b[el].l % n == 0)
            {
                j = b[el].l / n;
            }
            else
            {
                j = b[el].l / n + 1;
            }

            // Высчитывание i
            i = b[el].l - (j - 1) * n;
        }
        static public void Sum(Matrix A, Matrix B, Matrix C)
        {
            for (int i = 0; i < C.b.Length; i++)
            {
                C.b[i].value = 0;
                C.b[i].l = 0;
            }
            int cnt = 0;
            int index1 = 0; int index2 = 0;
            while ((index1 < A.b.Length && index2 < B.b.Length) && A.b[index1].value !=0 && B.b[index2].value !=0 )
            {
                if ((A.b[index1].l < B.b[index2].l) && A.b[index1].l != 0)
                {
                    C.b[cnt].l = A.b[index1].l;
                    C.b[cnt].value = A.b[index1].value;
                    index1++;
                    cnt++;
                }
                if ((A.b[index1].l > B.b[index2].l) && B.b[index2].l != 0)
                {
                    C.b[cnt].l = B.b[index2].l;
                    C.b[cnt].value = B.b[index2].value;
                    index2++;
                    cnt++;
                }
                if ((A.b[index1].l == B.b[index2].l) && B.b[index2].l != 0)
                {
                    C.b[cnt].l = B.b[index2].l;
                    C.b[cnt].value = A.b[index1].value + B.b[index2].value;
                    index1++;
                    index2++;
                    cnt++;
                }
            }
            if (A.b[index1].value != 0)
            {
                while (A.b[index1].value != 0 && index1 < A.b.Length)
                {
                    C.b[cnt].l = A.b[index1].l;
                    C.b[cnt].value = A.b[index1].value;
                    index1++;
                    cnt++;
                }
            }

            if (B.b[index2].value != 0)
            {
                while (B.b[index2].value != 0 && index2 < B.b.Length)
                {
                    C.b[cnt].l = B.b[index2].l;
                    C.b[cnt].value = B.b[index2].value;
                    index2++;
                    cnt++;
                }
            }

        }

        static public void Razn(Matrix A, Matrix B, Matrix C)
        {
            for (int i = 0; i < C.b.Length; i++)
            {
                C.b[i].value = 0;
                C.b[i].l = 0;
            }
            int cnt = 0;
            int index1 = 0; int index2 = 0;
            while ((index1 < A.b.Length && index2 < B.b.Length) && A.b[index1].value != 0 && B.b[index2].value != 0)
            {
                if ((A.b[index1].l < B.b[index2].l) && A.b[index1].l != 0)
                {
                    C.b[cnt].l = A.b[index1].l;
                    C.b[cnt].value = A.b[index1].value;
                    index1++;
                    cnt++;
                }
                if ((A.b[index1].l > B.b[index2].l) && B.b[index2].l != 0)
                {
                    C.b[cnt].l = B.b[index2].l;
                    C.b[cnt].value = -B.b[index2].value;
                    index2++;
                    cnt++;
                }
                if ((A.b[index1].l == B.b[index2].l) && B.b[index2].l != 0)
                {
                    C.b[cnt].l = B.b[index2].l;
                    C.b[cnt].value = A.b[index1].value - B.b[index2].value;
                    index1++;
                    index2++;
                    cnt++;
                }
            }
            if (A.b[index1].value != 0)
            {
                while (A.b[index1].value != 0 && index1 < A.b.Length)
                {
                    C.b[cnt].l = A.b[index1].l;
                    C.b[cnt].value = A.b[index1].value;
                    index1++;
                    cnt++;
                }
            }

            if (B.b[index2].value != 0)
            {
                while (B.b[index2].value != 0 && index2 < B.b.Length)
                {
                    C.b[cnt].l = B.b[index2].l;
                    C.b[cnt].value = -B.b[index2].value;
                    index2++;
                    cnt++;
                }
            }

        }

        static public void Trans(Matrix A)
        {

        }

    }
        class Program
    {

        static void Main(string[] args)
        {
            Matrix A = new Matrix(3);
            Matrix B = new Matrix(3);
            Matrix C = new Matrix(3);
            int cnt = 0;
            double[,] M = { { 10, 9, 0 }, 
                            { 8, 7, 57 },
                             {0, 0, 0 } };
            double[,] M1 = { { 5, 4, 0 },
                             { 3, 2, 0 },
                             { 0, 2, 1} };

            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++) {
                    if (M[i, j] != 0)
                    {
                        int kk = (i + 1) + ((j + 1) - 1) * A.n;
                        A.b[cnt].l = kk;
                        A.b[cnt].value = M[i, j];
                        cnt++;
                    }
                }
            }

             cnt = 0;
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (M1[i, j] != 0)
                    {
                        int kk = (i + 1) + ((j + 1) - 1) * B.n;
                        B.b[cnt].l = kk;
                        B.b[cnt].value = M1[i, j];
                        cnt++;
                    }
                }
            }

            Matrix.Razn(A, B, C);
            for (int i = 0; i < A.b.Length; i++)
            {
                Console.WriteLine($"{C.b[i].value} {C.b[i].l}");
            }

            Console.WriteLine();
            Console.WriteLine();

            //cnt = 0;
            //for (int i = 0; i < A.n; i++)
            //{
            //    for (int j = 0; j < A.n; j++)
            //    {
            //        int jj = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(A.b[cnt].l / A.n)));

            //        int ii = A.b[cnt].l - ((jj - 1) * A.n);
            //        Console.WriteLine($"{ii} {jj} {A.b[cnt].l} {A.n}");
            //        if (j == jj && i == ii)
            //        {
            //            Console.Write($"{A.b[cnt].value} ");
            //            cnt++;
            //        }
            //        else
            //        {
            //            Console.Write($"{0} ");
            //        }
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
