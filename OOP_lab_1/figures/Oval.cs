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
                    g.DrawEllipse(pen, _pos.x-_radiusX, _pos.y-_radiusY, _radiusX*2, _radiusY*2);
                    g.FillEllipse(brush, _pos.x-_radiusX, _pos.y-_radiusY, _radiusX*2, _radiusY*2);
                }
            }
        }
        
        public Oval(MyPoint pos, Color fillColor, Color borderColor, int borderSize, int rx, int ry) : base(pos, fillColor, borderColor, borderSize)
        {
            condRect.posStart.x = pos.x - rx - _borderSize;
            condRect.posStart.y = pos.y - ry - _borderSize;
            condRect.posEnd.x = pos.x + rx + _borderSize;
            condRect.posEnd.y = pos.y + ry + _borderSize;
            _radiusX = rx;
            _radiusY = ry;
        }
    }
}