﻿using System.Drawing;

namespace OOP_lab_4
{
    public class Circle : DisplayObject
    {
        protected int _X1, _Y1;
        protected int _X2, _Y2;
        public override void Draw(Graphics g)
        {
            Color fillColor = Color.FromArgb(_fillColor[0], _fillColor[1], _fillColor[2]);
            Color borderColor = Color.FromArgb(_borderColor[0], _borderColor[1], _borderColor[2]);
            using (var pen = new Pen(borderColor, _borderSize))
            {
                using (var brush = new SolidBrush(fillColor))
                {
                    g.FillEllipse(brush, _X1, _Y1, _X2 - _X1, _Y2 - _Y1);
                    g.DrawEllipse(pen, _X1, _Y1, _X2 - _X1, _Y2 - _Y1);
                }
            }
        }
        public Circle(int X, int Y,int x1, int y1,  int speed, double angle, int boost, int[] fillColor, int[] borderColor, int borderSize, int radius) : base(X, Y,fillColor, borderColor, borderSize, speed, angle, boost)
        {
            _X1 = x1;
            _Y1 = y1;
            _X2 = x1 + 2 * radius;
            _Y2 = y1 + 2 * radius;
            _outRectX1 = _X1 - borderSize / 2;
            _outRectY1 = _Y1 - borderSize / 2;
            _outRectX2 = _X1 + 2 * radius + borderSize / 2;
            _outRectY2 = _Y1 + 2 * radius + borderSize / 2;
            _inRectX1 =  _outRectX1 + borderSize;
            _inRectY1 = _outRectY1 + borderSize;
            _inRectX2 = _outRectX2 - borderSize;
            _inRectY2 = _outRectY2 - borderSize;
        }
        public override void MoveTo(int x, int y)
        {
            int diffX = x - _X;
            int diffY = y - _Y;
            if (diffY == 0 && diffX == 0)
            {
                _speed += 1;
            }
            _X = x;
            _Y = y;
            _X1 += diffX;
            _Y1 += diffY;
            _X2 += diffX;
            _Y2 += diffY;
            _outRectX1 += diffX;
            _outRectY1 += diffY;
            _outRectX2 += diffX;
            _outRectY2 += diffY;
            _inRectX1 += diffX;
            _inRectY1 += diffY;
            _inRectX2 += diffX;
            _inRectY2 += diffY;
        }
    }
}