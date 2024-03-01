using System;
using System.Drawing;

namespace OOP_lab_1
{
    public class EquilateralTriangle : DisplayObject
    {
        private readonly int _width;
        private readonly int _heigth;
        override public void Draw(Graphics g)
        {
            using (var pen = new Pen(_borderColor, _borderSize * 2))
            {
                using (var brush = new SolidBrush(_fillColor))
                {
                    g.DrawPolygon(pen, new []{ new Point(_pos.X + _width/2, _pos.Y), new Point(_pos.X, _pos.Y + _heigth), new Point(_pos.X + _width, _pos.Y + _heigth) });
                    g.FillPolygon(brush,new []{ new Point(_pos.X + _width/2, _pos.Y), new Point(_pos.X, _pos.Y + _heigth), new Point(_pos.X + _width, _pos.Y + _heigth) });
                }
            }
        }
        
        public EquilateralTriangle(Point pos, Color fillColor, Color borderColor, int borderSize, int width) : base(pos, fillColor, borderColor, borderSize)
        {
            _width = width;
            _heigth = (int)Math.Round(width * Math.Sqrt(3) / 2);
            condRect.posStart.x = pos.X - _borderSize;
            condRect.posStart.y = pos.Y - _borderSize;
            condRect.posEnd.x = pos.X + _width + _borderSize;
            condRect.posEnd.y = pos.Y + _heigth + _borderSize;
        }
    }
}