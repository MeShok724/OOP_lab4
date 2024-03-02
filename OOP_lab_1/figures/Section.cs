using System;
using System.Drawing;

namespace OOP_lab_1
{
    public class Section : DisplayObject
    {
        private readonly Point _posEnd = new Point();
        private readonly int _width;
        private Point _posFillStart = new Point();
        private Point _posFillEnd = new Point();

        override public void Draw(Graphics g)
        {
            using (var pen = new Pen(_borderColor, _borderSize * 2 + _width))
            {
                using (var penFill = new Pen(_fillColor, _width))
                {
                    g.DrawLine(pen, _pos, _posEnd);
                    g.DrawLine(penFill,_posFillStart, _posFillEnd);
                }
            }
        }

        private void FindFillPoint()
        {
            double dist = Math.Sqrt(Math.Pow(_posEnd.X - _pos.X, 2) + Math.Pow(_posEnd.Y - _pos.Y, 2));
            double k = Math.Round(dist / _borderSize);
            int diffX = (int)Math.Round((_posEnd.X - _pos.X) / k);
            int diffY = (int)Math.Round((_posEnd.Y - _pos.Y) / k);
            diffX = Math.Abs(diffX);
            diffY = Math.Abs(diffY);
            if (_posEnd.X - _pos.X >= 0)
            {
                _posFillStart.X = _pos.X + diffX;
                _posFillEnd.X = _posEnd.X - diffX;
            } else {
                _posFillStart.X = _pos.X - diffX;
                _posFillEnd.X = _posEnd.X + diffX;
            }
            if (_posEnd.Y - _pos.Y >= 0)
            {
                _posFillStart.Y = _pos.Y + diffY;
                _posFillEnd.Y = _posEnd.Y - diffY;
            } else {
                _posFillStart.Y = _pos.Y - diffY;
                _posFillEnd.Y = _posEnd.Y + diffY;
            }
        }
        
        public Section(Point pos, Color fillColor, Color borderColor, int borderSize, Point posEnd, int width) : base(pos, fillColor, borderColor, borderSize)
        {
            condRect.posStart.x = pos.X;
            condRect.posStart.y = pos.Y;
            condRect.posEnd.x = posEnd.X;
            condRect.posEnd.y = posEnd.Y;
            _posEnd = posEnd;
            _width = width;
            FindFillPoint();
        }
    }
}