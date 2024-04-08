using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace OOP_lab_1
{
    public class GameField : Rectangle
    {
        public DisplayObject[] arr;
        
        public GameField(int X, int Y,int x1, int y1,  int speed, double speedCorner, int boost, double boostCorner, int[] fillColor, int[] borderColor, int borderSize, int width, int heigth) : base(X, Y, x1, y1, speed, speedCorner, boost, boostCorner, fillColor, borderColor, borderSize, width, heigth)
        {
        }

        public static int DeleteObject(DisplayObject[] arrObj, DisplayObject obj)
        {
            int index = Array.IndexOf(arrObj, obj);
            // for (int i = index; i < arrObj.Length - 1; i++)
            // {
            //     arrObj[i] = arrObj[i + 1];
            // }
            // arrObj[arrObj.Length - 1] = null;
            arrObj[index] = null;
            return index;
        }

        public static void AddCircle(int index, int minX, int minY, int maxX, int maxY, int minB, int maxB, int minSpeed, int maxSpeed, int maxBoost, int maxCorner, DisplayObject[] arrObj, Random rand)
        {
            int x = rand.Next(minX, maxX);
            int y = rand.Next(minY, maxY);
            int speed = rand.Next(minSpeed, maxSpeed);
            int boost = rand.Next(maxBoost);
            int speedCorner = rand.Next(maxCorner);
int boostCorner = rand.Next(maxCorner);
            int x2 = rand.Next(minX, maxX);
            int y2 = rand.Next(minY, maxY);
            Circle f1 = new Circle(x, y,  x, y, speed, speedCorner, boost, boostCorner, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)},
                new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, rand.Next(minB, maxB),
                rand.Next(10,50));
            arrObj[index] = f1;
        }
        public static void AddEllipse(int index, int minX, int minY, int maxX, int maxY, int minB, int maxB, int minSpeed, int maxSpeed, int maxBoost, int maxCorner, DisplayObject[] arrObj, Random rand)
        {
            int x = rand.Next(minX, maxX);
            int y = rand.Next(minY, maxY);
            int speed = rand.Next(minSpeed, maxSpeed);
            int boost = rand.Next(maxBoost);
            int speedCorner = rand.Next(maxCorner);
int boostCorner = rand.Next(maxCorner);
            Ellipse f1 = new Ellipse(x, y,  x, y, speed, speedCorner, boost, boostCorner, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)},
                new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, rand.Next(1, 10),
                rand.Next(10, 50), rand.Next(10,50));
            arrObj[index] = f1;
        }
        public static void AddEquilateralTriangle(int index, int minX, int minY, int maxX, int maxY, int minB, int maxB, int minSpeed, int maxSpeed, int maxBoost, int maxCorner, DisplayObject[] arrObj, Random rand)
        {
            int x = rand.Next(minX, maxX);
            int y = rand.Next(minY, maxY);
            int speed = rand.Next(minSpeed, maxSpeed);
            int boost = rand.Next(maxBoost);
            int speedCorner = rand.Next(maxCorner);
int boostCorner = rand.Next(maxCorner);
            EquilateralTriangle f1 = new EquilateralTriangle(x, y,  x, y, speed, speedCorner, boost, boostCorner, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)},
                new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, rand.Next(1, 10),
                rand.Next(10,100));
            arrObj[index] = f1;
        }
        public static void AddIsoscelesTriangle(int index, int minX, int minY, int maxX, int maxY, int minB, int maxB, int minSpeed, int maxSpeed, int maxBoost, int maxCorner, DisplayObject[] arrObj, Random rand)
        {
            int x = rand.Next(minX, maxX);
            int y = rand.Next(minY, maxY);
            int speed = rand.Next(minSpeed, maxSpeed);
            int boost = rand.Next(maxBoost);
            int speedCorner = rand.Next(maxCorner);
int boostCorner = rand.Next(maxCorner);
            IsoscelesTriangle f1 = new IsoscelesTriangle(x, y,  x, y, speed, speedCorner, boost, boostCorner, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)},
                new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, rand.Next(1, 10),
                rand.Next(10,100), rand.Next(10,100));
            arrObj[index] = f1;
        }
        public static void AddRectangle(int index, int minX, int minY, int maxX, int maxY, int minB, int maxB, int minSpeed, int maxSpeed, int maxBoost, int maxCorner, DisplayObject[] arrObj, Random rand)
        {
            int x = rand.Next(minX, maxX);
            int y = rand.Next(minY, maxY);
            int speed = rand.Next(minSpeed, maxSpeed);
            int boost = rand.Next(maxBoost);
            int speedCorner = rand.Next(maxCorner);
int boostCorner = rand.Next(maxCorner);
            Rectangle f1 = new Rectangle(x, y,  x, y, speed, speedCorner, boost, boostCorner, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)},
                new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, rand.Next(1, 10),
                rand.Next(10,100), rand.Next(10,100));
            arrObj[index] = f1;
        }
        public static void AddSection(int index, int minX, int minY, int maxX, int maxY, int minB, int maxB, int minSpeed, int maxSpeed, int maxBoost, int maxCorner, DisplayObject[] arrObj, Random rand)
        {
            int x = rand.Next(minX, maxX);
            int y = rand.Next(minY, maxY);
            int speed = rand.Next(minSpeed, maxSpeed);
            int boost = rand.Next(maxBoost);
            int speedCorner = rand.Next(maxCorner);
int boostCorner = rand.Next(maxCorner);
            int x2 = rand.Next(minX, maxX);
            int y2 = rand.Next(minY, maxY);
            Section f1 = new Section(x, y,  x, y, speed, speedCorner, boost, boostCorner, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)},
                new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, rand.Next(1, 4),
                x2, y2, rand.Next(5,10));
            arrObj[index] = f1;
        }
        public static void AddSquare(int index, int minX, int minY, int maxX, int maxY, int minB, int maxB, int minSpeed, int maxSpeed, int maxBoost, int maxCorner, DisplayObject[] arrObj, Random rand)
        {
            int x = rand.Next(minX, maxX);
            int y = rand.Next(minY, maxY);
            int speed = rand.Next(minSpeed, maxSpeed);
            int boost = rand.Next(maxBoost);
            int speedCorner = rand.Next(maxCorner);
int boostCorner = rand.Next(maxCorner);
            Square f1 = new Square(x, y,  x, y, speed, speedCorner, boost, boostCorner, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)},
                new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, rand.Next(1, 10),
                rand.Next(10, 100));
            arrObj[index] = f1;
        }
        public static void AddTriangle(int index, int minX, int minY, int maxX, int maxY, int minB, int maxB, int minSpeed, int maxSpeed, int maxBoost, int maxCorner, DisplayObject[] arrObj, Random rand)
        {
            int x = rand.Next(minX, maxX);
            int y = rand.Next(minY, maxY);
            int speed = rand.Next(minSpeed, maxSpeed);
            int boost = rand.Next(maxBoost);
            int speedCorner = rand.Next(maxCorner);
int boostCorner = rand.Next(maxCorner);
            int pMinX = x - 100;
            int pMaxX = x + 100;
            int pMinY = y - 100;
            int pMaxY = y + 100;
            Triangle f1 = new Triangle(x, y,  x, y, speed, speedCorner, boost, boostCorner, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)},
                new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, rand.Next(1, 10),
                rand.Next(pMinX, pMaxX), rand.Next(pMinY, pMaxY), rand.Next(pMinX, pMaxX), rand.Next(pMinY, pMaxY));
            arrObj[index] = f1;
        }

        public static GameField GenerateTwoCircles(int width, int height, int minX, int minY, int maxX, int maxY,
            int minSpeed, int maxSpeed, int maxBoost)
        {
            int index = 0;  //индекс для заполнения массива фигурами
            Random rand = new Random();
            int numObj = 3;
            double corner1 = 0;
            double corner2 = (270 + 45)*Math.PI / 180;
            int radius = 45;
            int borderR = 10;
            int speed = 40;
            int boost = 10;
            int border = 10;
            int x = minX + border + borderR/2;
            int y = maxY - radius * 2 - borderR/2 - border;
            int xCent = x + borderR / 2 + radius;
            int yCent = y + borderR / 2 + radius;
            
            GameField gameField = new GameField(minX + border/2, minY + border/2,minX + border/2, minY + border/2,
                0, 0, 0, 0, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, 
                new int[] {rand.Next(255), rand.Next(255), rand.Next(255)},
                border, maxX - minX - border, maxY - minY - border);
            gameField.arr = new DisplayObject[numObj];
            gameField.arr[0] = new Circle(xCent, yCent, x, y, speed, corner1, boost, corner1, new int[] { 255, 255, 255 },
                new int[] { 255, 0, 0 }, borderR, radius);
            gameField.arr[1] = new Circle(xCent, yCent, x, y, speed, corner2, boost, corner2, new int[] { 255, 255, 255 },
                new int[] { 255, 0, 0 }, borderR, radius);
            gameField.arr[2] = new Circle(xCent, yCent, x, y, 0, corner2, 0, corner2, new int[] { 255, 255, 255 },
                new int[] { 255, 0, 0 }, borderR, radius);
            return gameField;
        }
        
        public static GameField GenerateObjects(int width, int height, int minX, int minY, int maxX, int maxY , int minSpeed, int maxSpeed, int maxBoost)
        {
            int index = 0;  //индекс для заполнения массива фигурами
            Random rand = new Random();
            int numObj = 1;
            const int minB = 1;
            const int maxB = 10;
            const int minBoost = 0;
            const int maxCorner = 360;

            int border = 10;
            GameField gameField = new GameField(minX + border/2, minY + border/2,minX + border/2, minY + border/2, 0, 0, 0, 0, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, border, width - border, height - border);
            gameField.arr = new DisplayObject[numObj * 8];
            minX += border + 50;
            minY += border + 50;
            maxX = maxX - border - 100;
            maxY = maxY - border - 100;
            
            for (int i = 0; i < numObj; i++)
            {
                AddCircle(index, minX, minY, maxX, maxY, minB, maxB, minSpeed, maxSpeed, maxBoost, maxCorner, gameField.arr, rand);
                index++;
            }
            for (int i = 0; i < numObj; i++)
            {
                AddEllipse(index, minX, minY, maxX, maxY, minB, maxB, minSpeed, maxSpeed, maxBoost, maxCorner, gameField.arr, rand);
                index++;
            }
            for (int i = 0; i < numObj; i++)
            {
                AddEquilateralTriangle(index, minX, minY, maxX, maxY, minB, maxB, minSpeed, maxSpeed, maxBoost, maxCorner, gameField.arr, rand);
                index++;
            }
            for (int i = 0; i < numObj; i++)
            {
                AddIsoscelesTriangle(index, minX, minY, maxX, maxY, minB, maxB, minSpeed, maxSpeed, maxBoost, maxCorner, gameField.arr, rand);
                index++;
            }
            for (int i = 0; i < numObj; i++)
            {
                AddRectangle(index, minX, minY, maxX, maxY, minB, maxB, minSpeed, maxSpeed, maxBoost, maxCorner, gameField.arr, rand);
                index++;
            }
            for (int i = 0; i < numObj; i++)
            {
                AddSection(index, minX, minY, maxX, maxY, minB, maxB, minSpeed, maxSpeed, maxBoost, maxCorner, gameField.arr, rand);
                index++;
            }
            for (int i = 0; i < numObj; i++)
            {
                AddSquare(index, minX, minY, maxX, maxY, minB, maxB, minSpeed, maxSpeed, maxBoost, maxCorner, gameField.arr, rand);
                index++;
            }
            for (int i = 0; i < numObj; i++)
            {
                AddTriangle(index, minX, minY, maxX, maxY, minB, maxB, minSpeed, maxSpeed, maxBoost, maxCorner, gameField.arr, rand);
                index++;
            }
            return gameField;
        }
    }
}