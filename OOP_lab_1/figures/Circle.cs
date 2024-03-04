using System.Drawing;

namespace OOP_lab_1
{
    public class Circle : DisplayObject
    {
        private readonly int _radius;
        public override void Draw(Graphics g)
        {
            using (var pen = new Pen(_borderColor, _borderSize))
            {
                using (var brush = new SolidBrush(_fillColor))
                {
                    g.FillEllipse(brush, _X1-_radius, _Y1-_radius, _radius*2, _radius*2);
                    g.DrawEllipse(pen, _X1-_radius, _Y1-_radius, _radius*2, _radius*2);
                }
            }
        }
        
        public Circle(int x1, int y1, Color fillColor, Color borderColor, int borderSize, int radius) : base(x1, y1, fillColor, borderColor, borderSize)
        {
            _radius = radius;
            _rectX1 = _X1 - _radius - borderSize / 2;
            _rectY1 = _Y1 - _radius - borderSize / 2;
            _rectX2 = _X1 + _radius + borderSize / 2;
            _rectY2 = _Y1 + _radius + borderSize / 2;
        }
    }
}