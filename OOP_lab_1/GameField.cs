using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace OOP_lab_1
{
    public class GameField : Rectangle
    {
        public DisplayObject[] arr;
        
        public GameField(int X, int Y, int X1, int Y1, int[] fillColor, int[] borderColor, int borderSize, int width, int heigth) : base(X, Y, X1, Y1, fillColor, borderColor, borderSize, width, heigth)
        {
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

        private static void AddCircle(int index, int minX, int minY, int maxX, int maxY, int minB, int maxB, DisplayObject[] arrObj, Random rand)
        {
            int x = rand.Next(minX, maxX);
            int y = rand.Next(minY, maxY);
            int x2 = rand.Next(minX, maxX);
            int y2 = rand.Next(minY, maxY);
            Circle f1 = new Circle(x, y,  x, y, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)},
                new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, rand.Next(minB, maxB),
                rand.Next(10,100));
            arrObj[index] = f1;
        }
        private static void AddEllipse(int index, int minX, int minY, int maxX, int maxY, int minB, int maxB, DisplayObject[] arrObj, Random rand)
        {
            int x = rand.Next(minX, maxX);
            int y = rand.Next(minY, maxY);
            Ellipse f1 = new Ellipse(x, y, x, y, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)},
                new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, rand.Next(1, 10),
                rand.Next(10, 100), rand.Next(10,100));
            arrObj[index] = f1;
        }
        private static void AddEquilateralTriangle(int index, int minX, int minY, int maxX, int maxY, int minB, int maxB, DisplayObject[] arrObj, Random rand)
        {
            int x = rand.Next(minX, maxX);
            int y = rand.Next(minY, maxY);
            EquilateralTriangle f1 = new EquilateralTriangle(x, y, x, y, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)},
                new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, rand.Next(1, 10),
                rand.Next(10,100));
            arrObj[index] = f1;
        }
        private static void AddIsoscelesTriangle(int index, int minX, int minY, int maxX, int maxY, int minB, int maxB, DisplayObject[] arrObj, Random rand)
        {
            int x = rand.Next(minX, maxX);
            int y = rand.Next(minY, maxY);
            IsoscelesTriangle f1 = new IsoscelesTriangle(x, y, x, y, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)},
                new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, rand.Next(1, 10),
                rand.Next(10,100), rand.Next(10,100));
            arrObj[index] = f1;
        }
        private static void AddRectangle(int index, int minX, int minY, int maxX, int maxY, int minB, int maxB, DisplayObject[] arrObj, Random rand)
        {
            int x = rand.Next(minX, maxX);
            int y = rand.Next(minY, maxY);
            Rectangle f1 = new Rectangle(x, y, x, y, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)},
                new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, rand.Next(1, 10),
                rand.Next(10,100), rand.Next(10,100));
            arrObj[index] = f1;
        }
        private static void AddSection(int index, int minX, int minY, int maxX, int maxY, int minB, int maxB, DisplayObject[] arrObj, Random rand)
        {
            int x = rand.Next(minX, maxX);
            int y = rand.Next(minY, maxY);
            int x2 = rand.Next(minX, maxX);
            int y2 = rand.Next(minY, maxY);
            Section f1 = new Section(x, y, x, y, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)},
                new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, rand.Next(1, 4),
                x2, y2, rand.Next(5,10));
            arrObj[index] = f1;
        }
        private static void AddSquare(int index, int minX, int minY, int maxX, int maxY, int minB, int maxB, DisplayObject[] arrObj, Random rand)
        {
            int x = rand.Next(minX, maxX);
            int y = rand.Next(minY, maxY);
            Square f1 = new Square(x, y, x, y, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)},
                new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, rand.Next(1, 10),
                rand.Next(10, 100));
            arrObj[index] = f1;
        }
        private static void AddTriangle(int index, int minX, int minY, int maxX, int maxY, int minB, int maxB, DisplayObject[] arrObj, Random rand)
        {
            int x = rand.Next(minX, maxX);
            int y = rand.Next(minY, maxY);
            int pMinX = x - 100;
            int pMaxX = x + 100;
            int pMinY = y - 100;
            int pMaxY = y + 100;
            Triangle f1 = new Triangle(x, y, x, y, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)},
                new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, rand.Next(1, 10),
                rand.Next(pMinX, pMaxX), rand.Next(pMinY, pMaxY), rand.Next(pMinX, pMaxX), rand.Next(pMinY, pMaxY));
            arrObj[index] = f1;
        }
        
        public static GameField GenerateObjects(int width, int height, int minX, int minY, int maxX, int maxY)
        {
            int index = 0;  //индекс для заполнения массива фигурами
            Random rand = new Random();
            
            const int minB = 1;
            const int maxB = 10;

            int border = 10;
            GameField gameField = new GameField(border/2, border/2,border/2, border/2, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, border, width - border, height - border);
            gameField.arr = new DisplayObject[10 * 8];
            minX += border / 2;
            minY += border / 2;
            maxX -= border;
            maxY -= border;
            
            for (int i = 0; i < 10; i++)
            {
                AddCircle(index, minX, minY, maxX, maxY, minB, maxB, gameField.arr, rand);
                index++;
            }
            for (int i = 0; i < 10; i++)
            {
                AddEllipse(index, minX, minY, maxX, maxY, minB, maxB, gameField.arr, rand);
                index++;
            }
            for (int i = 0; i < 10; i++)
            {
                AddEquilateralTriangle(index, minX, minY, maxX, maxY, minB, maxB, gameField.arr, rand);
                index++;
            }
            for (int i = 0; i < 10; i++)
            {
                AddIsoscelesTriangle(index, minX, minY, maxX, maxY, minB, maxB, gameField.arr, rand);
                index++;
            }
            for (int i = 0; i < 10; i++)
            {
                AddRectangle(index, minX, minY, maxX, maxY, minB, maxB, gameField.arr, rand);
                index++;
            }
            for (int i = 0; i < 10; i++)
            {
                AddSection(index, minX, minY, maxX, maxY, minB, maxB, gameField.arr, rand);
                index++;
            }
            for (int i = 0; i < 10; i++)
            {
                AddSquare(index, minX, minY, maxX, maxY, minB, maxB, gameField.arr, rand);
                index++;
            }
            for (int i = 0; i < 10; i++)
            {
                AddTriangle(index, minX, minY, maxX, maxY, minB, maxB, gameField.arr, rand);
                index++;
            }
            return gameField;
        }
    }
}