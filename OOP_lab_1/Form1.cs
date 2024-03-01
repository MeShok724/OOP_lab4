using System;
using System.Drawing;
using System.Windows.Forms;

namespace OOP_lab_1
{
    public partial class Form1 : Form
    {
        private Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Point point = new Point();
            point.X = 200;
            point.Y = 200;
            Triangle f1 = new Triangle(point, Color.Blue, Color.Red, 10, new Point(150, 300), new Point(170, 200));
            f1.Draw(g);
            // Circle figure1 = new Circle(point, Color.Blue, Color.Red, 10, 50);
            // Section figure5 = new Section(point, Color.Blue, Color.Red, 5, new Point(250, 150), 5);
            // figure5.Draw(g);
            // // figure1.Draw(g);
            // g.DrawLine(new Pen(Color.Black),100, 140, 300, 140);
            // g.DrawLine(new Pen(Color.Black),140, 100, 140, 250);
            // point.X = 400;
            // point.Y = 150;
            // Rectangle figure2 = new Rectangle(point, Color.Blue, Color.Red, 1, 100, 100);
            // figure2.Draw(g);
            // point.X = 200;
            // point.Y = 400;
            // IsoscelesTriangle figure3 = new IsoscelesTriangle(point, Color.Blue, Color.Red, 1, 100, 200);
            // figure3.Draw(g);
            // g.DrawLine(new Pen(Color.Black),200, 400 -4, 300, 400-4);
            // g.DrawLine(new Pen(Color.Black),200-2, 400, 200-2, 700);
            // g.DrawLine(new Pen(Color.Black),200, 601, 300, 601);
            // point.X = 400;
            // point.Y = 400;
            // EquilateralTriangle figure4 = new EquilateralTriangle(point, Color.Blue, Color.Red, 1, 100);
            // figure4.Draw(g);
        }
    }
}