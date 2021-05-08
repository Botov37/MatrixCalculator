using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MatrixLibrary.Tests
{
    [TestClass]
    public class MatrixTest
    {
        /// <summary>
        /// Тест для проверки правильно ли складываются матрицы
        /// </summary>
        [TestMethod]
        public void Get_Right_Plus_Result()
        {
            const int size = 4;
            var realResult = new dynamic[size, size] { { 0, 2, 4, 6 }, { 0, 2, 4, 6 }, { 0, 2, 4, 6 }, { 0, 2, 4, 6 } };

            var matrix1 = new MyMatrix<double>(size, size);
            var matrix2 = new MyMatrix<double>(size, size);
            MyMatrix<double> resultMatrix1;
            var resultMatrix2 = new dynamic[size, size];

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    matrix1[j, i] = i;
                    matrix2[j, i] = i;                 
                }               
            }

            resultMatrix1 = matrix1 + matrix2;

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    resultMatrix2[j, i] = resultMatrix1[j, i];
                }
            }

            CollectionAssert.AreEqual(realResult, resultMatrix2);
        }
         /// <summary>
         /// Проверка правильно ли умножаются матрицы
         /// </summary>
        [TestMethod]
        public void Get_Right_Multiply_Result()
        {
            const int size = 4;
            dynamic[,] realResult = new dynamic[size, size] { { 0, 6, 12, 18 }, { 0, 6, 12, 18 }, { 0, 6, 12, 18 }, { 0, 6, 12, 18 } };

            var matrix1 = new MyMatrix<double>(size, size);
            var matrix2 = new MyMatrix<double>(size, size);
            MyMatrix<double> resultMatrix1;
            dynamic[,] resultMatrix2 = new dynamic[size, size];

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    matrix1[j, i] = i;
                    matrix2[j, i] = i;
                }
            }

            resultMatrix1 = matrix1 * matrix2;

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    resultMatrix2[j, i] = resultMatrix1[j, i];
                }
            }

            CollectionAssert.AreEqual(realResult, resultMatrix2);
        }
        /// <summary>
        /// Умножение матриц проверка размерности
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Multiply_Negative_Matrix()
        {
            MyMatrix<double> resultMatrix1;
            var matrix1 = new MyMatrix<double>(2, 4);
            var matrix2 = new MyMatrix<double>(2, 4);

            resultMatrix1 = matrix1 * matrix2;
        }
         /// <summary>
         /// Сложение матриц, проверка размерности
         /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Plus_Negative_Matrix()
        {
            MyMatrix<double> resultMatrix1;
            var matrix1 = new MyMatrix<double>(2, 2);
            var matrix2 = new MyMatrix<double>(3, 3);

            resultMatrix1 = matrix1 + matrix2;
        }
         /// <summary>
         /// Проверка на то, что пользователь ввел колонку rows 0
         /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Negative_Matrix_With_0()
        {
            MyMatrix<double>.GenerateMatrix(0, 4, (x1, y1, rnd) => rnd.Next(-100, 100) + x1 - y1);
        }
    }
}
