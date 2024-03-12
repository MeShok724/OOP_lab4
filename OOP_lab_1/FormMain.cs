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
        }

        public DisplayObject[] GenerateObjects()
        {
            DisplayObject[] objectArr = new DisplayObject[10*8 + 1];
            int index = 0;
            Random rand = new Random();
            int x;
            int y;
            
            const int minX = 20;
            const int minY = 20;
            const int maxX = 1100;
            const int maxY = 700;
            const int minB = 1;
            const int maxB = 10;

            DrawField drawField = new DrawField(10, 10, Color.White, Color.White, 0, 1158, 724);
            objectArr[index++] = drawField;
            for (int i = 0; i < 10; i++)
            {
                x = rand.Next(minX, maxX);
                y = rand.Next(minY, maxY);
                int x2 = rand.Next(minX, maxX);
                int y2 = rand.Next(minY, maxY);
                Section f1 = new Section(x, y, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),
                    Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), rand.Next(minB, maxB),
                    x2, y2, rand.Next(1, 10));
                objectArr[index++] = f1;
            }
            
            for (int i = 0; i < 10; i++)
            {
                x = rand.Next(minX, maxX);
                y = rand.Next(minY, maxY);
                int pMinX = x - 100;
                int pMaxX = x + 100;
                int pMinY = y - 100;
                int pMaxY = y + 100;
                Triangle f1 = new Triangle(x, y, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),
                    Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), rand.Next(1, 10),
                    rand.Next(pMinX, pMaxX), rand.Next(pMinY, pMaxY), rand.Next(pMinX, pMaxX), rand.Next(pMinY, pMaxY));
                objectArr[index++] = f1;
            }
            for (int i = 0; i < 10; i++)
            {
                x = rand.Next(minX, maxX);
                y = rand.Next(minY, maxY);
                Circle f1 = new Circle(x, y, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),
                    Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), rand.Next(1, 10),
                    rand.Next(10, 100));
                objectArr[index++] = f1;
            }
            for (int i = 0; i < 10; i++)
            {
                x = rand.Next(minX, maxX);
                y = rand.Next(minY, maxY);
                Square f1 = new Square(x, y, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),
                    Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), rand.Next(1, 10),
                    rand.Next(10, 100));
                objectArr[index++] = f1;
            }
            for (int i = 0; i < 10; i++)
            {
                x = rand.Next(minX, maxX);
                y = rand.Next(minY, maxY);
                Ellipse f1 = new Ellipse(x, y, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),
                    Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), rand.Next(1, 10),
                    rand.Next(10, 100), rand.Next(10,100));
                objectArr[index++] = f1;
            }
            for (int i = 0; i < 10; i++)
            {
                x = rand.Next(minX, maxX);
                y = rand.Next(minY, maxY);
                IsoscelesTriangle f1 = new IsoscelesTriangle(x, y, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),
                    Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), rand.Next(1, 10),
                    rand.Next(10,100), rand.Next(10,100));
                objectArr[index++] = f1;
            }
            for (int i = 0; i < 10; i++)
            {
                x = rand.Next(minX, maxX);
                y = rand.Next(minY, maxY);
                EquilateralTriangle f1 = new EquilateralTriangle(x, y, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),
                    Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), rand.Next(1, 10),
                    rand.Next(10,100));
                objectArr[index++] = f1;
            }
            for (int i = 0; i < 10; i++)
            {
                x = rand.Next(minX, maxX);
                y = rand.Next(minY, maxY);
                Rectangle f1 = new Rectangle(x, y, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),
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