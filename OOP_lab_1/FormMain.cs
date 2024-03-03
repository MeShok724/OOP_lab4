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

        public DisplayObject[] GenerateObjects()
        {
            DisplayObject[] objectArr = new DisplayObject[10*8];
            int index = 0;
            Random rand = new Random();
            Point point = new Point();
            
            for (int i = 0; i < 10; i++)
            {
                point.X = rand.Next(20, 1400);
                point.Y = rand.Next(20, 600);
                Section f1 = new Section(point, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),
                    Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), rand.Next(1, 5),
                    new Point(rand.Next(50, 1300), rand.Next(50, 500)), rand.Next(1, 10));
                objectArr[index++] = f1;
            }
            
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
                objectArr[index++] = f1;
            }
            for (int i = 0; i < 10; i++)
            {
                point.X = rand.Next(110, 1300);
                point.Y = rand.Next(110, 600);
                Circle f1 = new Circle(point, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),
                    Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), rand.Next(1, 10),
                    rand.Next(10, 100));
                objectArr[index++] = f1;
            }
            for (int i = 0; i < 10; i++)
            {
                point.X = rand.Next(20, 1300);
                point.Y = rand.Next(20, 600);
                Square f1 = new Square(point, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),
                    Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), rand.Next(1, 10),
                    rand.Next(10, 100));
                objectArr[index++] = f1;
            }
            for (int i = 0; i < 10; i++)
            {
                point.X = rand.Next(110, 1300);
                point.Y = rand.Next(110, 600);
                Ellipse f1 = new Ellipse(point, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),
                    Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), rand.Next(1, 10),
                    rand.Next(10, 100), rand.Next(10,100));
                objectArr[index++] = f1;
            }
            for (int i = 0; i < 10; i++)
            {
                point.X = rand.Next(60, 1300);
                point.Y = rand.Next(60, 600);
                IsoscelesTriangle f1 = new IsoscelesTriangle(point, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),
                    Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), rand.Next(1, 10),
                    rand.Next(10,100), rand.Next(10,100));
                objectArr[index++] = f1;
            }
            for (int i = 0; i < 10; i++)
            {
                point.X = rand.Next(20, 1300);
                point.Y = rand.Next(20, 600);
                EquilateralTriangle f1 = new EquilateralTriangle(point, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),
                    Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), rand.Next(1, 10),
                    rand.Next(10,100));
                objectArr[index++] = f1;
            }
            for (int i = 0; i < 10; i++)
            {
                point.X = rand.Next(20, 1300);
                point.Y = rand.Next(20, 600);
                Rectangle f1 = new Rectangle(point, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),
                    Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), rand.Next(1, 10),
                    rand.Next(10,100), rand.Next(10,100));
                objectArr[index++] = f1;
            }

            return objectArr;
        }

        private void DrawObjects(DisplayObject[] arr, Graphics graphic)
        {
            foreach (var currObj in arr)
            {
                currObj.Draw(graphic);
            }
        }

        private void pbDrawField_Click(object sender, EventArgs e)
        {
            g = pbDrawField.CreateGraphics();
            g.Clear(Color.White);
            DisplayObject[] objects = GenerateObjects();
            DrawObjects(objects, g);
        }
    }
}