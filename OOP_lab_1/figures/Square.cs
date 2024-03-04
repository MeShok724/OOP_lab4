using System.Drawing;

namespace OOP_lab_1
{
    public class Square : DisplayObject
    {
        private readonly int _X2;
        private readonly int _Y2;
        override public void Draw(Graphics g)
        {
            using (var pen = new Pen(_borderColor, _borderSize*2))
            {
                using (var brush = new SolidBrush(_fillColor))
                {
                    g.FillRectangle(brush, _X1, _Y1, _X2 - _X1, _Y2 - _Y1);
                    g.DrawRectangle(pen, _X1, _Y1, _X2 - _X1, _Y2 - _Y1);
                }
            }
        }
        
        public Square(int x1, int y1, Color fillColor, Color borderColor, int borderSize, int side) : base(x1, y1, fillColor, borderColor, borderSize)
        {
            _X2 = _X1 + side;
            _Y2 = _Y1 + side;
            _rectX1 = _X1 - borderSize / 2;
            _rectY1 = _Y1 - borderSize / 2;
            _rectX2 = _X2 + borderSize / 2;
            _rectY2 = _Y2 + borderSize / 2;
        }
    }
}