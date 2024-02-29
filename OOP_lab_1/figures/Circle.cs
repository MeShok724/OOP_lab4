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
                    g.DrawEllipse(pen, _pos.x-_radius, _pos.y-_radius, _radius*2, _radius*2);
                    g.FillEllipse(brush, _pos.x-_radius, _pos.y-_radius, _radius*2, _radius*2);
                }
            }
        }
        
        public Circle(MyPoint pos, Color fillColor, Color borderColor, int borderSize, int radius) : base(pos, fillColor, borderColor, borderSize)
        {
            _radius = radius;
            condRect.posStart.x = pos.x - radius - _borderSize;
            condRect.posStart.y = pos.y - radius - _borderSize;
            condRect.posEnd.x = pos.x + radius + _borderSize;
            condRect.posEnd.y = pos.y + radius + _borderSize;
        }
    }
}