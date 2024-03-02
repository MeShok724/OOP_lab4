using System;
using System.Drawing;
using System.Windows.Forms;

namespace OOP_lab_1
{
    public partial class FormMain : Form
    {
        public Graphics g;
        public FormMain()
        {
            InitializeComponent();
            Width = 1500;
            Height = 800;
        }

        public void DrawObjects()
        {
            Random rand = new Random();
            Point point = new Point();
            
            
            
            for (int i = 0; i < 10; i++)
            {
                point.X = rand.Next(150, 1300);
                point.Y = rand.Next(150, 500);
                int pMinX = point.X - 100;
                int pMaxX = point.X + 100;
                int pMinY = point.Y - 100;
                int pMaxY = point.Y + 100;
                Triangle f1 = new Triangle(point, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),
                    Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), rand.Next(1, 10),
                    new Point(rand.Next(pMinX, pMaxX), rand.Next(pMinY, pMaxY)), new Point(rand.Next(pMinX, pMaxX), rand.Next(pMinY, pMaxY)));
                f1.Draw(g);
            }
            for (int i = 0; i < 10; i++)
            {
                point.X = rand.Next(110, 1300);
                point.Y = rand.Next(110, 600);
                Circle f1 = new Circle(point, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),
                    Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), rand.Next(1, 10),
                    rand.Next(10, 100));
                f1.Draw(g);
            }
            for (int i = 0; i < 10; i++)
            {
                point.X = rand.Next(20, 1300);
                point.Y = rand.Next(20, 600);
                Square f1 = new Square(point, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),
                    Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), rand.Next(1, 10),
                    rand.Next(10, 100));
                f1.Draw(g);
            }
            for (int i = 0; i < 10; i++)
            {
                point.X = rand.Next(110, 1300);
                point.Y = rand.Next(110, 600);
                Ellipse f1 = new Ellipse(point, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),
                    Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), rand.Next(1, 10),
                    rand.Next(10, 100), rand.Next(10,100));
                f1.Draw(g);
            }
            for (int i = 0; i < 10; i++)
            {
                point.X = rand.Next(60, 1300);
                point.Y = rand.Next(60, 600);
                IsoscelesTriangle f1 = new IsoscelesTriangle(point, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),
                    Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), rand.Next(1, 10),
                    rand.Next(10,100), rand.Next(10,100));
                f1.Draw(g);
            }
            for (int i = 0; i < 10; i++)
            {
                point.X = rand.Next(20, 1300);
                point.Y = rand.Next(20, 600);
                EquilateralTriangle f1 = new EquilateralTriangle(point, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),
                    Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), rand.Next(1, 10),
                    rand.Next(10,100));
                f1.Draw(g);
            }
            for (int i = 0; i < 10; i++)
            {
                point.X = rand.Next(20, 1300);
                point.Y = rand.Next(20, 600);
                Rectangle f1 = new Rectangle(point, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),
                    Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), rand.Next(1, 10),
                    rand.Next(10,100), rand.Next(10,100));
                f1.Draw(g);
            }
            for (int i = 0; i < 10; i++)
            {
                point.X = rand.Next(20, 1400);
                point.Y = rand.Next(20, 600);
                Section f1 = new Section(point, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),
                    Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), rand.Next(1, 5),
                    new Point(rand.Next(50, 1300), rand.Next(50, 500)), rand.Next(1, 10));
                f1.Draw(g);
            }
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

        private void pbDrawField_Click(object sender, EventArgs e)
        {
            g = pbDrawField.CreateGraphics();
            g.Clear(Color.Aqua);
            DrawObjects();
        }
    }
}