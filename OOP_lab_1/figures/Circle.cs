using System.Drawing;

namespace OOP_lab_1
{
    public class Circle : DisplayObject
    {
        private readonly int _radius;
        public override void Draw(Graphics g)
        {
            using (var pen = new Pen(_borderColor, _borderSize * 2))
            {
                using (var brush = new SolidBrush(_fillColor))
                {
                    g.DrawEllipse(pen, _pos.X-_radius, _pos.Y-_radius, _radius*2, _radius*2);
                    g.FillEllipse(brush, _pos.X-_radius, _pos.Y-_radius, _radius*2, _radius*2);
                }
            }
        }
        
        public Circle(Point pos, Color fillColor, Color borderColor, int borderSize, int radius) : base(pos, fillColor, borderColor, borderSize)
        {
            _radius = radius;
            condRect.posStart.x = pos.X - radius - _borderSize;
            condRect.posStart.y = pos.Y - radius - _borderSize;
            condRect.posEnd.x = pos.X + radius + _borderSize;
            condRect.posEnd.y = pos.Y + radius + _borderSize;
        }
    }
}