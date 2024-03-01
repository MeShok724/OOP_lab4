using System.Drawing;

namespace OOP_lab_1
{
    public class IsoscelesTriangle : DisplayObject
    {
        private readonly int _width;
        private readonly int _height;
        override public void Draw(Graphics g)
        {
            using (var pen = new Pen(_borderColor, _borderSize * 2))
            {
                using (var brush = new SolidBrush(_fillColor))
                {
                    g.DrawPolygon(pen, new []{ new Point(_pos.X + _width/2, _pos.Y), new Point(_pos.X, _pos.Y + _height), new Point(_pos.X + _width, _pos.Y + _height) });
                    g.FillPolygon(brush,new []{ new Point(_pos.X + _width/2, _pos.Y), new Point(_pos.X, _pos.Y + _height), new Point(_pos.X + _width, _pos.Y + _height) });
                }
            }
        }
        
        public IsoscelesTriangle(Point pos, Color fillColor, Color borderColor, int borderSize, int width, int height) : base(pos, fillColor, borderColor, borderSize)
        {
            condRect.posStart.x = pos.X - _borderSize;
            condRect.posStart.y = pos.Y - _borderSize;
            condRect.posEnd.x = pos.X + width + _borderSize;
            condRect.posEnd.y = pos.Y + height + _borderSize;
            _width = width;
            _height = height;
        }
    }
}