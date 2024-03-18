using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace OOP_lab_1
{
    public class GameField : DisplayObject
    {
        public DisplayObject[] arr;
        public override void Draw(Graphics g)
        {
            Color fillColor = Color.FromArgb(_fillColor[0], _fillColor[1], _fillColor[2]);
            Color borderColor = Color.FromArgb(_borderColor[0], _borderColor[1], _borderColor[2]);
            using (var brush = new SolidBrush(fillColor))
            {
                using (var pen = new Pen(borderColor, _borderSize))
                {
                    g.FillRectangle(brush, _X1, _Y1, _X2 - _X1, _Y2 - _Y1);
                    g.DrawRectangle(pen, _X1, _Y1, _X2 - _X1, _Y2 - _Y1);
                }
            }
        }
        
        public GameField(int X, int Y, int X1, int Y1, int[] fillColor, int[] borderColor, int borderSize, int width, int heigth) : base(X, Y, X1, Y1, fillColor, borderColor, borderSize)
        {
            _X2 = X1 + width;
            _Y2 = Y1 + heigth;
            _outRectX1 = _X1 - borderSize / 2;
            _outRectY1 = _Y1 - borderSize / 2;
            _outRectX2 = _X2 + borderSize / 2;
            _outRectY2 = _Y2 + borderSize / 2;
            _inRectX1 =  _outRectX1 + borderSize;
            _inRectY1 = _outRectY1 + borderSize;
            _inRectX2 = _outRectX2 - borderSize;
            _inRectY2 = _outRectY2 - borderSize;
        }

        private static void DeleteObject(DisplayObject[] arrObj, DisplayObject obj)
        {
            int index = Array.IndexOf(arrObj, obj);
            for (int i = index; i < arrObj.Length - 1; i++)
            {
                arrObj[i] = arrObj[i + 1];
            }
            arrObj[arrObj.Length - 1] = null;
        }

        private static void AddCircle(int index, int minX, int maxX, int minY, int maxY, int offsetX, int offsetY, int minB, int maxB, DisplayObject[] arrObj, Random rand)
        {
            int x = rand.Next(minX, maxX);
            int y = rand.Next(minY, maxY);
            int x2 = rand.Next(minX, maxX);
            int y2 = rand.Next(minY, maxY);
            Section f1 = new Section(offsetX + x, offsetY + y,  offsetX + x, offsetY + y, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)},
                new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, rand.Next(minB, maxB),
                offsetX + x2, offsetY + y2, rand.Next(1, 10));
            arrObj[index] = f1;
        }
        private static void AddEllipse(int index, int minX, int maxX, int minY, int maxY, int offsetX, int offsetY, int minB, int maxB, DisplayObject[] arrObj, Random rand)
        {
            int x = rand.Next(minX, maxX);
            int y = rand.Next(minY, maxY);
            Ellipse f1 = new Ellipse(offsetX + x, offsetY + y, offsetX + x, offsetY + y, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)},
                new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, rand.Next(1, 10),
                rand.Next(10, 100), rand.Next(10,100));
            arrObj[index] = f1;
        }
        private static void AddEquilateralTriangle(int index, int minX, int maxX, int minY, int maxY, int offsetX, int offsetY, int minB, int maxB, DisplayObject[] arrObj, Random rand)
        {
            int x = rand.Next(minX, maxX);
            int y = rand.Next(minY, maxY);
            EquilateralTriangle f1 = new EquilateralTriangle(offsetX + x, offsetY + y, offsetX + x, offsetY + y, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)},
                new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, rand.Next(1, 10),
                rand.Next(10,100));
            arrObj[index] = f1;
        }
        private static void AddIsoscelesTriangle(int index, int minX, int maxX, int minY, int maxY, int offsetX, int offsetY, int minB, int maxB, DisplayObject[] arrObj, Random rand)
        {
            int x = rand.Next(minX, maxX);
            int y = rand.Next(minY, maxY);
            IsoscelesTriangle f1 = new IsoscelesTriangle(offsetX + x, offsetY + y, offsetX + x, offsetY + y, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)},
                new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, rand.Next(1, 10),
                rand.Next(10,100), rand.Next(10,100));
            arrObj[index] = f1;
        }
        private static void AddRectangle(int index, int minX, int maxX, int minY, int maxY, int offsetX, int offsetY, int minB, int maxB, DisplayObject[] arrObj, Random rand)
        {
            int x = rand.Next(minX, maxX);
            int y = rand.Next(minY, maxY);
            Rectangle f1 = new Rectangle(offsetX + x, offsetY + y, offsetX + x, offsetY + y, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)},
                new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, rand.Next(1, 10),
                rand.Next(10,100), rand.Next(10,100));
            arrObj[index] = f1;
        }
        private static void AddSection(int index, int minX, int maxX, int minY, int maxY, int offsetX, int offsetY, int minB, int maxB, DisplayObject[] arrObj, Random rand)
        {
            int x = rand.Next(minX, maxX);
            int y = rand.Next(minY, maxY);
            int x2 = rand.Next(minX, maxX);
            int y2 = rand.Next(minY, maxY);
            Section f1 = new Section(offsetX + x, offsetY + y, offsetX + x, offsetY + y, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)},
                new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, rand.Next(1, 4),
                x2, y2, rand.Next(5,10));
            arrObj[index] = f1;
        }
        private static void AddSquare(int index, int minX, int maxX, int minY, int maxY, int offsetX, int offsetY, int minB, int maxB, DisplayObject[] arrObj, Random rand)
        {
            int x = rand.Next(minX, maxX);
            int y = rand.Next(minY, maxY);
            Square f1 = new Square(offsetX + x, offsetY + y, offsetX + x, offsetY + y, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)},
                new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, rand.Next(1, 10),
                rand.Next(10, 100));
            arrObj[index] = f1;
        }
        private static void AddTriangle(int index, int minX, int maxX, int minY, int maxY, int offsetX, int offsetY, int minB, int maxB, DisplayObject[] arrObj, Random rand)
        {
            int x = rand.Next(minX, maxX);
            int y = rand.Next(minY, maxY);
            int pMinX = x - 100;
            int pMaxX = x + 100;
            int pMinY = y - 100;
            int pMaxY = y + 100;
            Triangle f1 = new Triangle(offsetX + x, offsetY + y, offsetX + x, offsetY + y, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)},
                new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, rand.Next(1, 10),
                rand.Next(pMinX, pMaxX), rand.Next(pMinY, pMaxY), rand.Next(pMinX, pMaxX), rand.Next(pMinY, pMaxY));
            arrObj[index] = f1;
        }
        
        public static GameField GenerateObjects(int width, int height, int minX, int minY, int maxX, int maxY)
        {
            int offsetX = 0;
            int offsetY = 0;
            int index = 0;  //индекс для заполнения массива фигурами
            Random rand = new Random();
            int x;
            int y;
            
            const int minB = 1;
            const int maxB = 10;

            offsetX = 10;
            offsetY = 10;
            GameField gameField = new GameField(offsetX, offsetY,offsetX, offsetY, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, 1, width, height);
            gameField.arr = new DisplayObject[10 * 8];
            
            for (int i = 0; i < 10; i++)
            {
                AddCircle(index, minX, maxX, minY, maxY, offsetX, offsetY, minB, maxB, gameField.arr, rand);
                index++;
            }
            for (int i = 0; i < 10; i++)
            {
                AddEllipse(index, minX, maxX, minY, maxY, offsetX, offsetY, minB, maxB, gameField.arr, rand);
                index++;
            }
            for (int i = 0; i < 10; i++)
            {
                AddEquilateralTriangle(index, minX, maxX, minY, maxY, offsetX, offsetY, minB, maxB, gameField.arr, rand);
                index++;
            }
            for (int i = 0; i < 10; i++)
            {
                AddIsoscelesTriangle(index, minX, maxX, minY, maxY, offsetX, offsetY, minB, maxB, gameField.arr, rand);
                index++;
            }
            for (int i = 0; i < 10; i++)
            {
                AddRectangle(index, minX, maxX, minY, maxY, offsetX, offsetY, minB, maxB, gameField.arr, rand);
                index++;
            }
            for (int i = 0; i < 10; i++)
            {
                AddSection(index, minX, maxX, minY, maxY, offsetX, offsetY, minB, maxB, gameField.arr, rand);
                index++;
            }
            for (int i = 0; i < 10; i++)
            {
                AddSquare(index, minX, maxX, minY, maxY, offsetX, offsetY, minB, maxB, gameField.arr, rand);
                index++;
            }
            for (int i = 0; i < 10; i++)
            {
                AddTriangle(index, minX, maxX, minY, maxY, offsetX, offsetY, minB, maxB, gameField.arr, rand);
                index++;
            }
            return gameField;
        }
    }
}