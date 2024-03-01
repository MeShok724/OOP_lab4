using System.Drawing;

namespace OOP_lab_1
{
    public class Oval : DisplayObject
    {
        private readonly int _radiusX;
        private readonly int _radiusY;
        override public void Draw(Graphics g)
        {
            using (var pen = new Pen(_borderColor, _borderSize * 2))
            {
                using (var brush = new SolidBrush(_fillColor))
                {
                    g.DrawEllipse(pen, _pos.X-_radiusX, _pos.Y-_radiusY, _radiusX*2, _radiusY*2);
                    g.FillEllipse(brush, _pos.X-_radiusX, _pos.Y-_radiusY, _radiusX*2, _radiusY*2);
                }
            }
        }
        
        public Oval(Point pos, Color fillColor, Color borderColor, int borderSize, int rx, int ry) : base(pos, fillColor, borderColor, borderSize)
        {
            condRect.posStart.x = pos.X - rx - _borderSize;
            condRect.posStart.y = pos.Y - ry - _borderSize;
            condRect.posEnd.x = pos.X + rx + _borderSize;
            condRect.posEnd.y = pos.Y + ry + _borderSize;
            _radiusX = rx;
            _radiusY = ry;
        }
    }
}