using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework_7
{
    public partial class Form1 : Form
    {
        double t;
        
        private Graphics graphics;
       
        double th2 = 30 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.LightBlue;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            t = trackBar1.Value;
            int m = comboBox1.SelectedIndex;
            int n = int.Parse(textBox1.Text);
            if (graphics == null) graphics = this.CreateGraphics();
            graphics.Clear(this.BackColor);
            drawCayleyTree(n, 100, 200, 50, -Math.PI / 2,m);

        }

        void drawCayleyTree(int n, double x0, double y0, double leng, double th,int col_num)
        {
            double th1 = t * Math.PI / 180;
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            drawLine(x0, y0, x1, y1,col_num);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1, col_num);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th - th2, col_num);
        }
        void drawLine(double x0, double y0, double x1, double y1,int col_num)
        {
            switch (col_num)
            {
                case 0:
                    graphics.DrawLine(Pens.Red, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case 1:
                    graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case 2:
                    graphics.DrawLine(Pens.Yellow, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case 3:
                    graphics.DrawLine(Pens.Green, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case 4:
                    graphics.DrawLine(Pens.LightBlue, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
            }               
        }


        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
