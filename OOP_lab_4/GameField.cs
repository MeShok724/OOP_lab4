using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace OOP_lab_4
{
    public class GameField : Rectangle
    {
        public DisplayObject[] arr;
        private static int _maxRecursionCount = 10;
        
        public GameField(int X, int Y,int x1, int y1,  int speed, double angle, int boost, int[] fillColor, int[] borderColor, int borderSize, int width, int heigth) : base(X, Y, x1, y1, speed, angle, boost, fillColor, borderColor, borderSize, width, heigth)
        {
        }

        public static bool AddCircle(int index, int minX, int minY, int maxX, int maxY, int minB, int maxB, int minSpeed, int maxSpeed, int maxBoost, int maxCorner, DisplayObject[] arrObj, Random rand, int recursionCount = 0)
        {
            int borderSize = rand.Next(minB, maxB);
            int radius = rand.Next(10, 50);
            int x = rand.Next(minX + borderSize, maxX - borderSize*2 - radius*2);
            int y = rand.Next(minY + borderSize, maxY - borderSize*2 - radius*2);
            int speed = rand.Next(minSpeed, maxSpeed);
            int boost = rand.Next(maxBoost);
            int speedCornerGrad = rand.Next(maxCorner);
            double speedCorner = (speedCornerGrad) * Math.PI / 180;
            // int x2 = rand.Next(minX, maxX);
            // int y2 = rand.Next(minY, maxY);
            Circle createdObj = new Circle(x, y,  x, y, speed, speedCorner, boost, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)},
                new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, borderSize, radius);
            bool isValid = true;
            for (int i = 0; i < index; i++)
            {
                var currObj = arrObj[i];
                if (createdObj.IntersectsWith(currObj))
                {
                    isValid = false;
                    break;
                }
            }
            if (isValid)
            {
                arrObj[index] = createdObj;
                return true;
            }
            else
            {
                if (recursionCount >= _maxRecursionCount)
                    return false;
                recursionCount++;
                return AddCircle(index, minX, minY,  maxX,  maxY,  minB,  maxB, minSpeed,  maxSpeed,  maxBoost,  maxCorner, arrObj, rand, recursionCount);
            }
        }
        public static GameField GenerateCircles(int circleCount, int width, int height, int minX, int minY, int maxX, int maxY,
            int minSpeed, int maxSpeed, int maxBoost, int border)
        {
            int index = 0;  //индекс для заполнения массива фигурами
            Random rand = new Random();
            int numObj = circleCount;
            double maxCorner = 2 * Math.PI;
            int maxCornerGrad = 360;
            double corner2 = (270 + 45)*Math.PI / 180;
            int radius = 45;
            int borderR = 10;
            int speed = 40;
            int boost = 10;
            int x = minX + border + borderR/2;
            int y = maxY - radius * 2 - borderR/2 - border;
            int xCent = x + borderR / 2 + radius;
            int yCent = y + borderR / 2 + radius;
            
            GameField gameField = new GameField(minX + border/2, minY + border/2,minX + border/2, minY + border/2,
                0, 0, 0, new int[] {rand.Next(255), rand.Next(255), rand.Next(255)}, 
                new int[] {rand.Next(255), rand.Next(255), rand.Next(255)},
                border, maxX - minX - border, maxY - minY - border);
            gameField.arr = new DisplayObject[numObj];
            bool success = true;
            for (int i = 0; i < numObj; i++)
            {
                bool result = AddCircle(i, minX + border, minY + border, maxX - border, maxY - border, 0, 10, minSpeed, maxSpeed, maxBoost, maxCornerGrad, gameField.arr,
                    rand);
                if (!result)
                    success = false;
            }

            if (!success)
                return null;
            return gameField;
        }
    }
}