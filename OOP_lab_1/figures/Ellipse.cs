using System.Drawing;

namespace OOP_lab_1
{
    public class Ellipse : DisplayObject
    {
        private readonly int _X2;
        private readonly int _Y2;
        override public void Draw(Graphics g)
        {
            using (var pen = new Pen(_borderColor, _borderSize))
            {
                using (var brush = new SolidBrush(_fillColor))
                {
                    g.FillEllipse(brush, _X1, _Y1, _X2 - _X1, _Y2 - _Y1);
                    g.DrawEllipse(pen, _X1, _Y1, _X2 - _X1, _Y2 - _Y1);
                }
            }
        }
        
        public Ellipse(int x1, int y1, Color fillColor, Color borderColor, int borderSize, int rx, int ry) : base(x1, y1, fillColor, borderColor, borderSize)
        {
            _X2 = x1 + 2 * rx;
            _Y2 = y1 + 2 * ry;
            _rectX1 = _X1 - borderSize / 2;
            _rectY1 = _Y1 - borderSize / 2;
            _rectX2 = _X1 + 2 * rx + borderSize / 2;
            _rectY2 = _Y1 + 2 * ry + borderSize / 2;
        }
    }
}