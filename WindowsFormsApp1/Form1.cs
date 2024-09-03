using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Security.Policy;
using System.IO;
using System.Globalization;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        StreamWriter sw;
        private double[,] matrix;
        private double[,] matrixWithoutZW;
        private double[] yArray;
        private double[] xArray;
        private double[] uArray;
        private double[] vArray;
        private double[] solve1;
        private double[] solve2;
        int sizeX;
        int sizeY;


        private void buttonSolve_Click(object sender, EventArgs e)
        {
            if (checkBoxWriteFile.Checked)
            {
                sw = new StreamWriter(@"D:\result.txt");
            }
            makeMatrix();
            sizeX = matrix.GetLength(0);
            sizeY = matrix.Length / matrix.GetLength(0);

            matrixWithoutZW = new double[sizeX - 1, sizeY - 1];

            for (int j = 0; j < sizeY - 1; j++)
            {
                for (int i = 0; i < sizeX - 1; i++)
                {
                    matrixWithoutZW[i, j] = matrix[i, j];
                }
            }

            if (cleanStrategy(matrixWithoutZW, sizeX - 1, sizeY - 1))
            {
                MessageBox.Show("Є чисті стратегії");
                if (checkBoxWriteFile.Checked)
                {
                    sw.WriteLine("Є чисті стратегії");
                }
            }
            else
            {
                MessageBox.Show("Чистих стратегій не знайдено");
                if (checkBoxWriteFile.Checked)
                {
                    sw.WriteLine("Чистих стратегій не знайдено");
                }
                if (sizeX == 3 && sizeY == 3)
                {
                    analiticSolve();
                }

                else if (sizeX == sizeY)
                {
                    MessageBox.Show("Пошук змішаних стратегій симлекс методом");
                    if (checkBoxWriteFile.Checked)
                    {
                        sw.WriteLine("Пошук змішаних стратегій симлекс методом");
                    }
                    siticsmetod();
                }
            
            }
            if (checkBoxWriteFile.Checked)
            {
                sw.Close();
            }
        }
        private void analiticSolve()
        {
            MessageBox.Show("Аналітичний розв'язок задачі 2х2");
            if (checkBoxWriteFile.Checked)
            {
                sw.WriteLine("Аналітичний розв'язок задачі 2х2");
            }

            double x1 = (matrix[1, 0] - matrix[0, 0]) / (-matrix[0, 0] + matrix[0, 1] + matrix[1, 0] - matrix[1, 1]);
            double x2 = 1 - x1;

            double y1 = (matrix[0, 1] - matrix[0, 0]) / (-matrix[0, 0] + matrix[0, 1] + matrix[1, 0] - matrix[1, 1]);
            double y2 = 1 - y1;

            solve1 = new double[2];
            solve2 = new double[2];

            solve1[0] = x1;
            solve2[0] = y1;
            solve1[1] = x2;
            solve2[1] = y2;

            textBoxX.Text = x1.ToString() + " " + x2.ToString();
            if (checkBoxWriteFile.Checked)
            {
                sw.WriteLine($"стратегії I гравця: {x1} {x2}");
            }
            textBoxU.Text = y1.ToString() + " " + y2.ToString();
            if (checkBoxWriteFile.Checked)
            {
                sw.WriteLine($"стратегії II гравця: {y1} {y2}");
            }
            double cost = matrix[0, 0] * x1 + matrix[0, 1] * x2;
            if (checkBoxWriteFile.Checked)
            {
                sw.WriteLine($"Ціна гри={cost}");
            }
            textBoxMax.Text = cost.ToString();

        }
        private bool cleanStrategy(double[,] matrix,int sizeX,int sizeY)
        {
            double[] minInColumn = new double[sizeY];
            double[] maxInRow = new double[sizeX];
            double maxElement=Double.MinValue;
            double minElement=Double.MaxValue;

            for (int j = 0; j < sizeY; j++)
            {
                double min= Double.MaxValue;
                for (int i = 0; i < sizeX; i++)
                {
                    if (matrix[i,j]<min)
                    {
                        min = matrix[i,j];
                        minInColumn[j] = min;
                    }
                }
            }

            for(int i = 0; i < minInColumn.Length; i++)
            {
                if (minInColumn[i] >maxElement) maxElement = minInColumn[i];
            }

            for (int j = 0; j < sizeY; j++)
            {
                double max = Double.MinValue;
                for (int i = 0; i < sizeX; i++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxInRow[j] = max;
                    }
                }
            }

            for (int i = 0; i < maxInRow.Length; i++)
            {
                if (maxInRow[i] < minElement) minElement = maxInRow[i];
            }

            if (minElement == maxElement)
            {
                return true;
            }

            return false;
        }

        double[,] g(double[,] matrix, int piviotX, int piviotY, int sizeX, int sizeY)
        {

            double pivot = matrix[piviotX, piviotY];

            double[,] newMatrix = new double[sizeX, sizeY];

            newMatrix[piviotX, piviotY] = 1;
            //изменения всех вертикальних
            for (int i = 0; i < sizeY; i++)
            {
                if (i != piviotY)
                {
                    newMatrix[piviotX, i] = -matrix[piviotX, i];
                }
            }
            //горизонтальх и изменения знака
            for (int i = 0; i < sizeX; i++)
            {
                if (i != piviotX)
                {
                    newMatrix[i, piviotY] = matrix[i, piviotY];
                }
            }


            //bij= aijars−aisarj
            for (int j = 0; j < sizeY; j++)
            {
                for (int i = 0; i < sizeX; i++)
                {
                    if (i != piviotX && j != piviotY)
                    {
                        newMatrix[i, j] = matrix[i, j] * matrix[piviotX, piviotY] - matrix[i, piviotY] * matrix[piviotX, j];
                    }
                }
            }
            //диления всех єлементов
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    newMatrix[i, j] = newMatrix[i, j] / pivot;
                }
            }

            double temp = xArray[piviotX];
            xArray[piviotX] = yArray[piviotY];
            yArray[piviotY] = temp;
            temp = vArray[piviotX];
            vArray[piviotX] = uArray[piviotY];
            uArray[piviotY] = temp;

            return newMatrix;
        }

        double[,] findOpSolve(double[,] matrix, int sizeX, int sizeY)
        {
            bool isNegative;
            do
            {
                isNegative = false;
                int negativePosY = -1;
                int negativePosX = -1;
                for (int i = 0; i < sizeY - 1; i++)
                {
                    if (matrix[sizeX - 1, i] < 0)
                    {
                        isNegative = true;
                        negativePosY = i;
                        break;
                    }
                }
                if (!isNegative)
                {
                    if (checkBoxWriteFile.Checked)
                    {
                        sw.WriteLine("Опорний розв’язок знайдено");
                    }
                    return matrix;
                }

                isNegative = false;
                for (int i = 0; i < sizeX - 1; i++)
                {
                    if (matrix[i, negativePosY] < 0)
                    {
                        isNegative = true;
                        negativePosX = i;
                        break;
                    }
                }
                if (!isNegative)
                {
                    if (checkBoxWriteFile.Checked)
                    {
                        MessageBox.Show("Система обмежень є суперечливою");
                        sw.WriteLine("Система обмежень є суперечливою");
                    }
                    return null;
                }

                double[] solveRow = new double[sizeY - 1];

                for (int i = 0; i < sizeY - 1; i++)
                {
                    solveRow[i] = matrix[sizeX - 1, i] / matrix[negativePosX, i];
                }

                double min = double.MaxValue;
                int minPos = -1;
                for (int i = 0; i < sizeY - 1; i++)
                {
                    if (solveRow[i] > 0 && solveRow[i] < min)
                    {
                        min = solveRow[i];
                        minPos = i;
                    }
                }
                if (checkBoxWriteFile.Checked)
                {
                    fileWrite(matrix, sizeX, sizeY);
                }
                matrix = g(matrix, negativePosX, minPos, sizeX, sizeY);
                if (checkBoxWriteFile.Checked)
                {
                    fileWrite(matrix, sizeX, sizeY);
                }

            } while (isNegative);

            return null;
        }
        double[,] findOptiSolve(double[,] matrix, int sizeX, int sizeY)
        {
            bool isNegative;
            do
            {
                isNegative = false;
                int negativePosX = -1;
                for (int i = 0; i < sizeX - 1; i++)
                {
                    if (matrix[i, sizeY - 1] < 0)
                    {
                        isNegative = true;
                        negativePosX = i;
                        break;
                    }
                }
                if (!isNegative)
                {
                    if (checkBoxWriteFile.Checked)
                    {
                        sw.WriteLine("Оптимальний розв’язок знайдено");
                    }
                    return matrix;
                }

                double[] solveRow = new double[sizeY - 1];

                for (int i = 0; i < sizeY - 1; i++)
                {
                    solveRow[i] = matrix[sizeX - 1, i] / matrix[negativePosX, i];
                }

                double min = double.MaxValue;
                int minPos = -1;
                for (int i = 0; i < sizeY - 1; i++)
                {
                    if (solveRow[i] >= 0 && solveRow[i] < min)
                    {
                        min = solveRow[i];
                        minPos = i;
                    }
                }
                if (minPos == -1)
                {
                    MessageBox.Show("«Функція мети не обмежена зверху»");
                    if (checkBoxWriteFile.Checked)
                    {
                        sw.WriteLine("«Функція мети не обмежена зверху»");
                    }
                    return null;
                }

                matrix = g(matrix, negativePosX, minPos, sizeX, sizeY);
                if (checkBoxWriteFile.Checked)
                {
                    fileWrite(matrix, sizeX, sizeY);
                }

            } while (isNegative);
            return null;
        }
        private void siticsmetod()
        {
            xArray = new double[sizeX - 1];
            vArray = new double[sizeX - 1];
            uArray = new double[sizeY - 1];

            int resultSize = sizeX;

            for (int i = 0; i < sizeX - 1; i++)
            {
                xArray[i] = 10 + i + 1;
                vArray[i] = 30 + i + 1;
            }
            for (int i = 0; i < sizeY - 1; i++)
            {
                uArray[i] = 50 + i + 1;
            }


            if (checkBoxWriteFile.Checked)
            {
                sw.WriteLine("Початкова матриця");
                fileWrite(matrix, sizeX, sizeY);
                sw.WriteLine("---------------------------------------------------------");
            }
            double[,] newMatrix = matrix;

            newMatrix = findOpSolve(newMatrix, sizeX, sizeY);
            double[] solveX;
            double[] solveV;
            if (matrix != null)
            {
                solveX = new double[resultSize - 1];

                for (int i = 0; i < sizeY - 1; i++)
                {
                    if (yArray[i] / 20 < 1)
                    {
                        solveX[(int)yArray[i] % 10 - 1] = newMatrix[sizeX - 1, i];
                    }
                }

                string x = "";
                foreach (double i in solveX)
                {
                    x += i.ToString() + " ";
                }
                if (checkBoxWriteFile.Checked)
                {
                    sw.WriteLine($"Розв'язок " + x + " ");
                    sw.WriteLine("---------------------------------------------------------");
                }
            }

            newMatrix = findOptiSolve(newMatrix, sizeX, sizeY);
            if (newMatrix != null)
            {

                textBoxMax.Text = newMatrix[sizeX - 1, sizeY - 1].ToString();
                solveX = new double[resultSize - 1];
                solveV = new double[sizeY - 1];
               
                for (int i = 0; i < sizeY - 1; i++)
                {
                    if (yArray[i] / 20 < 1)
                    {
                        solveX[(int)yArray[i] % 10 - 1] = newMatrix[sizeX - 1, i];
                    }
                }
                for (int i = 0; i < vArray.Length; i++)
                {
                    if (vArray[i] / 50 > 1)
                    {
                        solveV[(int)vArray[i] % 50 - 1] = newMatrix[i, sizeY - 1];
                    }
                }


                double sum = 0;
                string x = "";
                foreach (double i in solveX)
                {
                    sum += i;
                    x += i.ToString() + " ";
                }
                if (checkBoxWriteFile.Checked)
                {
                    sw.WriteLine($"Розв'язок X: " + x + " ");
                    sw.WriteLine("---------------------------------------------------------");
                }
                for(int i = 0; i < solveX.Length; i++)
                {
                    solveX[i] = solveX[i] / sum;
                }
                x = "";
                foreach (double i in solveX)
                {
                    x += i.ToString() + " ";
                }
                if (checkBoxWriteFile.Checked)
                {
                    sw.WriteLine($"Стратегії гравця 1: " + x + " ");
                    sw.WriteLine("---------------------------------------------------------");
                }
                solve1 = solveX;
                textBoxX.Text = x;
               
                x = "";
                sum= 0;
                foreach (double i in solveV)
                {
                    sum += i;
                    x += i.ToString() + " ";
                }
                if (checkBoxWriteFile.Checked)
                {
                    sw.WriteLine($"Розв'язок U: " + x + " ");
                    sw.WriteLine("---------------------------------------------------------");
                }
                for (int i = 0; i < solveV.Length; i++)
                {
                    solveV[i] = solveV[i] / sum;
                }
                x = "";
                foreach (double i in solveV)
                {
                    x += i.ToString() + " ";
                }
                if (checkBoxWriteFile.Checked)
                {
                    sw.WriteLine($"Стратегії гравця 2: " + x + " ");
                    sw.WriteLine("---------------------------------------------------------");
                }
                solve2 = solveV;
                textBoxU.Text = x;

                if (checkBoxWriteFile.Checked)
                {
                    sw.WriteLine($"Ціна гри " + textBoxMax.Text + " ");
                    sw.WriteLine("---------------------------------------------------------");
                }
            }
        }
        private void makeMatrix()
        {
            string[] equlense = textBoxSystem.Text.Split('\n');
            matrix = new double[(int)numericUpDownXCount.Value + 1, equlense.Length + 1];
            yArray = new double[equlense.Length];
            for (int j = 0; j < equlense.Length; j++)
            {
                string[] line = equlense[j].Split(' ');
                for(int i = 0; i < line.Length; i++)
                {
                    matrix[i, j] =Double.Parse(line[i]);
                }
            }
            for (int i = 0; i < equlense.Length; i++)
            {
                matrix[(int)numericUpDownXCount.Value, i] = 1;
            }

                for (int i = 0; i < numericUpDownXCount.Value; i++)
            {
                matrix[i, equlense.Length] = -1;
                yArray[i] = 21 + i;
              
            }
        }
        private void fileWrite(double[,] matrix, int sizeX, int sizeY)
        {
            string line = "";
            line += "       ";
            for (int i = 0; i < sizeX - 1; i++)
            {
                line += vArray[i] + "   ";
            }
            line += "  W \n";
            line += "       ";
            for (int i = 0; i < sizeX-1; i++)
            {
                line +=xArray[i]+"   ";
            }
            line += "  1 \n";

            line += "_______________________\n";
            for (int j = 0; j < sizeY-1; j++)
            {
                line += uArray[j] +" "+yArray[j]+" |";
                for (int i = 0; i < sizeX; i++)
                {
                    line += " " + matrix[i, j] + " ";
                }
                line += "\n";
            }
            line += "        ";
            for (int i = 0; i < sizeX ; i++)
            {
                line += matrix[i,sizeY-1] + "  ";
            }

            sw.WriteLine(line);
           
        }

        private void buttonModel_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(matrixWithoutZW,solve1,solve2,(int)numericUpDownGameCount.Value);
            form2.Show();
            this.Hide();
        }
    }
}
