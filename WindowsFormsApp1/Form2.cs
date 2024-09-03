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
    public partial class Form2 : Form
    {

        private double[,] matrix;
        double[] solve1, solve2;
        int countGame;


        public Form2(double[,] matrix,double[] solve1,double[] solve2,int countGame)
        {
            InitializeComponent();
            this.matrix = matrix;
            this.solve1 = solve1;
            this.solve2 = solve2;
            this.countGame = countGame;
            makeGrid();

            string x = "";
            foreach (double i in solve1)
            {
                x += i.ToString() + "   ";
            }
            textBox1.Text = x;
            x = "";
            foreach (double i in solve2)
            {
                x += i.ToString() + "   ";
            }
            textBox2.Text = x;
        }

        private void makeGrid()
        {
            dataGridView1.RowCount = countGame+1;
            dataGridView1.ColumnCount = 8;

            dataGridView1[0, 0].Value = "Номер партії";
            dataGridView1[1, 0].Value = "Випадкове\r\nчисло гравця\r\nА";
            dataGridView1[2, 0].Value = "Стратегія\r\nгравця\r\nА";
            dataGridView1[3, 0].Value = "Випадкове\r\nчисло гравця\r\nВ";
            dataGridView1[4, 0].Value = "Стратегія\r\nгравця В";
            dataGridView1[5, 0].Value = "Виграш А";
            dataGridView1[6, 0].Value = "Накопичений\r\nвиграш А";
            dataGridView1[7, 0].Value = "Середній\r\nвиграш А\r\n(ціна гри)";
            Random r=new Random();
            double r1,r2;
            int strategy1=-1,strategy2=-1;
            double win=0;
            for (int i = 0; i < countGame; i++)
            {
                dataGridView1[0, i+1].Value = i+1;

                r1=r.NextDouble();
                dataGridView1[1, i+1].Value = r1;

                double sum = 0;
                for(int j = 0; j < solve1.Length;j++)
                {
                    sum+= solve1[j];
                    if (sum > r1)
                    {
                        strategy1 = j;
                        break;
                    }
                }
                dataGridView1[2, i+1].Value = strategy1+1;

                r2 = r.NextDouble();
                dataGridView1[3, i + 1].Value = r1;

                sum = 0;
                for (int j = 0; j < solve2.Length; j++)
                {
                    sum += solve2[j];
                    if (sum > r2)
                    {
                        strategy2 = j;
                        break;
                    }
                }
                dataGridView1[4, i+1].Value = strategy2 + 1;

                dataGridView1[5, i + 1].Value = matrix[strategy1, strategy2];

                win+= matrix[strategy1, strategy2];
                dataGridView1[6, i + 1].Value = win;
                dataGridView1[7, i + 1].Value = win/(i+1);
            }
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
