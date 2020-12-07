using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_OOP
{
    class MyMatrix
    {
        private double[,] _myMatrix;

        public MyMatrix(MyMatrix myMatrix)
        {
            _myMatrix = myMatrix._myMatrix;
        }

        public MyMatrix()
        {

        }
    }
}
