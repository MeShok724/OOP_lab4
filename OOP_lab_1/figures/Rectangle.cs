using System.Drawing;

namespace OOP_lab_1
{
    public class Rectangle : DisplayObject
    {
        private readonly int _width;
        private readonly int _height;
        override public void Draw(Graphics g)
        {
            using (var pen = new Pen(_borderColor, _borderSize*2))
            {
                using (var brush = new SolidBrush(_fillColor))
                {
                    g.DrawRectangle(pen, _pos.X, _pos.Y, _width, _height);
                    g.FillRectangle(brush, _pos.X, _pos.Y, _width, _height);
                }
            }
        }
        
        public Rectangle(Point pos, Color fillColor, Color borderColor, int borderSize, int width, int height) : base(pos, fillColor, borderColor, borderSize)
        {
            condRect.posStart.x = pos.X - _borderSize;
            condRect.posStart.y = pos.Y - _borderSize;
            _width = width;
            _height = height;
            condRect.posEnd.x = pos.X + width + _borderSize;
            condRect.posEnd.y = pos.Y + height + _borderSize;
        }
    }
}