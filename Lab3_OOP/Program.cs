using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isOpen = true;
            Random rand = new Random();

            while (isOpen)
            {
                Console.WriteLine("Введіть розмірність матриці:");
                int firstInput = Convert.ToInt32(Console.ReadLine());
                int secondInput = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                double[,] arr = new double[firstInput, secondInput];
                double[][] arr1 = new double[firstInput][];
                double[][] arr2 = new double[firstInput][];
                string[] strArr = { "6", "45", "4", "34", "2" };
                string str = "3 4    1 3    463 67 55 5";

                RandArr(rand, arr);
                RandArr(arr1, secondInput);
                RandArr(rand, arr2);

                Console.WriteLine("Копіювання двовимірного масиву:");
                MyMatrix myMatrix = new MyMatrix(arr);
                Console.WriteLine(myMatrix);

                Console.WriteLine("Копіювання зубчастого масиву 1:");
                MyMatrix myMatrix1 = new MyMatrix(arr1);
                if (myMatrix1.IsEqualToCopy(myMatrix1.IsEqual))
                    Console.WriteLine(myMatrix1);

                Console.WriteLine("Копіювання зубчастого масиву 2 (не прямокутний):");
                MyMatrix myMatrix2 = new MyMatrix(arr2);
                if (myMatrix2.IsEqualToCopy(myMatrix2.IsEqual))
                    Console.WriteLine(myMatrix2);

                Console.WriteLine("Копіювання масиву рядків:");
                MyMatrix myMatrix3 = new MyMatrix(strArr);
                Console.WriteLine(myMatrix3);

                Console.WriteLine("Копіювання рядка:");
                MyMatrix myMatrix4 = new MyMatrix(str);
                Console.WriteLine(myMatrix4);

                Console.Write("Демонстрація роботи методу GetElement, за номером рядка 2 та стовпчика 3:\t");
                myMatrix.GetElement(2, 3);
                Console.WriteLine("\n" + myMatrix);

                Console.Write("Демонстрація роботи методу SetElement, за номером рядка 2 та стовпчика 3:\t");
                myMatrix.SetElement(2, 3, 1000);
                Console.WriteLine("\n" + myMatrix);

                Console.WriteLine("Демонстрація індексаторів:");
                Console.WriteLine($"Отримане значення за координатами [3, 3]: {myMatrix1[3, 3]}");
                Console.WriteLine(myMatrix1);
                Console.WriteLine($"Встановлене значення за координатами [3, 3]: {myMatrix1[3, 3] = 1000}");
                Console.WriteLine(myMatrix1);

                Console.WriteLine("Додавання двох матриць:");
                MyMatrix resPlus = myMatrix + myMatrix;
                Console.Write($"{myMatrix} + \n{myMatrix} = \n{resPlus}");

                Console.WriteLine("\nМноження двох матриць:");
                MyMatrix resMulti = myMatrix * myMatrix1;
                Console.Write($"{myMatrix} * \n{myMatrix1} = \n{resMulti}");

                Console.WriteLine("\nТранспонування матриць:");
                Console.WriteLine($"До:\n{myMatrix}");
                Console.WriteLine($"Після:\n{myMatrix.GetTransposedCopy()}");

                Console.WriteLine($"До:\n{myMatrix1}");
                myMatrix1.TransponeMe(myMatrix1);
                Console.WriteLine($"Після:\n{myMatrix1}");

                Console.ReadLine();
                Console.Clear();
            }
        }

        public static void RandArr(Random rand, double[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rand.Next(11);
                }
            }
        }

        public static void RandArr(double[][] arr, int size)
        {
            Random rand = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new double[size];
            }

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = rand.Next(11);
                }
            }
        }

        public static void RandArr(Random rand, double[][] arr)
        {
            int randSize;

            for (int i = 0; i < arr.Length; i++)
            {
                randSize = rand.Next(11);
                arr[i] = new double[randSize];
            }

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = rand.Next(11);
                }
            }
        }
    }
}
