using System;
using System.Drawing;

namespace OOP_lab_1
{
    public abstract class DisplayObject
    {
        protected double _createTime;
        protected int _speed = 10;
        protected double _speedCorner = 0.5;
        protected int _boost = 10;
        protected double _boostCorner = 0.5;
        protected readonly int _XStart, _YStart;   // точка создания 
        protected int _X, _Y;   // точка привзки
        protected int _outRectX1, _outRectY1;  // верхняя левая точка с учетом рамки
        protected int _outRectX2, _outRectY2;  // нижняя правая точка с учетом рамки
        protected int _inRectX1, _inRectY1;  // верхняя левая точка клиентской части
        protected int _inRectX2, _inRectY2;  // нижняя правая точка клиентской части
        protected readonly int[] _fillColor = new int[3];   // цвет заливки
        protected readonly int[] _borderColor = new int[3]; // цвет границы
        protected readonly int _borderSize; // толщина границы
        public abstract void Draw(Graphics g);
        protected DisplayObject(int x, int y, int[] fillColor, int[] borderColor, int borderSize, int speed, double speedCorner, int boost, double boostCorner)
        {
            _createTime = DateTime.Now.Minute*60 + DateTime.Now.Second + DateTime.Now.Millisecond*0.001;
            _X = x;
            _Y = y;
            _XStart = x;
            _YStart = y;
            Array.Copy(fillColor, _fillColor, 3);
            Array.Copy(borderColor, _borderColor, 3);
            _borderSize = borderSize;
            _speed = speed;
            _speedCorner = speedCorner;
            _boost = boost;
            _boostCorner = boostCorner;
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

        public void Move()
        {
            double currTime = DateTime.Now.Minute*60 + DateTime.Now.Second + DateTime.Now.Millisecond*0.001;
            double diffTime = currTime - _createTime;
            double speedX = _speed * Math.Cos(_speedCorner);
            double speedY = _speed * Math.Sin(_speedCorner);
            double boostX = _boost * Math.Cos(_boostCorner);
            double boostY = _boost * Math.Sin(_boostCorner);
            double currX = _XStart + speedX * diffTime + (boostX * Math.Pow(diffTime, 2)) / 2;
            double currY = _YStart + speedY * diffTime + (boostY * Math.Pow(diffTime, 2)) / 2;
            Update((int)Math.Round(currX), (int)Math.Round(currY));
        }

        public bool BehindTheField(int minX, int minY, int maxX, int maxY)
        {
            return _X <= minX || _X >= maxX || _Y <= minY || _Y >= maxY;
        }

        public int GetX => _X;
        public int GetY => _Y;
    }
}