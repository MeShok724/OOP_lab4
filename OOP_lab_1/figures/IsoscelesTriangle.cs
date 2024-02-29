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
                    g.DrawPolygon(pen, new []{ new Point(_pos.x + _width/2, _pos.y), new Point(_pos.x, _pos.y + _height), new Point(_pos.x + _width, _pos.y + _height) });
                    g.FillPolygon(brush,new []{ new Point(_pos.x + _width/2, _pos.y), new Point(_pos.x, _pos.y + _height), new Point(_pos.x + _width, _pos.y + _height) });
                }
            }
        }
        
        public IsoscelesTriangle(MyPoint pos, Color fillColor, Color borderColor, int borderSize, int width, int height) : base(pos, fillColor, borderColor, borderSize)
        {
            condRect.posStart.x = pos.x - _borderSize;
            condRect.posStart.y = pos.y - _borderSize;
            condRect.posEnd.x = pos.x + width + _borderSize;
            condRect.posEnd.y = pos.y + height + _borderSize;
            _width = width;
            _height = height;
        }
    }
}