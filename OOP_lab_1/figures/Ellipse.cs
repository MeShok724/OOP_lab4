using System.Drawing;

namespace OOP_lab_1
{
    public class Ellipse : DisplayObject
    {
        private readonly int _rX;
        private readonly int _rY;
        override public void Draw(Graphics g)
        {
            using (var pen = new Pen(_borderColor, _borderSize))
            {
                using (var brush = new SolidBrush(_fillColor))
                {
                    g.FillEllipse(brush, _X1-_rX, _Y1-_rY, _rX*2, _rY*2);
                    g.DrawEllipse(pen, _X1-_rX, _Y1-_rY, _rX*2, _rY*2);
                }
            }
        }
        
        public Ellipse(int x1, int y1, Color fillColor, Color borderColor, int borderSize, int rx, int ry) : base(x1, y1, fillColor, borderColor, borderSize)
        {
            _rX = rx;
            _rY = ry;
            _rectX1 = _X1 - _rX - borderSize / 2;
            _rectY1 = _Y1 - _rY - borderSize / 2;
            _rectX2 = _X1 + _rX + borderSize / 2;
            _rectY2 = _Y1 + _rY + borderSize / 2;
        }
    }
}