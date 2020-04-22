using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            //генерируем случайные координаты;
            int A1 = random.Next(0, 2), B1 = random.Next(0, 2);
            int A2 = random.Next(0, 2), B2 = random.Next(0, 2);
            int A3 = random.Next(0, 2), B3 = random.Next(0, 2);
            int A4 = random.Next(0, 2), B4 = random.Next(0, 2);
            int A5 = random.Next(0, 2), B5 = random.Next(0, 2);
            int A6 = random.Next(0, 2), B6 = random.Next(0, 2);
            int A7 = random.Next(0, 2), B7 = random.Next(0, 2);
            int A8 = random.Next(0, 2), B8 = random.Next(0, 2);
            int A9 = random.Next(0, 2), B9 = random.Next(0, 2);

            //пересылаем в конструкторы соотвественные данные;
            Matrix A = new Matrix(new int[,]{ { A1, A2, A3 } , { A4, A5, A6 } , { A7, A8, A9 } });
            Matrix B = new Matrix(new int[,] { { B1, B2, B3 }, { B4, B5, B6 }, { B7, B8, B9 } });
           
            richTextBox1.Text += ($"Матрица А:" + "\n");
            richTextBox1.Text += ($"{(A)}" + " ");
            richTextBox1.Text += ("\n" + "Матрица В:" + "\n");
            richTextBox1.Text += ($"{(B)}" + " ");
            richTextBox1.Text += ("\n" + "Сумма матриц:" + "\n");
            richTextBox1.Text += ($"{(A + B)}" + " ");
            richTextBox1.Text += ("\n" + "Удвоенная матрица А:" + "\n");
            richTextBox1.Text += ($"{(2 * A)}" + " ");
            richTextBox1.Text += ("\n" + "Утроенная матрица А:" + "\n");
            richTextBox1.Text += ($"{(3 * A)}" + " ");
            richTextBox1.Text += ("\n" + "Пример 2А*(А + В):" + "\n");
            richTextBox1.Text += ($"{((2 * A) * (A + B))}" + " ");
            richTextBox1.Text += ("\n" + "Финальный пример 2А*(А + В) - 3А:" + "\n");
            richTextBox1.Text += ($"{((2 * A) * (A + B)) - (3 * A)}" + " " + "\n");

            if (Matrix.Symmetry(A, B) == true)
                richTextBox1.Text += "Матрица симметричная\n";
            else
                richTextBox1.Text += "Матрица не симметричная\n";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    class Matrix
    {
        private int row, col;
        private int[,] matrix;

        //конструкторы, принимающие соответственные данные и присваивающие значения этих данных полям класса;
        public Matrix(int row, int col)
        {
            this.row = row;
            this.col = col;
            this.matrix = new int[row, col];
        }

        public Matrix(int[,] matrix)
        {
            this.matrix = matrix;
        }

        public double this[int i, int j]
        {
            get { return matrix[i, j]; } set { matrix[i, j] = Convert.ToInt32(value); }
        }

        //представляем массив в виде строки для вывода в textbox;
        public override string ToString()
        {
            string str = "";

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    str += matrix[i, j].ToString() + "  ";
                }
                str += ("\n");
            }

            return str;
        }

        //оперыторы перегрузки, принимающие 2 массива;
        public static Matrix operator +(Matrix A, Matrix B)
        {
            Matrix result = new Matrix(3,3);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result[i, j] = A[i, j] + B[i, j];
                }
            }

            return result;
        }

        public static Matrix operator -(Matrix A, Matrix B)
        {
            Matrix result = new Matrix(3, 3);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result[i, j] = A[i, j] - B[i, j];
                }
            }

            return result;
        }

        public static Matrix operator *(Matrix A, Matrix B)
        {
            Matrix result = new Matrix(3, 3);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result[i, j] = A[i, j] * B[i, j];
                }
            }

            return result;
        }

        public static Matrix operator *(int a, Matrix A)
        {
            Matrix result = new Matrix(3, 3);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result[i, j] = A[i, j] * a;
                }
            }

            return result;
        }

        //проверка на симметричность;
        public static bool Symmetry(Matrix A, Matrix B)
        {
            int X1, X2, X3, X4, X5, X6, X7, X8, X9;
            
            X1 = Convert.ToInt32(((2 * A[0, 0]) * (A[0 , 0] + B[0, 0])) - (3 * A[0, 0]));
            X2 = Convert.ToInt32(((2 * A[0, 1]) * (A[0, 1] + B[0, 1])) - (3 * A[0, 1]));
            X3 = Convert.ToInt32(((2 * A[0, 2]) * (A[0, 2] + B[0, 2])) - (3 * A[0, 2]));
            X4 = Convert.ToInt32(((2 * A[1, 0]) * (A[1, 0] + B[1, 0])) - (3 * A[1, 0]));
            X5 = Convert.ToInt32(((2 * A[1, 1]) * (A[1, 1] + B[1, 1])) - (3 * A[1, 1]));
            X6 = Convert.ToInt32(((2 * A[1, 2]) * (A[1, 2] + B[1, 2])) - (3 * A[1, 2]));
            X7 = Convert.ToInt32(((2 * A[2, 0]) * (A[2, 0] + B[2, 0])) - (3 * A[2, 0]));
            X8 = Convert.ToInt32(((2 * A[2, 1]) * (A[2, 1] + B[2, 1])) - (3 * A[2, 1]));
            X9 = Convert.ToInt32(((2 * A[2, 2]) * (A[2, 2] + B[2, 2])) - (3 * A[2, 2]));

            if(X1 == X3 && X3 == X9 && X9 == X7 && X7 == X1)
            {
                if(X4 == X2 && X2 == X6 && X6 == X8 && X8 == X4)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
