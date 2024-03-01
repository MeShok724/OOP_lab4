using System.Drawing;

namespace OOP_lab_1
{
    public class Square : DisplayObject
    {
        private readonly int _side;
        override public void Draw(Graphics g)
        {
            using (var pen = new Pen(_borderColor, _borderSize*2))
            {
                using (var brush = new SolidBrush(_fillColor))
                {
                    g.DrawRectangle(pen, _pos.X, _pos.Y, _side, _side);
                    g.FillRectangle(brush, _pos.X, _pos.Y, _side, _side);
                }
            }
        }
        
        public Square(Point pos, Color fillColor, Color borderColor, int borderSize, int side) : base(pos, fillColor, borderColor, borderSize)
        {
            condRect.posStart.x = pos.X - _borderSize;
            condRect.posStart.y = pos.Y - _borderSize;
            _side = side;
            condRect.posEnd.x = pos.X + _side + _borderSize;
            condRect.posEnd.y = pos.Y + _side + _borderSize;
        }
    }
}