using System;
using System.Drawing;

namespace OOP_lab_1
{
    public class Triangle : DisplayObject
    {
        private readonly int _X2;
        private readonly int _Y2;
        private readonly int _X3;
        private readonly int _Y3;
        
        override public void Draw(Graphics g)
        {
            using (var pen = new Pen(_borderColor, _borderSize))
            {
                using (var brush = new SolidBrush(_fillColor))
                {
                    g.FillPolygon(brush, new Point[] {new Point(_X1, _Y1), new Point(_X2, _Y2), new Point(_X3, _Y3)});
                    g.DrawPolygon(pen, new Point[] {new Point(_X1, _Y1), new Point(_X2, _Y2), new Point(_X3, _Y3)});
                }
            }
        }
        
        public Triangle(int x1, int y1, Color fillColor, Color borderColor, int borderSize, int x2, int y2, int x3, int y3) : base(x1, y1, fillColor, borderColor, borderSize)
        {
            _X2 = x2;
            _Y2 = y2;
            _X3 = x3;
            _Y3 = y3;
            
            int minX = Math.Min(Math.Min(_X1, _X2), _X3);
            int maxX = Math.Max(Math.Max(_X1, _X2), _X3);
            int minY = Math.Min(Math.Min(_Y1, _Y2), _Y3);
            int maxY = Math.Max(Math.Max(_Y1, _Y2), _Y3);
            
            _rectX1 = minX - borderSize / 2;
            _rectY1 = minY - borderSize / 2;
            _rectX2 = maxX + borderSize / 2;
            _rectY2 = maxY + borderSize / 2;
        }
    }
}