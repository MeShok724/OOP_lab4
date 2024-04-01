using System;
using System.Drawing;

namespace OOP_lab_1
{
    public abstract class DisplayObject
    {
        protected int _X, _Y;   // точка привзки
        protected int _outRectX1, _outRectY1;  // верхняя левая точка с учетом рамки
        protected int _outRectX2, _outRectY2;  // нижняя правая точка с учетом рамки
        protected int _inRectX1, _inRectY1;  // верхняя левая точка клиентской части
        protected int _inRectX2, _inRectY2;  // нижняя правая точка клиентской части
        protected readonly int[] _fillColor = new int[3];   // цвет заливки
        protected readonly int[] _borderColor = new int[3]; // цвет границы
        protected readonly int _borderSize; // толщина границы
        public abstract void Draw(Graphics g);
        protected DisplayObject(int x, int y, int[] fillColor, int[] borderColor, int borderSize)
        {
            _X = x;
            _Y = y;
            Array.Copy(fillColor, _fillColor, 3);
            Array.Copy(borderColor, _borderColor, 3);
            _borderSize = borderSize;
        }

        public virtual void Update(int x, int y)
        {
            int diffX = x - _X;
            int diffY = y - _Y;
            _X = x;
            _Y = y;
            _outRectX1 += diffX;
            _outRectY1 += diffY;
            _outRectX2 += diffX;
            _outRectY2 += diffY;
            _inRectX1 += diffX;
            _inRectY1 += diffY;
            _inRectX2 += diffX;
            _inRectY2 += diffY;
        }

        public int GetX => _X;
        public int GetY => _Y;
    }
}