using System;
using System.Drawing;

namespace OOP_lab_1
{
    public class Triangle : DisplayObject
    {
        private readonly Point _point1 = new Point();
        private readonly Point _point2 = new Point();
        private readonly Point _point3 = new Point();
        
        override public void Draw(Graphics g)
        {
            using (var pen = new Pen(_borderColor, _borderSize * 2))
            {
                using (var brush = new SolidBrush(_fillColor))
                {
                    g.DrawPolygon(pen, new []{_point1, _point2, _point3});
                    g.FillPolygon(brush,new []{_point1, _point2, _point3});
                }
            }
        }
        
        public Triangle(Point pos1, Color fillColor, Color borderColor, int borderSize, Point pos2, Point pos3) : base(pos1, fillColor, borderColor, borderSize)
        {
            int minX = Math.Min(Math.Min(_point1.X, _point2.X), _point3.X);
            int maxX = Math.Max(Math.Max(_point1.X, _point2.X), _point3.X);
            int minY = Math.Min(Math.Min(_point1.Y, _point2.Y), _point3.Y);
            int maxY = Math.Max(Math.Max(_point1.Y, _point2.Y), _point3.Y);
            
            condRect.posStart.x = minX - _borderSize;
            condRect.posStart.y = minY - _borderSize;
            condRect.posEnd.x = maxX + _borderSize;
            condRect.posEnd.y = maxY + _borderSize;

            _point1.X = pos1.X;
            _point1.Y = pos1.Y;
            _point2.X = pos2.X;
            _point2.Y = pos2.Y;
            _point3.X = pos3.X;
            _point3.Y = pos3.Y;
        }
    }
}