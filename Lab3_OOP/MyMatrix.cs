using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_OOP
{
    class MyMatrix
    {
        public bool IsEqual { get; private set; }

        private double[,] _myMatrix;

        public double this[int i, int j]
        {
            get
            {
                return _myMatrix[i - 1, j - 1];
            }
            set
            {
                _myMatrix[i - 1, j - 1] = value;
            }
        }

        public MyMatrix(int sizeX, int sizeY)
        {
            _myMatrix = new double[sizeX, sizeY];
        }

        public MyMatrix(MyMatrix myMatrix)
        {
            _myMatrix = myMatrix._myMatrix;
        }

        public MyMatrix(double[,] myMatrix)
        {
            _myMatrix = new double[myMatrix.GetLength(0), myMatrix.GetLength(1)];

            for (int i = 0; i < myMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < myMatrix.GetLength(1); j++)
                {
                    _myMatrix[i, j] = myMatrix[i, j];
                }
            }
        }

        public MyMatrix(double[][] myMatrix)
        {
            bool flag = true;

            _myMatrix = new double[myMatrix.Length, myMatrix.Length];

            for (int i = 0; i < myMatrix.Length; i++)
            {
                for (int j = 0; j < myMatrix[i].Length; j++)
                {
                    if (myMatrix[i].Length != _myMatrix.GetLength(1))
                    {
                        Console.WriteLine("Зубчатий масив не прямокутний...\n");
                        flag = false;
                        break;
                    }
                    _myMatrix[i, j] = myMatrix[i][j];
                }
                if (flag == false)
                    break;
            }

            IsEqualToCopy(flag);
        }

        public MyMatrix(string[] strArr)
        {
            _myMatrix = new double[strArr.Length, strArr.Length];

            int[] tempIntArr = new int[strArr.Length];

            try
            {
                for (int i = 0; i < strArr.Length; i++)
                {
                    tempIntArr[i] = Convert.ToInt32(strArr[i]);
                }

                for (int i = 0; i < _myMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < _myMatrix.GetLength(1); j++)
                    {
                        _myMatrix[i, j] = tempIntArr[i];
                    }
                }
            }
            catch
            {
                Console.WriteLine("Некоректні символи.");
            }
        }

        public MyMatrix(string str)
        {
            //3 4    1 3    463 67 55 5
            char[] separators = { ' ' };
            string[] strTempArr = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int[] tempArr = new int[strTempArr.Length];

            _myMatrix = new double[strTempArr.Length, strTempArr.Length];

            try
            {
                for (int i = 0; i < strTempArr.Length; i++)
                {
                    tempArr[i] = Convert.ToInt32(strTempArr[i]);
                }

                for (int i = 0; i < _myMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < _myMatrix.GetLength(1); j++)
                    {
                        _myMatrix[i, j] = tempArr[i];
                    }
                }
            }
            catch
            {
                Console.WriteLine("Некоректні символи.");
            }
        }

        public static MyMatrix operator +(MyMatrix myMatrix1, MyMatrix myMatrix2)
        {
            MyMatrix result = new MyMatrix(myMatrix1.Height(), myMatrix2.Width());
            double[,] firstMatrix = new double[myMatrix1.Height(), myMatrix1.Width()];
            double[,] secondMatrix = new double[myMatrix2.Height(), myMatrix2.Width()];

            try
            {
                if (firstMatrix.Length == secondMatrix.Length)
                {
                    for (int i = 0; i < myMatrix1.Height(); i++)
                    {
                        for (int j = 0; j < myMatrix1.Width(); j++)
                        {
                            result._myMatrix[i, j] = myMatrix1._myMatrix[i, j] + myMatrix2._myMatrix[i, j];
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Помилка з кілк-стю елемнтами...");
            }

            return result;
        }

        public static MyMatrix operator *(MyMatrix myMatrix1, MyMatrix myMatrix2)
        {
            MyMatrix result = new MyMatrix(myMatrix1.Height(), myMatrix2.Width());
            double[,] firstMatrix = new double[myMatrix1.Height(), myMatrix1.Width()];
            double[,] secondMatrix = new double[myMatrix2.Height(), myMatrix2.Width()];

            try
            {
                if (firstMatrix.Length == secondMatrix.Length)
                {
                    for (int i = 0; i < myMatrix1.Height(); i++)
                    {
                        for (int j = 0; j < myMatrix1.Width(); j++)
                        {
                            result._myMatrix[i, j] = 0;
                            for (int k = 0; k < myMatrix1.Width(); k++)
                            {
                                result._myMatrix[i, j] += myMatrix1._myMatrix[i, j] * myMatrix2._myMatrix[i, j];
                            }
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Помилка з кілк-стю елемнтами...");
            }

            return result;
        }

        private double[,] GetTransponedArray()
        {
            double[,] result = new double[Width(), Height()];

            for (int row = 0; row < Height(); row++)
            {
                for (int column = 0; column < Width(); column++)
                {
                    result[column, row] = _myMatrix[row, column];
                }
            }

            return result;
        }

        public MyMatrix GetTransposedCopy()
        {
            MyMatrix matrix = new MyMatrix(GetTransponedArray());

            return matrix;
        }

        public void TransponeMe(MyMatrix matrix)
        {
            _myMatrix = matrix.GetTransponedArray();
        }

        public int Height()
        {
            return _myMatrix.GetLength(0);
        }

        public int Width()
        {
            return _myMatrix.GetLength(1);
        }

        public int GetHeight()
        {
            return Height();
        }

        public int GetWidth()
        {
            return Width();
        }

        public void GetElement(int x, int y)
        {
            bool flag = true;
            
            for (int i = 0; i < GetHeight(); i++)
            {
                for (int j = 0; j < GetWidth(); j++)
                {
                    if (_myMatrix[x - 1, y - 1] == _myMatrix[i, j])
                    {
                        Console.WriteLine(_myMatrix[x - 1, y - 1]);
                        flag = false;
                        break;
                    }
                }
                if (flag == false)
                    break;
            }
        }

        public void SetElement(int x, int y, int value)
        {
            bool flag = true;

            for (int i = 0; i < GetHeight(); i++)
            {
                for (int j = 0; j < GetWidth(); j++)
                {
                    if (_myMatrix[x - 1, y - 1] == _myMatrix[i, j])
                    {
                        _myMatrix[x - 1, y - 1] = value;
                        flag = false;
                        break;
                    }
                }
                if (flag == false)
                    break;
            }
        }

        public bool IsEqualToCopy(bool flag)
        {
            IsEqual = flag;

            if (IsEqual == true)
                return true;
            return false;
        }

        override public string ToString()
        {
            var sb = new StringBuilder();
            
            for (int i = 0; i < _myMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < _myMatrix.GetLength(1); j++)
                {
                    sb.Append($"{_myMatrix[i, j]}\t");
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
